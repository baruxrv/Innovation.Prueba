using System;

namespace Innovation.DGT.Entities.Common
{
    public interface IAudit
    {
        int CreateUser { get; set; }

        DateTime CreateDate { get; set; }

        int UpdateUser { get; set; }

        DateTime UpdateDate { get; set; }
    }
}