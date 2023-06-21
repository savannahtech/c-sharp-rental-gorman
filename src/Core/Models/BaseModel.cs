using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class BaseModel
    {
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set;}
    }
}
