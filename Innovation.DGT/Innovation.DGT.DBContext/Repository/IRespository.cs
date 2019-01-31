
using Innovation.DGT.Entities.Common;


namespace Innovation.DGT.DBContext.Repository
{
    public interface IRepository<Entity> : IModifications<Entity>, IGet<Entity> where Entity : class, IEntity , IAudit
    {
        DgtDbContext DgtDbContext {get;set;}
       
    }
}