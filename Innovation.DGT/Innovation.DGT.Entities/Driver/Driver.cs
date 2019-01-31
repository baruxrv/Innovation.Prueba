using System.Collections.Generic;
using Innovation.DGT.Entities.Common;




namespace Innovation.DGT.Entities
{
    public class Driver : BaseEntity
    {
        public Driver()
        {
            
        }


        public Driver(int id, string dni, string name, string surnames, short points) : base(id)
        {
            this.Dni = dni;
            this.Name = name;
            this.Surnames = surnames;
            this.Points = points;
        }

        public string Dni { get; set; }
        public string Name { get; set; }
        public string Surnames { get; set; }
        public short Points { get; set; }

    }
}