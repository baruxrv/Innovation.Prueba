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
    public class InfringementController : ControllerBase
    {


        private readonly IInfringement _infringement;

        private readonly IModifications<Innovation.DGT.DBContext.Entities.Infringement> _modificationInfringement;

        private readonly IGet<Innovation.DGT.DBContext.Entities.Infringement> _getInfringement;

        private readonly IMapper _mapper;

        public InfringementController(IInfringement infringement, IMapper mapper, IModifications<Innovation.DGT.DBContext.Entities.Infringement> modificationInfringement, IGet<Innovation.DGT.DBContext.Entities.Infringement> getInfringement)
        {
            this._getInfringement = getInfringement;
            this._modificationInfringement = modificationInfringement;
            this._mapper = mapper;
            this._infringement = infringement;
        }



        // GET api/Infringement
        [HttpGet("driver/{idDriver}")]
        public ActionResult<BaseListResponse<Innovation.DGT.Entities.Response.InfringementDriverHistorical>> GetInfringementByDriver(int idDriver)
        {

            return _infringement.GetInfrigimentByDriver(idDriver);

        }


        // GET api/Infringement/TopPopular
        [HttpGet("TopPopular/{top}")]
        public ActionResult<BaseListResponse<Innovation.DGT.Entities.Infringement>> GetInfrigimentTopPopular(int top)
        {
            BaseListResponse<Innovation.DGT.Entities.Infringement> response = new BaseListResponse<Entities.Infringement>();
            var infContext = _infringement.GetInfrigimentTopPopular(top);
            response.List = _mapper.Map<List<Innovation.DGT.Entities.Infringement>>(infContext.List);
            return response;

        }




        // POST api/Infringement
        [HttpPost]
        public ActionResult<BaseResponse> Add([FromBody] Innovation.DGT.Entities.Infringement Infringement)
        {
            var InfringementContext = _mapper.Map<Innovation.DGT.DBContext.Entities.Infringement>(Infringement);
            return _modificationInfringement.Create(InfringementContext);
        }

        // POST api/InfringementVehicle
        [HttpPost("vehicle")]
        public ActionResult<BaseResponse> AddInfringementVehicle([FromBody] Innovation.DGT.Entities.Request.InfringementVehicleRequest InfringementVehicleRequest)
        {

            return _infringement.CreateInfringementVehicle(InfringementVehicleRequest);
        }

    }
}
