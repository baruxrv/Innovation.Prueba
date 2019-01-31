using Innovation.DGT.DBContext.Entities;
using Innovation.DGT.DBContext.Repository;
using Innovation.DGT.Entities.Response;

namespace Innovation.DGT.Domain
{
    public class DriverLogic : IDriver, IModifications<Driver> ,IGet<Driver>
    {

        private DriverRepository _repository;
        public DriverLogic()
        {
            _repository = new DriverRepository();
        }


        public BaseListResponse<Driver> GetDriversTop(int top)
        {
            return _repository.GetDriversTop(top);
        }

        public BaseResponse Create(Driver entity)
        {
          return _repository.Create(entity);
        }

        public BaseResponse CreateUpdate(Driver entity)
        {
            return _repository.CreateUpdate(entity);
        }

        public BaseResponse Delete(int id)
        {
            return _repository.Delete(id);
        }

        public BaseResponse Update(Driver entity)
        {
            return _repository.Update(entity);
        }

        public BaseListResponse<Driver> Get()
        {
            return _repository.Get();
        }

        public BaseItemResponse<Driver> GetById(int id)
        {
            return _repository.GetById(id);
        }

        public BaseItemResponse<Driver> GetDriverByDni(string dni)
        {
            return _repository.GetDriverByDni(dni);
        }
    }
}