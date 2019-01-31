using Innovation.DGT.DBContext.Entities;
using Innovation.DGT.DBContext.Repository;
using Innovation.DGT.Entities.Response;
using Innovation.DGT.Entities.Request;
using Innovation.DGT.Entities.Common;
using System.Linq;
using System;

namespace Innovation.DGT.Domain
{
    public class InfringementLogic : IInfringement, IModifications<Infringement>, IGet<Infringement>
    {

        private InfringementRepository _repository;
        public InfringementLogic()
        {
            _repository = new InfringementRepository();
        }



        public BaseResponse Create(Infringement entity)
        {
            return _repository.Create(entity);
        }

        public BaseResponse CreateUpdate(Infringement entity)
        {
            return _repository.CreateUpdate(entity);
        }

        public BaseResponse Delete(int id)
        {
            return _repository.Delete(id);
        }

        public BaseResponse Update(Infringement entity)
        {
            return _repository.Update(entity);
        }

        public BaseListResponse<Infringement> Get()
        {
            return _repository.Get();
        }

        public BaseItemResponse<Infringement> GetById(int id)
        {
            return _repository.GetById(id);
        }

        public BaseListResponse<InfringementDriverHistorical> GetInfrigimentByDriver(int idDriver)
        {
            BaseListResponse<InfringementDriverHistorical> response = new BaseListResponse<InfringementDriverHistorical>();
            var result = from dv in _repository.DgtDbContext.DriverVehicle
                         join idv in _repository.DgtDbContext.InfringementDriverVehicle on dv.Id equals idv.DriverVehicleId
                         join inf in _repository.DgtDbContext.Infringement on idv.InfringementId equals inf.Id
                         join driver in _repository.DgtDbContext.Driver on dv.DriverId equals driver.Id
                         join vehicle in _repository.DgtDbContext.Vehicle on dv.VehicleId equals vehicle.Id
                         where dv.DriverId == idDriver
                         select new InfringementDriverHistorical()
                         {

                             Id = (short)inf.Id,
                             DriverDni = driver.Dni,
                             DriverName = driver.Name + " " + driver.Surnames,
                             Description = inf.Description,
                             VehicleRegistration = vehicle.Registration,
                             InfringamentDate = idv.CreateDate
                         };

            if (result != null)
            {
                response.List = result;

            }
            return response;
        }

        public BaseListResponse<Infringement> GetInfrigimentTopPopular(int top)
        {
            BaseListResponse<Infringement> response = new BaseListResponse<Infringement>();
            var resultCount = from idv in _repository.DgtDbContext.InfringementDriverVehicle
                              group idv by idv.InfringementId into inc
                              select new { InfringementId = inc.Key, count = inc.Count() };

            var result = from inf in _repository.DgtDbContext.Infringement
                         join rc in resultCount.OrderBy(x => x.count) on inf.Id equals rc.InfringementId
                         select inf;


            if (result != null)
            {
                response.List = result.Take(top);

            }
            return response;
        }

        public BaseResponse CreateInfringementVehicle(InfringementVehicleRequest request)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                var DriverVehicle = _repository.DgtDbContext.DriverVehicle.Where(x => x.VehicleId == request.IdVehicle).FirstOrDefault();
                if (DriverVehicle != null)
                {
                    _repository.DgtDbContext.InfringementDriverVehicle.Add(new InfringementDriverVehicle()
                    {
                        InfringementId = request.IdInfringement,
                        DriverVehicleId = DriverVehicle.Id,
                        CreateUser = request.CreateUser
                    });

                    _repository.DgtDbContext.SaveChanges();

                    var driverUpdate = _repository.DgtDbContext.Driver.Where(x => x.Id == DriverVehicle.DriverId).FirstOrDefault();
                    var infringiment = _repository.DgtDbContext.Infringement.Where(x => x.Id == request.IdInfringement).FirstOrDefault();
                    driverUpdate.Points = (short)(driverUpdate.Points - infringiment.Points);
                    _repository.DgtDbContext.Driver.Update(driverUpdate);
                    _repository.DgtDbContext.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                response.Errors.Add(new Error() { Code = "DbContextCreate", Description = ex.Message });

            }

            return response;


        }
    }
}