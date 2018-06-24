using _2018_SG_MVC_BTPROJECT.Business.Abstract;

using _2018_SG_MVC_BTPROJECT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_SG_MVC_BTPROJECT.Business.Concrete
{
    public class LoginService:ILoginService
    {
        private _2018_SG_MVC_BTPROJECT.Business.UnitOfWork.UnitOfWork _uow = null;
         
        public LoginService()
        {
           _uow = new _2018_SG_MVC_BTPROJECT.Business.UnitOfWork.UnitOfWork();
        }
     

        public bool LoginOlduMu(User gelenuser)
        {
            bool logincontrol = _uow.GetRepository<User>().Any(x => x.Email == gelenuser.Email && x.Password == gelenuser.Password);
            return logincontrol;
        } 


         
    }
}
