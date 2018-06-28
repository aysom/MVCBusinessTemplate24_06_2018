using _2018_SG_MVC_BTPROJECT.Business.Abstract;
using _2018_SG_MVC_BTPROJECT.Business.Concrete;
using _2018_SG_MVC_BTPROJECT.Business.UnitOfWork;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _2018_SG_MVC_BTPROJECT.SG_UI.Infrastructure
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        private IKernel _ninjectKernel;

        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddAllBindings();
        }

        private void AddAllBindings()
        {
            _ninjectKernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            _ninjectKernel.Bind<ILoginService>().To<LoginService>();
            _ninjectKernel.Bind<ICategoryService>().To<CategoryService>();
            _ninjectKernel.Bind<ISliderService>().To<SliderService>();

        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)
                 _ninjectKernel.Get(controllerType);
        }

    }
}