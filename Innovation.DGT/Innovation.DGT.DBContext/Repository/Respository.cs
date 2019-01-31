using System;
using Microsoft.EntityFrameworkCore;
using Innovation.DGT.Entities.Common;
using Innovation.DGT.Entities.Response;

namespace Innovation.DGT.DBContext.Repository
{
    public abstract class Repository<Entity> : IRepository<Entity> where Entity : class, IEntity  , IAudit
    {

        DgtDbContext _DgtDbContext;

        public DgtDbContext DgtDbContext { get{ return _DgtDbContext;} set{_DgtDbContext = value;}}

       

        public Repository()
        {
            _DgtDbContext = new DgtDbContext();
        }

        public virtual BaseResponse Create(Entity entity)
        {
            BaseResponse response = new BaseResponse();

            try
            {

                _DgtDbContext.Set<Entity>().Add(entity);
                _DgtDbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Errors.Add(new Error() { Code = "1", Description = ex.Message });

            }


            return response;


        }
        public virtual BaseResponse Delete(int id)
        {
            BaseResponse response = new BaseResponse();

            try
            {



            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Errors.Add(new Error() { Code = "1", Description = ex.Message });

            }


            return response;


        }

        public virtual BaseResponse Update(Entity entity)
        {

            BaseResponse response = new BaseResponse();

            try
            {

                _DgtDbContext.Set<Entity>().Update(entity);
                _DgtDbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Errors.Add(new Error() { Code = "1", Description = ex.Message });

            }


            return response;


        }

        public virtual BaseListResponse<Entity> Get()
        {
            BaseListResponse<Entity> response = new BaseListResponse<Entity>();
            try
            {
                var list = _DgtDbContext.Set<Entity>()
                     .AsNoTracking();
                    response.List = list.ToListAsync().Result;

            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Errors.Add(new Error() { Code = "1", Description = ex.Message });

            }
            return response;

        }
        public virtual BaseItemResponse<Entity> GetById(int id)
        {
            BaseItemResponse<Entity> response = new BaseItemResponse<Entity>();
            try
            {

                var item = _DgtDbContext.Set<Entity>()
                     .AsNoTracking()
                     .FirstOrDefaultAsync(e => e.Id == id);

                response.Item = item.Result;

            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Errors.Add(new Error() { Code = "1", Description = ex.Message });

            }
            return response;

        }

        public abstract BaseResponse CreateUpdate(Entity entity);
        
    }
}