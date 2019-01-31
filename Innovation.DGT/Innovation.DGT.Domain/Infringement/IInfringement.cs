using Innovation.DGT.DBContext.Entities;
using Innovation.DGT.Entities.Request;
using Innovation.DGT.Entities.Response;

namespace Innovation.DGT.Domain
{
    public interface IInfringement
    {
        BaseListResponse<InfringementDriverHistorical> GetInfrigimentByDriver(int idDriver);

        BaseListResponse<Infringement> GetInfrigimentTopPopular(int top);

         BaseResponse CreateInfringementVehicle(InfringementVehicleRequest request);
    }
}