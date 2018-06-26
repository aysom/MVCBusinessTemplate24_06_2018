using _2018_SG_MVC_BTPROJECT.Business.Abstract;
using _2018_SG_MVC_BTPROJECT.Business.Concrete;
using _2018_SG_MVC_BTPROJECT.Business.UnitOfWork;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace _2018_SG_MVC_BTPROJECT.Business.Properties
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel _ninjectKernel;

        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddBllBindings();
        }

        private void AddBllBindings()
        {
            _ninjectKernel.Bind<IUnitOfWork>().To<UnitOfWork.UnitOfWork>();
            _ninjectKernel.Bind<ILoginService>().To<LoginService>();
            _ninjectKernel.Bind<ICategoryService>().To<CategoryService>();
            
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)
                  _ninjectKernel.Get(controllerType);
        }

    }
}
