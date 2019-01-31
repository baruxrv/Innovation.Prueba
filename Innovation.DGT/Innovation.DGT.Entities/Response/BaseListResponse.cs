using System.Collections.Generic;


namespace Innovation.DGT.Entities.Response
{
    public class BaseListResponse<Entity> : BaseResponse
    {
        public BaseListResponse()
        {
            base.Success = true;
            List = new List<Entity>();
        }

        
        public IEnumerable<Entity> List{get;set;}
    }
}