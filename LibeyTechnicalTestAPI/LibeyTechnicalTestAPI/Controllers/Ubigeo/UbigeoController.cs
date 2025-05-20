using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.Ubigeo
{
    [ApiController]
    [Route("[controller]")]
    public class UbigeoController : Controller
    {
        private readonly IUbigeoRepository _repository;
        public UbigeoController(IUbigeoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var rows = _repository.GetAll();
            return Ok(rows);
        }

        [HttpGet]
        [Route("province/{provinceCode}")]
        public IActionResult GetByProvinceCode(string provinceCode)
        {
            var rows = _repository.GetByProvinceCode(provinceCode);
            return Ok(rows);
        }

        [HttpGet]
        [Route("region/{regionCode}")]
        public IActionResult GetByRegionCode(string regionCode)
        {
            var rows = _repository.GetByRegionCode(regionCode);
            return Ok(rows);
        }
    }
}
