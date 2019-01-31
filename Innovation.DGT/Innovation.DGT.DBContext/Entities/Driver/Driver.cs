using System.Collections.Generic;
using Innovation.DGT.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Innovation.DGT.DBContext.Entities
{
    public class Driver : BaseEntity
    {
        public Driver()
        {
            this.DriverVehicle = new HashSet<DriverVehicle>();
        }


        public Driver(int id, string dni, string name, string surnames, short points) : base(id)
        {
            this.Dni = dni;
            this.Name = name;
            this.Surnames = surnames;
            this.Points = points;
            this.DriverVehicle = new HashSet<DriverVehicle>();

        }

        [Required]
        public string Dni { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surnames { get; set; }
        [Required]
        public short Points { get; set; }

        public virtual ICollection<DriverVehicle> DriverVehicle { get; set; }
    }
}