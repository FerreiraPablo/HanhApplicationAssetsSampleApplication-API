using System;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.February2021.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hahn.ApplicationProcess.February2021.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;

        public CountriesController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            return Ok(await _countryRepository.GetCountriesByName(name));
        }

    }
}
