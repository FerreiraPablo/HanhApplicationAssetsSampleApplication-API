using System.Threading.Tasks;
using Hahn.ApplicationProcess.February2021.Domain.Models;

namespace Hahn.ApplicationProcess.February2021.Domain.BusinessLogic
{
    /// <summary>
    /// Asset Logic Contract
    /// </summary>
    public interface IAssetsLogic
    {
        /// <summary>
        /// Validates and creates the specified asset
        /// </summary>
        /// <param name="asset">The asset to be created</param>
        /// <returns>The created asset</returns>
        Task<Asset> ValidateAndCreate(Asset asset);

        /// <summary>
        /// Validates and creates the specified asset
        /// </summary>
        /// <param name="asset">The asset to be updated</param>
        /// <returns>The updated asset</returns>
        Task<Asset> ValidateAndUpdate(Asset asset);
    }
}