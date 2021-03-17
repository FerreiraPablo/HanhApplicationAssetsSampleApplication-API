using System;
using Microsoft.EntityFrameworkCore;
using Hahn.ApplicationProcess.February2021.Domain.Models;

namespace Hahn.ApplicationProcess.February2021.Data.Contexts
{
    public class AssetsDatabaseContext : DbContext
    {
        public DbSet<Asset> Assets { get; set; }

        public AssetsDatabaseContext(DbContextOptions options):base(options)
        {

        }
    }
}
