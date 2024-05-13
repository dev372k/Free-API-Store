using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Entities
{
    public class Todo : Base
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public enPriotity Priority { get; set; }
        public DateTime Expiry { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
