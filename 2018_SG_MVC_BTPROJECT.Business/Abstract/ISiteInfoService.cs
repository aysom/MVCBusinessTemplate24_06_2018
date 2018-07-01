using _2018_SG_MVC_BTPROJECT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_SG_MVC_BTPROJECT.Business.Abstract
{
    public interface ISiteInfoService
    {
        SiteInfo getSiteInfoDetail(int id);
    }
}
