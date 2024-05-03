using Application.Abstractions.Interfaces;
using Application.DTOs;
using Azure;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Implementations
{
    public class OrderRepo : IOrderRepo
    {
        private readonly ApplicationDBContext _context;

        public OrderRepo(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<int> Add(AddOrderDTO dto)
        {
            Order order = new Order
            {
                UserId = dto.UserId,
                ProductId = dto.ProductId
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order.Id;
        }

        public async Task<int> Delete(int id)
        {
            var order = _context.Orders.FirstOrDefault(_ => _.Id == id);
            if (order != null)
            {
                order.IsDeleted = true;
                await _context.SaveChangesAsync();
                return order.Id;
            }
            return 0;
        }

        public List<GetOrderDTO> Get(int pageNo, int pageSize)
        {
            var orders = _context.Orders.Include(_ => _.Product).ThenInclude(_ => _.Category).Include(_ => _.User).Select(_ => new GetOrderDTO
            {
                Id = _.Id,
                User = new GetUserDTO
                {
                    Id = _.User.Id,
                    Name = _.User.Name,
                    Email = _.User.Email
                },
                Product = new GetProductDTO
                {
                    Name = _.Product.Name,
                    Description = _.Product.Description,
                    Price = _.Product.Price,
                    CategoryName = _.Product.Category.Name,
                    ImageUrl = _.Product.ImageUrl
                }
            }).Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            return orders;
        }

        public GetOrderDTO Get(int Id)
        {
            var order = _context.Orders.Include(_ => _.Product).ThenInclude(_ => _.Category).Include(_ => _.User).Where(_ => _.Id == Id).Select(_ => new GetOrderDTO
            {
                Id = _.Id,
                User = new GetUserDTO
                {
                    Id = _.User.Id,
                    Name = _.User.Name,
                    Email = _.User.Email
                },
                Product = new GetProductDTO
                {
                    Name = _.Product.Name,
                    Description = _.Product.Description,
                    Price = _.Product.Price,
                    CategoryName = _.Product.Category.Name,
                    ImageUrl = _.Product.ImageUrl
                }
            }).FirstOrDefault();
            return order;
        }

        public async Task<int> Update(int id, UpdateOrderDTO dto)
        {
            var order = _context.Orders.FirstOrDefault(_ => _.Id == id);
            if (order != null)
            {
                order.ProductId = dto.ProductId;
                order.UserId = dto.UserId;
                order.UpdatedOn = DateTime.Now;
                await _context.SaveChangesAsync();
                return order.Id;
            }
            return 0;
        }
    }
}
