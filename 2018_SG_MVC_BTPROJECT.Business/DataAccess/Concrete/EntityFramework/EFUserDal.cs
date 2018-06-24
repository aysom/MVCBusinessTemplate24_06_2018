using _2018_SG_MVC_BTPROJECT.Business.DataAccess.Abstract;
using _2018_SG_MVC_BTPROJECT.Business.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace _2018_SG_MVC_BTPROJECT.Business.DataAccess.Concrete.EntityFramework
{
    public class EFUserDal:IUserDal
    {
        private IUnitOfWork _unitOfWork = null;

        public EFUserDal()
        {
            _unitOfWork = new UnitOfWork();
        }




    }
}
