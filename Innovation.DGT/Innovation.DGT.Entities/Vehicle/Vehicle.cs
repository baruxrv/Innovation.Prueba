using System.Collections.Generic;
using Innovation.DGT.Entities.Common;


namespace Innovation.DGT.Entities
{
    public class Vehicle : BaseEntity
    {
        public Vehicle()
        {

        }


        public Vehicle(int id, string registration, string brand, string model,int idDriver) : base(id)
        {
            this.Registration = registration;
            this.Brand = brand;
            this.Model = model;
            this.IdDriver = idDriver;
        }

        public string Registration { get; set; }


        public string Brand { get; set; }


        public string Model { get; set; }


        public int IdDriver { get; set; }



    }
}