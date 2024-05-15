using Shared;

namespace Application.DTOs
{
    public class GetTodoDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Priority { get; set; }
        public DateTime Expiry { get; set; }
        public bool IsExpired { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int UserId { get; set; }
    }

    public class GetTodoDTOs
    {
        public List<GetTodoDTO> Todos { get; set; }
        public int TotalCount { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
    }

        public class UpsertTodoDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public enPriotity Priority { get; set; }
        public DateTime Expiry { get; set; }
    }
}
