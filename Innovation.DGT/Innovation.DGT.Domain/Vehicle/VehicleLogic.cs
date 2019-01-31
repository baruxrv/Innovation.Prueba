using Innovation.DGT.DBContext.Entities;
using Innovation.DGT.DBContext.Repository;
using Innovation.DGT.Entities.Response;
using Innovation.DGT.Entities.Common;
using System.Linq;
using System;

namespace Innovation.DGT.Domain
{
    public class VehicleLogic : IVehicle, IModifications<Vehicle>, IGet<Vehicle>
    {

        private VehicleRepository _repository;
        public VehicleLogic()
        {
            _repository = new VehicleRepository();
        }



        public BaseResponse Create(Vehicle entity)
        {
            BaseResponse response = new BaseResponse();

            if (_repository.DgtDbContext.Vehicle.Where(x => x.Registration == entity.Registration).Count() > 0)
                response.Errors.Add(new Error() { Code = "ExistEntity", Description = "The Vehicle Exists" });
            if (response.Success)
            {
               
                if (entity.DriverVehicle != null && entity.DriverVehicle.Count() > 0)
                {

                    if (_repository.DgtDbContext.Driver.Where(x => x.Id == entity.DriverVehicle.FirstOrDefault().DriverId).Count() == 0)
                        response.Errors.Add(new Error() { Code = "NoExistEntity", Description = "The Driver No Exists" });

                    if (_repository.DgtDbContext.DriverVehicle.Where(x => x.DriverId == entity.DriverVehicle.FirstOrDefault().DriverId).Count() + 1 > 10)
                        response.Errors.Add(new Error() { Code = "ExistRelation", Description = "Can not assign more vehicles to the driver" });

                    if (response.Success)
                    {
                        response = _repository.Create(entity);
                    }
                }
            }

            return response;
        }

        public BaseResponse CreateUpdate(Vehicle entity)
        {
            return _repository.CreateUpdate(entity);
        }

        public BaseResponse Delete(int id)
        {
            return _repository.Delete(id);
        }

        public BaseResponse Update(Vehicle entity)
        {
            return _repository.Update(entity);
        }

        public BaseListResponse<Vehicle> Get()
        {
            return _repository.Get();
        }

        public BaseItemResponse<Vehicle> GetById(int id)
        {
            return _repository.GetById(id);
        }


    }
}