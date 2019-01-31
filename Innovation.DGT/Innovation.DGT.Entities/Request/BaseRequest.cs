using Innovation.DGT.Entities.Common;
using System;

namespace Innovation.DGT.Entities.Request
{
    public class BaseRequest : IAudit
    {
        public BaseRequest()
        {
        }


        public BaseRequest(string ip, int createUser, DateTime createDate, int updateUser, DateTime updateDate)
        {
            this.Ip = ip;
            this.CreateUser = createUser;
            this.CreateDate = createDate;
            this.UpdateUser = updateUser;
            this.UpdateDate = updateDate;

        }
        public string Ip { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int UpdateUser { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}