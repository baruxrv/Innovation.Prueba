using Innovation.DGT.DBContext.Entities;
using Innovation.DGT.DBContext.Repository;
using Innovation.DGT.Entities.Response;
using Innovation.DGT.Entities.Common;
using System.Linq;

namespace Innovation.DGT.Domain
{
    public class DriverRepository : Repository<Driver>, IDriver
    {
        public override BaseListResponse<Driver> Get()
        {
            return base.Get();
        }

        public override BaseResponse Create(Driver entity)
        {
            BaseResponse response = new BaseResponse();

            if (DgtDbContext.Driver.Where(x => x.Dni == entity.Dni).Count() > 0)
                response.Errors.Add(new Error() { Code = "Exists", Description = "Error: Exists Driver" });
            else
                response = base.Create(entity);
            return response;
        }

        public override BaseResponse Update(Driver entity)
        {
            return base.Update(entity);
        }

        public override BaseResponse Delete(int id)
        {
            return base.Delete(id);
        }

        public override BaseResponse CreateUpdate(Driver entity)
        {
            BaseResponse response = new BaseResponse();
            if (DgtDbContext.Driver.Where(x => x.Dni == entity.Dni).Count() > 0)
                response = Update(entity);
            else
                response = Create(entity);

            return response;
        }

        public BaseListResponse<Driver> GetDriversTop(int top)
        {
            var driversTop = Get();
            if (driversTop.Success)
            {
                driversTop.List = driversTop.List.Take(top);
            }
            return driversTop;
        }

        public BaseItemResponse<Driver> GetDriverByDni(string dni)
        {

            BaseItemResponse<Driver> response = new BaseItemResponse<Driver>();

            var driversTop = Get();
            if (driversTop.Success)
                response.Item = driversTop.List.Where(x => x.Dni == dni).FirstOrDefault();

            response.Errors = driversTop.Errors;
            response.Success = driversTop.Success;

            return response;
        }
    }
}