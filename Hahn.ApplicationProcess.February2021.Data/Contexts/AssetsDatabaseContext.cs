using System;
using Microsoft.EntityFrameworkCore;
using Hahn.ApplicationProcess.February2021.Domain.Models;

namespace Hahn.ApplicationProcess.February2021.Data.Contexts
{
    /// <summary>
    /// Assets Database Context
    /// </summary>
    public class AssetsDatabaseContext : DbContext
    {
        /// <summary>
        /// Assets Set
        /// </summary>
        public DbSet<Asset> Assets { get; set; }


        /// <summary>
        /// Database Context Constructor
        /// </summary>
        /// <param name="options">Context options</param>
        public AssetsDatabaseContext(DbContextOptions options):base(options)
        {

        }
    }
}
