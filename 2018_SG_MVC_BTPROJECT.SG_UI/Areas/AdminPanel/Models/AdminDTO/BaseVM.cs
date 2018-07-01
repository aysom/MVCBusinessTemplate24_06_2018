using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _2018_SG_MVC_BTPROJECT.SG_UI.Areas.AdminPanel.Models.AdminDTO
{
    public class BaseVM
    {
       

        private bool _IsDeleted = false;
        public bool IsDeleted
        {
            get { return _IsDeleted; }
            set { _IsDeleted = value; }
        }
        [DataType(DataType.Date)]
        private DateTime? _CreatedDate = DateTime.Now;
        public DateTime? CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = DateTime.UtcNow; }
        }
    }
}