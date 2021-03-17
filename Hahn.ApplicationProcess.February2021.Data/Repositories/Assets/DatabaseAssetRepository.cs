using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.February2021.Data.Contexts;
using Hahn.ApplicationProcess.February2021.Domain.Interfaces;
using Hahn.ApplicationProcess.February2021.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicationProcess.February2021.Data.Repositories.Assets
{
    /// <summary>
    /// Asset repository abstraction for the entity framework database context.
    /// </summary>
    public class DatabaseAssetRepository : IAssetRepository
    {
        private readonly AssetsDatabaseContext _context;

        private IQueryable<Asset> _assets => _context.Assets;


        /// <summary>
        /// Constructor for the repository based on a AssetsDatabaseContext.
        /// </summary>
        /// <param name="context">The AssetsDatabaseContext Instance</param>
        public DatabaseAssetRepository(AssetsDatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns an specific asset by it's identity.
        /// </summary>
        /// <param name="id">The asset identity</param>
        /// <returns>The specified asset</returns>
        public async Task<Asset> Get(int id)
        {
            return await _assets.FirstOrDefaultAsync(x => x.Id == id);
        }


        /// <summary>
        /// Returns an specific asset by it's identity.
        /// </summary>
        /// <param name="id">The asset identity</param>
        /// <returns>The specified asset</returns>
        public IEnumerable<Asset> All(Expression<Func<Asset, bool>> predicate = null)
        {
            return predicate == null ? _assets : _assets.Where(predicate);
        }

        /// <summary>
        /// Creates an asset
        /// </summary>
        /// <param name="asset">The asset to be created</param>
        /// <returns>The created asset</returns>
        public async Task<Asset> Create(Asset asset)
        {
            await _context.AddAsync(asset);
            await _context.SaveChangesAsync();
            return asset;
        }

        /// <summary>
        /// Deletes an asset by it's identity
        /// </summary>
        /// <param name="id">The asset identity</param>
        /// <returns>The deleted asset</returns>
        public async Task<Asset> Delete(int id)
        {
            var asset = await Get(id);
            if (asset != null)
            {
                _context.Remove(asset);
                await _context.SaveChangesAsync();
            }
            return asset;
        }

        /// <summary>
        /// Updates an asset
        /// </summary>
        /// <param name="asset">The asset to be updated</param>
        /// <returns>The updated asset</returns>
        public async Task<Asset> Update(Asset asset)
        {
            var originalAsset = await Get(asset.Id);

            originalAsset.AssetName = asset.AssetName;
            originalAsset.Department = asset.Department;
            originalAsset.CountryOfDepartment = asset.CountryOfDepartment;
            originalAsset.EmailAddressOfDepartment = asset.EmailAddressOfDepartment;
            originalAsset.PurchaseDate = asset.PurchaseDate;
            originalAsset.Broken = asset.Broken;


            _context.Update(originalAsset);
            await _context.SaveChangesAsync();
            return asset;
        }
    }
}
