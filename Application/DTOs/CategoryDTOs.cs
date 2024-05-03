namespace Application.DTOs
{
    public class GetCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
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
