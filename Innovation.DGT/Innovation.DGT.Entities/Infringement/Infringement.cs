using System.Collections.Generic;
using Innovation.DGT.Entities.Common;


namespace Innovation.DGT.Entities
{
    public class Infringement : BaseEntity
    {
        public Infringement()
        {
           
        }

        public Infringement(int id,string description, short points): base(id)
        {
            this.Description = description;
            this.Points = points;
           

        }
         
        public string Description { get; set; }

 
        public short Points { get; set; }


       

        

    }
}