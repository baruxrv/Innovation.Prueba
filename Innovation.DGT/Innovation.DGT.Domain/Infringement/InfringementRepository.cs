using Innovation.DGT.DBContext.Entities;
using Innovation.DGT.DBContext.Repository;
using Innovation.DGT.Entities.Response;
using Innovation.DGT.Entities.Request;
using Innovation.DGT.Entities.Common;
using System.Linq;

namespace Innovation.DGT.Domain
{
    public class InfringementRepository : Repository<Infringement>
    {
        public override BaseListResponse<Infringement> Get()
        {
            return base.Get();
        }

        public override BaseResponse Create(Infringement entity)
        {
            return base.Create(entity);
        }

        public override BaseResponse Update(Infringement entity)
        {
            return base.Update(entity);
        }

        public override BaseResponse Delete(int id)
        {
            return base.Delete(id);
        }

        public override BaseResponse CreateUpdate(Infringement entity)
        {
            BaseResponse response = new BaseResponse();
            if (DgtDbContext.Infringement.Where(x => x.Id == entity.Id).Count() > 0)
                response = Update(entity);
            else
                response = Create(entity);

            return response;
        }

      
    }
}