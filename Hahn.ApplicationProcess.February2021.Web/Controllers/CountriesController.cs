using System.Collections.Generic;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.February2021.Domain.Interfaces;
using Hahn.ApplicationProcess.February2021.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hahn.ApplicationProcess.February2021.Web.Controllers
{
    /// <summary>
    /// Countries API Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;

        /// <summary>
        /// Countries Controller Constructor
        /// </summary>
        /// <param name="countryRepository">The country repository to be used.</param>
        public CountriesController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        /// <summary>
        /// Returns a collection of countries with similar names as the provided.
        /// </summary>
        /// <param name="name">The country name</param>
        /// <returns>A country collection</returns>
        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Country>))]
        public async Task<IActionResult> Get(string name)
        {
            return Ok(await _countryRepository.GetCountriesByName(name));
        }

    }
}
