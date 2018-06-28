using _2018_SG_MVC_BTPROJECT.Business.Abstract;
using _2018_SG_MVC_BTPROJECT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_SG_MVC_BTPROJECT.Business.Concrete
{
    public class SliderService:ISliderService
    {

        private _2018_SG_MVC_BTPROJECT.Business.UnitOfWork.UnitOfWork _uow = null;
        public SliderService()
        {
            _uow = new _2018_SG_MVC_BTPROJECT.Business.UnitOfWork.UnitOfWork();
        }

        public Slider getSliderDetail(int id)
        {
            return _uow.GetRepository<Slider>().GetAll().FirstOrDefault(x => x.Id == id);
        }
    }
}
