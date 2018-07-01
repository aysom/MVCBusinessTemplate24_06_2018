using _2018_SG_MVC_BTPROJECT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2018_SG_MVC_BTPROJECT.SG_UI.Areas.AdminPanel.Models.AdminDTO
{
    public class PictureVM
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public Category category { get; set; }
        public int CatId { get; set; }
        public string catName { get; set; }
        public IEnumerable<SelectListItem> drpcategories { get; set; }

    }
}