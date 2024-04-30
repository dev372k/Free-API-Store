using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Statics.Models
{
    public class GetAPIs
    {
        public string GroupBy { get; set; } = string.Empty;
        public List<API> APIs { get; set; }
    }

    public class GetAPIDTO
    {
        public List<GetAPIs> GetAPIs { get; set; }
        public API API { get; set; }
    }


    public class API
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
