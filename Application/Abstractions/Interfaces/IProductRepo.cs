using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Interfaces
{
    public interface IProductRepo
    {
        GetProductDTOs Get(int pageNo, int pageSize);
        GetProductDTO Get(int Id);
        List<GetProductDTO> GetbyCatogoryId(int categoryId);
        Task<int> Add(AddProductDTO dto);
        Task<int> Update(int id, UpdateProductDTO dto);
        Task<int> Delete(int id);
        void Test();
    }
}
