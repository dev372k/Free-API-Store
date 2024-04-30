using Shared;

namespace Application.DTOs
{
    public class GetAPIDTOs
    {
        public string GroupBy { get; set; } = string.Empty;
        public List<APIDTO> APIDTOs { get; set; }
    }

    public class APIDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string UniqueName { get; set; } = string.Empty;
        public string Endpoint { get; set; } = string.Empty;
        public string Request { get; set; } = string.Empty;
        public string Response { get; set; } = string.Empty;
        public enMethodType Method { get; set; }
    }
}
