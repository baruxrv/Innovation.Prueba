using System;
using Innovation.DGT.Entities.Common;

namespace Innovation.DGT.Entities.Response
{
    public class InfringementDriverHistorical
    {
        public string Description { get; set; }
        public short Id { get; set; }

        public string VehicleRegistration { get; set; }

        public string DriverDni { get; set; }

        public string DriverName { get; set; }

        public DateTime InfringamentDate { get; set; }

    }
}