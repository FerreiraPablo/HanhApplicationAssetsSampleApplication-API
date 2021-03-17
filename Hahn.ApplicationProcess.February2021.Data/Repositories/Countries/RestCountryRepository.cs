using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.February2021.Domain.Interfaces;
using Hahn.ApplicationProcess.February2021.Domain.Models;

namespace Hahn.ApplicationProcess.February2021.Data.Repositories.Countries
{
    public class RestCountryRepository : ICountryRepository
    {
        private readonly HttpClient _client;

        public RestCountryRepository()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://restcountries.eu")
            };
        }

        /// <summary>
        /// Returns a country by its exact name.
        /// </summary>
        /// <param name="name">The name of the country</param>
        /// <returns>The country</returns>
        public async Task<Country> GetCountryByExactName(string name)
        {
            var result = await _client.GetAsync($"/rest/v2/name/{name}?fullText=true");
            if (result.IsSuccessStatusCode)
            {
                var countries = await result.Content.ReadFromJsonAsync<Country[]>();
                return countries[0];
            }

            return null;
        }

        /// <summary>
        /// Returns all the countries with a name similar to the specified one.
        /// </summary>
        /// <param name="name">The name of the country</param>
        /// <returns>A collection of countries</returns>
        public async Task<IEnumerable<Country>> GetCountriesByName(string name)
        {
            var result = await _client.GetAsync($"/rest/v2/name/{name}");
            if (result.IsSuccessStatusCode)
            {
                var countries = await result.Content.ReadFromJsonAsync<Country[]>();
                return countries;
            } 
            return new Country[] { };
        }
    }
}
