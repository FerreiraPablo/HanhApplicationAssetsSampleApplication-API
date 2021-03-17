using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.February2021.Domain.Models;

namespace Hahn.ApplicationProcess.February2021.Domain.Interfaces
{
    public interface IAssetRepository
    {
        /// <summary>
        /// Returns an specific asset by it's identity.
        /// </summary>
        /// <param name="id">The asset identity</param>
        /// <returns>The specified asset</returns>
        IEnumerable<Asset> All(Expression<Func<Asset, bool>> predicate = null);

        /// <summary>
        /// Returns an specific asset by it's identity.
        /// </summary>
        /// <param name="id">The asset identity</param>
        /// <returns>The specified asset</returns>
        Task<Asset> Create(Asset asset);


        /// <summary>
        /// Creates an asset
        /// </summary>
        /// <param name="asset">The asset to be created</param>
        /// <returns>The created asset</returns>
        Task<Asset> Delete(int id);


        /// <summary>
        /// Deletes an asset by it's identity
        /// </summary>
        /// <param name="id">The asset identity</param>
        /// <returns>The deleted asset</returns>
        Task<Asset> Get(int id);

        /// <summary>
        /// Updates an asset
        /// </summary>
        /// <param name="asset">The asset to be updated</param>
        /// <returns>The updated asset</returns>
        Task<Asset> Update(Asset asset);
    }
}