using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_SG_MVC_BTPROJECT.Business.Concrete
{
    public class ServiceProvider
    {
        public ServiceProvider()
        {

        }

        private _2018_SG_MVC_BTPROJECT.Business.UnitOfWork.UnitOfWork _uow = null;
        public _2018_SG_MVC_BTPROJECT.Business.UnitOfWork.UnitOfWork unitDondur()
        {
            _uow = new _2018_SG_MVC_BTPROJECT.Business.UnitOfWork.UnitOfWork();
            return _uow;
        }

        ////Bunu controllerda new liycek
        //private CategoryService _categoryService;
        //public CategoryService categoryService()
        //{
        //    if (_categoryService == null)
        //    {
        //        _categoryService = new CategoryService();
        //    }
        //    return _categoryService;
        //}
    }
}
