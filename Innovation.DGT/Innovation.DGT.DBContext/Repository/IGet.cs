using Innovation.DGT.Entities.Common;
using Innovation.DGT.Entities.Response;

namespace Innovation.DGT.DBContext.Repository
{
    public interface IGet<Entity> where Entity : class, IEntity
    {
        BaseListResponse<Entity> Get();

        BaseItemResponse<Entity> GetById(int id);
    }
}