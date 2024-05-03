using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class GetOrderDTO
    {
        public int Id { get; set; }
        public GetUserDTO User { get; set; }
        public GetProductDTO Product { get; set; }
    }

    public class AddOrderDTO
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }

    public class UpdateOrderDTO
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}
