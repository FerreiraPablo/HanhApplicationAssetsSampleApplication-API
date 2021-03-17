using System.Collections.Generic;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.February2021.Domain.Models;

namespace Hahn.ApplicationProcess.February2021.Domain.Interfaces
{
    public interface ICountryRepository
    {
        /// <summary>
        /// Returns a country by its exact name.
        /// </summary>
        /// <param name="name">The name of the country</param>
        /// <returns>The country</returns>
        Task<Country> GetCountryByExactName(string name);

        /// <summary>
        /// Returns all the countries with a name similar to the specified one.
        /// </summary>
        /// <param name="name">The name of the country</param>
        /// <returns>A collection of countries</returns>
        Task<IEnumerable<Country>> GetCountriesByName(string name);
    }
}