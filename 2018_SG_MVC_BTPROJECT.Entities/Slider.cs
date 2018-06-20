using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_SG_MVC_BTPROJECT.Entities
{
    public class Slider:BaseEntity
    { 
        public int Id { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
