using Innovation.DGT.Entities.Response;
using Innovation.DGT.DBContext.Entities;

namespace Innovation.DGT.Domain
{
    public interface IDriver
    {
        BaseListResponse<Driver> GetDriversTop(int top);

        BaseItemResponse<Driver> GetDriverByDni(string dni);
    }
}