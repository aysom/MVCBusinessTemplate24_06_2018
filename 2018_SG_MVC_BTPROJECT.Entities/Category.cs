using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_SG_MVC_BTPROJECT.Entities
{
    public class Category:BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual List<Picture> Pictures { get; set; }
        public int TopCatId { get; set; }
        public string Description { get; set; }
        public string CatImage { get; set; }
        public string ServiceDescription { get; set; }
    }
}
