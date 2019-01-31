using System;

namespace Innovation.DGT.Entities.Request
{
    public class InfringementVehicleRequest : BaseRequest
    {
        public InfringementVehicleRequest()
        {

        }

        public InfringementVehicleRequest(int idInfringement, int IdVehicle)
        {
            this.IdInfringement = idInfringement;
            this.IdVehicle = IdVehicle;

        }

        public InfringementVehicleRequest(string ip, int createUser, DateTime crateDate, int updateUser, DateTime updateDate) : base(ip, createUser, crateDate, updateUser, updateDate)
        {
        }

        public int IdInfringement { get; set; }

        public int IdVehicle { get; set; }
    }
}