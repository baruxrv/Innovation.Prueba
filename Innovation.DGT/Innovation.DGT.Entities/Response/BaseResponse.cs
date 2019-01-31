using System.Collections.Generic;
using System.Linq;
using Innovation.DGT.Entities.Common;

namespace Innovation.DGT.Entities.Response
{
    public class BaseResponse
    {

        bool _Success;
        public BaseResponse()
        {
            Errors = new List<Error>();
            Success = true;
        }

        public bool Success
        {
            get
            {
                return Errors.Count() == 0 && _Success;
            }
            set
            {
                _Success = value;
            }
        }

        public List<Error> Errors { get; set; }
    }
}