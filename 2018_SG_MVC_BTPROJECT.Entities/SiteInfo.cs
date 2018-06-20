using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_SG_MVC_BTPROJECT.Entities
{
    public class SiteInfo:BaseEntity
    {
        public int Id { get; set; }
        public string SiteUrl { get; set; }
        public string CompanyName { get; set; }
        public string SiteName { get; set; }
        public string MetaTag { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string Youtube { get; set; }
        public string SiteDesignAgency { get; set; }
        public string SiteMap { get; set; }
        public string Logo { get; set; }
        public string AboutText { get; set; }
        public string VisionText { get; set; }
        public string MissionText { get; set; }
        public string Service { get; set; }

    }
}
