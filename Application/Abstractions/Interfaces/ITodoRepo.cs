using Application.DTOs;

namespace Application.Abstractions.Interfaces
{
    public interface ITodoRepo
    {
        //List<GetTodoDTO> Get(int pageNo, int pageSize);
        GetTodoDTO Get(int Id);
        List<GetTodoDTO> Get(int userId, int pageNo, int pageSize);
        Task<int> Add(int userId, UpsertTodoDTO dto);
        Task<int> Update(int id, UpsertTodoDTO dto);
        Task<int> Delete(int id);
    }
}
