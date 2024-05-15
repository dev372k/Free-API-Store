namespace Application.DTOs
{
    public class GetCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
    }

    public class GetCategoryDTOs
    {
        public List<GetCategoryDTO> Categories { get; set; }
        public int TotalCount { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
    }
        public class AddCategoryDTO
    {
        public string Name { get; set; } = string.Empty;
    }

    public class UpdateCategoryDTO
    {
        public string Name { get; set; } = string.Empty;
    }
}
