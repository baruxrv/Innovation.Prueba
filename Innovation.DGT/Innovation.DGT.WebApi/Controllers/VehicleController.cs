using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Innovation.DGT.DBContext.Entities;
using Innovation.DGT.DBContext.Repository;
using Innovation.DGT.Domain;
using Innovation.DGT.Entities.Response;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Innovation.DGT.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {

        private readonly IModifications<Innovation.DGT.DBContext.Entities.Vehicle> _modificationVehicle;

        private readonly IGet<Innovation.DGT.DBContext.Entities.Vehicle> _getVehicle;

        private readonly IMapper _mapper;

        public VehicleController(IMapper mapper, IModifications<Innovation.DGT.DBContext.Entities.Vehicle> modificationVehicle, IGet<Innovation.DGT.DBContext.Entities.Vehicle> getVehicle)
        {
            this._getVehicle = getVehicle;
            this._modificationVehicle = modificationVehicle;
            this._mapper = mapper;
        }

       

        // POST api/Vehicle
        [HttpPost]
        public ActionResult<BaseResponse> Add([FromBody] Innovation.DGT.Entities.Vehicle vehicle)
        {
            var VehicleContext = _mapper.Map<Innovation.DGT.DBContext.Entities.Vehicle>(vehicle);
            VehicleContext.DriverVehicle.Add(new DriverVehicle(){ DriverId = vehicle.IdDriver, CreateUser = vehicle.CreateUser, CreateDate= vehicle.CreateDate});
            return _modificationVehicle.Create(VehicleContext);
        }

    }
}
