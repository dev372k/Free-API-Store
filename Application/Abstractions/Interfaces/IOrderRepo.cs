using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Interfaces
{
    public interface IOrderRepo
    {
        List<GetOrderDTO> Get(int pageNo, int pageSize);
        GetOrderDTO Get(int Id);
        Task<int> Add(AddOrderDTO dto);
        Task<int> Update(int id, UpdateOrderDTO dto);
        Task<int> Delete(int id);
    }
}
