using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.February2021.Domain.BusinessLogic;
using Hahn.ApplicationProcess.February2021.Domain.BusinessLogic.Assets.Exceptions;
using Hahn.ApplicationProcess.February2021.Domain.Interfaces;
using Hahn.ApplicationProcess.February2021.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hahn.ApplicationProcess.February2021.Web.Controllers
{
    /// <summary>
    /// Asset API Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AssetsController : ControllerBase
    {
        private readonly IAssetsLogic _assetsLogic;
        private readonly IAssetRepository _assetRepository;

        /// <summary>
        /// Constructor of the Asset Controller
        /// </summary>
        /// <param name="assetsLogic">The asset logic implementation to be used.</param>
        /// <param name="assetRepository">The asset repository to be used.</param>
        public AssetsController(IAssetsLogic assetsLogic, IAssetRepository assetRepository)
        {
            _assetsLogic = assetsLogic;
            _assetRepository = assetRepository;
        }

        /// <summary>
        /// Return all the assets or the specific ones where the criterias match.
        /// </summary>
        /// <param name="criteria">Search criteria</param>
        /// <param name="name">Name of he asset</param>
        /// <param name="department">Department</param>
        /// <param name="departmentCountry">Deparment Country</param>
        /// <param name="departmentEmail">Deparment Email</param>
        /// <param name="purchaseDate">Purchase Date</param>
        /// <param name="broken">Is Broken?</param>
        /// <returns>A collection of assets based on the parameters or all the items.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Asset>))]
        public IActionResult Get(string criteria = null, string name = null, Department? department = null, string departmentCountry = null, string departmentEmail = null, DateTime? purchaseDate = null, bool? broken = null)
        {
            return Ok(_assetRepository.All(x =>
                (name == null || x.AssetName.ToUpper().Contains(name.ToUpper()))
                && (department == null || x.Department == department)
                && (department == null || x.CountryOfDepartment.ToUpper().Contains(departmentCountry.ToUpper()))
                && (departmentEmail == null || x.EmailAddressOfDepartment.ToUpper().Contains(departmentEmail.ToUpper()))
                // Maybe this is imposible, but well there it is... Can be fun.
                && (purchaseDate == null || x.PurchaseDate == purchaseDate)
                && (broken == null || x.Broken == broken)
                && (criteria == null || (x.AssetName + x.CountryOfDepartment + x.EmailAddressOfDepartment).ToUpper().Contains(criteria.ToUpper()))
            ));
        }

        /// <summary>
        /// Returns the asset with the specified id.
        /// </summary>
        /// <param name="id">Identity of the asset</param>
        /// <returns>The asset if exists</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Asset))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var asset = await _assetRepository.Get(id);
            if(asset != null)
            {
                return Ok(asset);
            } else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Creates an asset
        /// </summary>
        /// <param name="asset">The asset to be created</param>
        /// <returns>The created asset</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Asset))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(Asset asset)
        {
            try
            {
                var createdAsset = await _assetsLogic.ValidateAndCreate(asset);
                return CreatedAtAction(nameof(GetById), new { id = createdAsset.Id }, createdAsset);
            } catch(AssetValidationException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Updates an asset by it's id
        /// </summary>
        /// <param name="id">Id of the asset to be updated</param>
        /// <param name="asset">The asset to be updated</param>
        /// <returns>An update confirmation success</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Asset asset)
        {
            if (id != asset.Id)
            {
                return BadRequest();
            }

            var existingAsset = await _assetRepository.Get(id);
            if (existingAsset == null)
            {
                return NotFound();
            }

           
            try
            {
                var updatedAsset = await _assetsLogic.ValidateAndUpdate(asset);
                return NoContent();
            }
            catch (AssetValidationException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Delete the asset with the specified id.
        /// </summary>
        /// <param name="id">Id of the asset to be deleted</param>
        /// <returns>A delete confirmation successs</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var existingAsset = await _assetRepository.Get(id);
            if (existingAsset == null)
            {
                return NotFound();
            }

            await _assetRepository.Delete(id);
            return NoContent();
        }
    }
}
