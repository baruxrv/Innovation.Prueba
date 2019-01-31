using System.Collections.Generic;
using Innovation.DGT.Entities.Common;

namespace Innovation.DGT.DBContext.Entities
{
    public class DriverVehicle : BaseEntity
    {
        public DriverVehicle()
        {
            this.InfringementDriverVehicle = new HashSet<InfringementDriverVehicle>();
        }

        public DriverVehicle(int DriverId, int VehicleId)
        {
            this.DriverId = DriverId;
            this.VehicleId = VehicleId;
            this.InfringementDriverVehicle = new HashSet<InfringementDriverVehicle>();

        }
        public int DriverId { get; set; }
        public int VehicleId { get; set; }

        public virtual Driver Driver { get; set; }

        public virtual Vehicle Vehicle { get; set; }

         public virtual ICollection<InfringementDriverVehicle> InfringementDriverVehicle { get; set; }
    }
}