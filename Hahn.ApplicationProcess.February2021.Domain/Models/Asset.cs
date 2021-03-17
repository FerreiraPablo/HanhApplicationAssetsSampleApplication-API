using System;

namespace Hahn.ApplicationProcess.February2021.Domain.Models
{
    /// <summary>
    /// Asset Entity Model
    /// (Some of the comments are just based on doubts just for this coding sample. I will never comment any objection to an specification in a real project.)
    /// </summary>
    public class Asset
    {
        /// <summary>
        /// Asset Identity
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the asset
        /// (Asset in the property name is redundant based on the class name, but that's the specification.)
        /// </summary>
        public string AssetName { get; set; }

        /// <summary>
        /// Asset Department
        /// </summary>
        public Department Department { get; set; }

        /// <summary>
        /// Asset Department Country
        /// </summary>
        public string CountryOfDepartment { get; set; }

        /// <summary>
        /// Asset Department Email Address
        /// (This one and the previous property look like shared values of the actual department, the deparment entity should be independent, but this is the specification.)
        /// </summary>
        public string EmailAddressOfDepartment { get; set; }

        /// <summary>
        /// Asset Purchase Date
        /// </summary>
        public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Asset Is Broken (The C#/dotnet naming standard adds the "Is" Prefix to Booleans, but this is the specification)
        /// </summary>
        public bool Broken { get; set; } = false;

    }
}
