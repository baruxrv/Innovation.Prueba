using System;

namespace Innovation.DGT.Entities.Common
{
    public class BaseEntity : IEntity, IAudit
    {
        public BaseEntity()
        {
        }

        public BaseEntity(int id)
        {
            this.Id = id;

        }

        public BaseEntity(int id, int createUser, DateTime createDate, int updateUser, DateTime updateDate)
        {
            this.Id = id;
            this.CreateUser = createUser;
            this.CreateDate = createDate;
            this.UpdateUser = updateUser;
            this.UpdateDate = updateDate;

        }
        public int Id { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int UpdateUser { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}