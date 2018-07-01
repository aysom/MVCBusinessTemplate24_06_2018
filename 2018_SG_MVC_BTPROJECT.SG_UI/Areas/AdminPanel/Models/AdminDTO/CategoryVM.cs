using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2018_SG_MVC_BTPROJECT.SG_UI.Areas.AdminPanel.Models.AdminDTO
{
    public class CategoryVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Lütfen Boş Bırakmayınız")]
        [Display(Name = "Ad")]
        public string Name { get; set; }
        public int TopCatId { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        public string CatImage { get; set; }
        [Display(Name = "Açıklama")]
        public string ServiceDescription { get; set; }
        public string TopCatName { get; set; }
        public IEnumerable<SelectListItem> drpcategories { get; set; }
    }
}