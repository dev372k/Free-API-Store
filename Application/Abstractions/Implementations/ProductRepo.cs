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
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDBContext _context;

        public ProductRepo(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<int> Add(AddProductDTO dto)
        {
            Product product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                CategoryId = dto.CategoryId,
                CreatedOn = DateTime.Now,
                ImageUrl = dto.ImageUrl,
                IsDeleted = false
            };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }

        public async Task<int> Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(_ => _.Id == id);
            if (product != null)
            {
                product.IsDeleted = true;
                await _context.SaveChangesAsync();
                return product.Id;
            }
            return 0;
        }

        public List<GetProductDTO> Get(int pageNo, int pageSize)
        {
            var products = _context.Products.Include(_ => _.Category).Select(_ => new GetProductDTO
            {
                Id = _.Id,
                Name = _.Name,
                Description = _.Description,
                Price = _.Price,
                ImageUrl = _.ImageUrl,
                CategoryName = _.Category.Name
            }).Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            return products;
        }

        public GetProductDTO Get(int Id)
        {
            var products = _context.Products.Include(_ => _.Category).Where(_ => _.Id == Id).Select(_ => new GetProductDTO
            {
                Id = _.Id,
                Name = _.Name,
                Description = _.Description,
                Price = _.Price,
                ImageUrl = _.ImageUrl,
                CategoryName = _.Category.Name
            }).FirstOrDefault();
            return products;
        }

        public List<GetProductDTO> GetbyCatogoryId(int categoryId)
        {
            var products = _context.Products.Include(_ => _.Category).Where(_ => _.CategoryId == categoryId).Select(_ => new GetProductDTO
            {
                Id = _.Id,
                Name = _.Name,
                Description = _.Description,
                Price = _.Price,
                ImageUrl = _.ImageUrl,
                CategoryName = _.Category.Name
            }).ToList();
            return products;
        }

        public async Task<int> Update(int id, UpdateProductDTO dto)
        {
            var product = _context.Products.FirstOrDefault(_ => _.Id == id);
            if (product != null)
            {
                product.Name = dto.Name;
                product.Description = dto.Description;
                product.ImageUrl = dto.ImageUrl;
                product.Price = dto.Price;
                product.CategoryId = dto.CategoryId;
                product.UpdatedOn = DateTime.Now;
                await _context.SaveChangesAsync();
                return product.Id;
            }
            return 0;
        }
    }
}
