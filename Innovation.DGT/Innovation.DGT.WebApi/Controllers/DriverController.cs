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
    public class DriverController : ControllerBase
    {

        private readonly IDriver _driver;
        private readonly IModifications<Innovation.DGT.DBContext.Entities.Driver> _modificationDriver;

        private readonly IGet<Innovation.DGT.DBContext.Entities.Driver> _getDriver;

        private readonly IMapper _mapper;

        public DriverController(IMapper mapper, IDriver driver, IModifications<Innovation.DGT.DBContext.Entities.Driver> modificationDriver, IGet<Innovation.DGT.DBContext.Entities.Driver> getDriver)
        {
            this._getDriver = getDriver;
            this._driver = driver;
            this._modificationDriver = modificationDriver;
            this._mapper = mapper;
        }



        // GET api/driver
        [HttpGet()]
        public ActionResult<BaseListResponse<Innovation.DGT.Entities.Driver>> GetDriver()
        {

            BaseListResponse<Innovation.DGT.Entities.Driver> response = new BaseListResponse<Innovation.DGT.Entities.Driver>();
            var driverResponseContext = _getDriver.Get();
            response.List = _mapper.Map<List<Innovation.DGT.Entities.Driver>>(driverResponseContext.List);
            response.Success = driverResponseContext.Success;
            response.Errors = driverResponseContext.Errors;

            return response;
        }


        // GET api/driver
        [HttpGet("{dni}")]
        public ActionResult<BaseItemResponse<Innovation.DGT.Entities.Driver>> GetDriverByDni(string dni)
        {
            BaseItemResponse<Innovation.DGT.Entities.Driver> response = new BaseItemResponse<Innovation.DGT.Entities.Driver>();
            var driverResponseContext = _driver.GetDriverByDni(dni);
            response.Item = _mapper.Map<Innovation.DGT.Entities.Driver>(driverResponseContext.Item);
            response.Success = driverResponseContext.Success;
            response.Errors = driverResponseContext.Errors;


            return response;
        }


        // GET api/driver
        [HttpGet("top/{top}")]
        public ActionResult<BaseListResponse<Innovation.DGT.Entities.Driver>> GetDriversTop(int top)
        {
            BaseListResponse<Innovation.DGT.Entities.Driver> response = new BaseListResponse<Innovation.DGT.Entities.Driver>();
            var driverResponseContext = _driver.GetDriversTop(top);
            response.List = _mapper.Map<List<Innovation.DGT.Entities.Driver>>(driverResponseContext.List);
            response.Success = driverResponseContext.Success;
            response.Errors = driverResponseContext.Errors;


            return response;
        }

        // POST api/driver
        [HttpPost]
        public ActionResult<BaseResponse> Add([FromBody] Innovation.DGT.Entities.Driver driver)
        {
            var driverContext = _mapper.Map<Innovation.DGT.DBContext.Entities.Driver>(driver);
            return _modificationDriver.Create(driverContext);
        }

    }
}
