using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_SG_MVC_BTPROJECT.Entities
{
    public class Picture:BaseEntity
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public int CatId { get; set; } 
        [ForeignKey("CatId")]
        public virtual Category Category { get; set; }
        public int isShowHomePage { get; set; } 
    }
}
