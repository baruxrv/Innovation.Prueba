using System.Collections.Generic;
using Innovation.DGT.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Innovation.DGT.DBContext.Entities
{
    public class Vehicle : BaseEntity
    {
        public Vehicle()
        {
            this.DriverVehicle = new HashSet<DriverVehicle>();
            
        }


        public Vehicle(int id, string registration, string brand, string model) : base(id)
        {
            this.Registration = registration;
            this.Brand = brand;
            this.Model = model;
            this.DriverVehicle = new HashSet<DriverVehicle>();
            

        }
        [Required]
        public string Registration { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        public virtual ICollection<DriverVehicle> DriverVehicle { get; set; }

    }
}