using System.Collections.Generic;
using Innovation.DGT.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Innovation.DGT.DBContext.Entities
{
    public class Infringement : BaseEntity
    {
        public Infringement()
        {
            this.InfringementDriverVehicle = new HashSet<InfringementDriverVehicle>();
        }

        public Infringement(int id, string description, short points) : base(id)
        {
            this.Description = description;
            this.Points = points;
            this.InfringementDriverVehicle = new HashSet<InfringementDriverVehicle>();

        }
        [Required]
        public string Description { get; set; }

        [Required]
        public short Points { get; set; }

        public virtual ICollection<InfringementDriverVehicle> InfringementDriverVehicle { get; set; }

    }
}