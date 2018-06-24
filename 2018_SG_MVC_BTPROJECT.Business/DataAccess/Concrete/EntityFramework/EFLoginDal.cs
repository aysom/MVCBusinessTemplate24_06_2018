
using _2018_SG_MVC_BTPROJECT.Business.DataAccess.Abstract;
using _2018_SG_MVC_BTPROJECT.Business.UnitOfWork;
using _2018_SG_MVC_BTPROJECT.Entities; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_SG_MVC_BTPROJECT.Business.DataAccess.Concrete.EntityFramework
{
    public class EFLoginDal:ILoginDal
    {
        private IUnitOfWork _unitOfWork=null;

        public EFLoginDal()
        {
            _unitOfWork = new UnitOfWork();
        }

        public bool LoginControl(User gelenuser)
        { 
            bool logincontrol = _unitOfWork.GetRepository<User>().Any(x => x.Email == gelenuser.Email && x.Password == gelenuser.Password);
            return logincontrol; 
        }
    }
}
