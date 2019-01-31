using Innovation.DGT.Entities.Common;

namespace Innovation.DGT.DBContext.Entities
{
    public class InfringementDriverVehicle : BaseEntity
    {
        public InfringementDriverVehicle()
        {
        }

        public int InfringementId{get;set;}
        public int DriverVehicleId{get;set;}

        public virtual Infringement Infringement{get;set;}

        public virtual DriverVehicle DriverVehicle{get;set;}
    }
}