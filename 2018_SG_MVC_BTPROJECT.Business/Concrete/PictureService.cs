using _2018_SG_MVC_BTPROJECT.Business.Abstract;
using _2018_SG_MVC_BTPROJECT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_SG_MVC_BTPROJECT.Business.Concrete
{
    public class PictureService : IPictureService
    {
        private _2018_SG_MVC_BTPROJECT.Business.UnitOfWork.UnitOfWork _uow = null;

        public PictureService()
        {
            _uow = new _2018_SG_MVC_BTPROJECT.Business.UnitOfWork.UnitOfWork();
        }

        public Picture getPictureDetail(int id)
        {
            return _uow.GetRepository<Picture>().GetAll().FirstOrDefault(x => x.Id == id);
        }
    }
}
