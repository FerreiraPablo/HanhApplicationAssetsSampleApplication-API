using System;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Hahn.ApplicationProcess.February2021.Domain.BusinessLogic.Assets.Exceptions;
using Hahn.ApplicationProcess.February2021.Domain.Interfaces;
using Hahn.ApplicationProcess.February2021.Domain.Models;

namespace Hahn.ApplicationProcess.February2021.Domain.BusinessLogic
{
    public class AssetsLogic : IAssetsLogic
    {
        private readonly IAssetRepository _assetRepository;
        private readonly AbstractValidator<Asset> _assetValidator;

        public AssetsLogic(IAssetRepository assetRepository, AbstractValidator<Asset> assetValidator)
        {
            _assetRepository = assetRepository;
            _assetValidator = assetValidator;
        }


        /// <summary>
        /// Validates and creates the specified asset
        /// </summary>
        /// <param name="asset">The asset to be created</param>
        /// <returns>The created asset</returns>
        public async Task<Asset> ValidateAndCreate(Asset asset)
        {
            var validationResult = _assetValidator.Validate(asset);
            if (validationResult.IsValid)
            {
                return await _assetRepository.Create(asset);
            }
            else
            {
                throw new AssetValidationException(validationResult.Errors.First().ErrorMessage);
            }
        }


        /// <summary>
        /// Validates and creates the specified asset
        /// </summary>
        /// <param name="asset">The asset to be updated</param>
        /// <returns>The updated asset</returns>
        public async Task<Asset> ValidateAndUpdate(Asset asset)
        {
            var validationResult = _assetValidator.Validate(asset);
            if (validationResult.IsValid)
            {
                return await _assetRepository.Update(asset);
            }
            else
            {
                throw new AssetValidationException(validationResult.Errors.First().ErrorMessage);
            }
        }
    }
}
