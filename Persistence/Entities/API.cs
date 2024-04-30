using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Entities
{
    public class API : Base
    {
        public string Name { get; set; } = string.Empty;
        public string UniqueName { get; set; } = string.Empty;
        public string Endpoint { get; set; } = string.Empty;
        public string Request { get; set; } = string.Empty;
        public string Response { get; set; } = string.Empty;
        public enMethodType Method { get; set; }
        public string GroupBy { get; set; } = string.Empty;
    }
}
