using _2018_SG_MVC_BTPROJECT.Business.Abstract;
using _2018_SG_MVC_BTPROJECT.DataAccess.Abstract;
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
        private ILoginDal _LoginDal;

        public LoginService(ILoginDal loginDal)
        {
            _LoginDal = loginDal;
        }
         
        public bool LoginOlduMu(User gelenuser)
        {
            if (_LoginDal.LoginControl(gelenuser))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
