using Innovation.DGT.DBContext.Entities;
using Innovation.DGT.DBContext.Repository;
using Innovation.DGT.Entities.Response;
using Innovation.DGT.Entities.Common;
using System.Linq;

namespace Innovation.DGT.Domain
{
    public class VehicleRepository : Repository<Vehicle>, IVehicle
    {
        public override BaseListResponse<Vehicle> Get()
        {
            return base.Get();
        }

        public override BaseResponse Create(Vehicle entity)
        {
            return base.Create(entity);
        }

        public override BaseResponse Update(Vehicle entity)
        {
            return base.Update(entity);
        }

        public override BaseResponse Delete(int id)
        {
            return base.Delete(id);
        }

        public override BaseResponse CreateUpdate(Vehicle entity)
        {
            BaseResponse response = new BaseResponse();
            if (DgtDbContext.Vehicle.Where(x => x.Registration == entity.Registration).Count() > 0)
                response = Update(entity);
            else
                response = Create(entity);

            return response;
        }

      
    }
}