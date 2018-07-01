using _2018_SG_MVC_BTPROJECT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2018_SG_MVC_BTPROJECT.SG_UI.Areas.AdminPanel.Models.AdminDTO.PageDTO
{
    public class PictureListVM:BaseVM
    {
        public List<Category> MainCategoryFilter { get; set; }
        public List<PictureVM> AllPictures { get; set; }
    }
}