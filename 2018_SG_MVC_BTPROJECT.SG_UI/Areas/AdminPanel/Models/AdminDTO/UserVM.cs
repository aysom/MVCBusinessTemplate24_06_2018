using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _2018_SG_MVC_BTPROJECT.SG_UI.Areas.AdminPanel.Models.AdminDTO
{
    public class UserVM
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}