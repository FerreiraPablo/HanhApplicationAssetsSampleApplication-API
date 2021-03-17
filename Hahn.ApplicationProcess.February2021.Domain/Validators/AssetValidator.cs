using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentValidation;
using Hahn.ApplicationProcess.February2021.Domain.Interfaces;
using Hahn.ApplicationProcess.February2021.Domain.Models;

namespace Hahn.ApplicationProcess.February2021.Domain.Validators
{
    /// <summary>
    /// Asset Validator
    /// </summary>
    public class AssetValidator : AbstractValidator<Asset>
    {
        private readonly ICountryRepository _countryRepository;

        /// <summary>
        /// AssetValidator constructor
        /// </summary>
        /// <param name="countryRepository">A country repository for country naming validation.</param>
        public AssetValidator(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
            DefineRules();
        }

        private void DefineRules()
        {
            RuleFor(x => x.AssetName).Length(5, 150);
            RuleFor(x => x.Department).IsInEnum();
            RuleFor(x => x.PurchaseDate).LessThan(DateTime.UtcNow.AddYears(1));
            RuleFor(x => x.Broken).NotNull();
            RuleFor(x => x.EmailAddressOfDepartment).EmailAddress();
            RuleFor(x => x.CountryOfDepartment).Must(BeAValidCountry).WithMessage("Please specify a valid country");
        }

        /// <summary>
        /// Checks if the specified country exists.
        /// </summary>
        /// <param name="countryName">Name of the country</param>
        /// <returns>A boolean value about the existence of the country</returns>
        private bool BeAValidCountry(string countryName)
        {
            return _countryRepository.GetCountryByExactName(countryName).Result != null;
        }
    }
}
