using Application.Abstractions.Interfaces;
using Application.DTOs;
using Azure;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Entities;

namespace Application.Abstractions.Implementations
{
    public class TodoRepo : ITodoRepo
    {
        private ApplicationDBContext _context;

        public TodoRepo(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<int> Add(int userId, UpsertTodoDTO dto)
        {
            Todo todo = new Todo
            {
                Title = dto.Title,
                Description = dto.Description,
                Expiry = dto.Expiry,
                Priority = dto.Priority,
                IsDeleted = false,
                UserId = userId,
                CreatedOn = DateTime.Now
            };
            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();
            return todo.Id;
        }

        public async Task<int> Delete(int id)
        {
            var todo = _context.Todos.FirstOrDefault(_ => _.Id == id);
            if (todo != null)
            {
                todo.IsDeleted = true;
                await _context.SaveChangesAsync();
                return todo.Id;
            }
            else
                throw new Exception("Todo does not exist.");
        }

        public GetTodoDTO Get(int Id)
        {
            var todo = _context.Todos.Where(_ => _.Id == Id).Select(_ => new GetTodoDTO
            {
                Id = _.Id,
                Title = _.Title,
                Description = _.Description,
                CreatedOn = _.CreatedOn,
                Expiry = _.Expiry,
                IsExpired = _.Expiry < DateTime.Now ? true : false,
                Priority = _.Priority.ToString(),
                UpdatedOn = _.UpdatedOn,
                UserId = _.UserId
            }).FirstOrDefault();
            return todo;
        }

        public GetTodoDTOs Get(int userId, int pageNo, int pageSize)
        {
            var query = _context.Todos.AsQueryable();
            var todos = query.Where(_ => _.UserId == userId).Select(_ => new GetTodoDTO
            {
                Id = _.Id,
                Title = _.Title,
                Description = _.Description,
                CreatedOn = _.CreatedOn,
                Expiry = _.Expiry,
                IsExpired = _.Expiry < DateTime.Now ? true : false,
                Priority = _.Priority.ToString(),
                UpdatedOn = _.UpdatedOn,
                UserId = _.UserId
            }).Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();


            return new GetTodoDTOs
            {
                Todos = todos,
                PageNo = pageNo,
                PageSize = pageSize,
                TotalCount = query.Count()
            };
        }

        public async Task<int> Update(int id, UpsertTodoDTO dto)
        {
            var todo = _context.Todos.FirstOrDefault(_ => _.Id == id);
            if (todo != null)
            {
                todo.Title = dto.Title;
                todo.Description = dto.Description;
                todo.UpdatedOn = DateTime.Now;
                todo.Priority = dto.Priority;
                todo.Expiry = dto.Expiry;
                await _context.SaveChangesAsync();
                return todo.Id;
            }
            else
                throw new Exception("Todo does not exist.");
        }
    }
}
