using Innovation.DGT.Entities.Common;
using Innovation.DGT.Entities.Response;

namespace Innovation.DGT.DBContext.Repository
{
    public interface IModifications<Entity> where Entity : class, IEntity
    {
        BaseResponse Create(Entity entity);


        BaseResponse Update(Entity entity);

         BaseResponse CreateUpdate(Entity entity);


        BaseResponse Delete(int id);
    }
}