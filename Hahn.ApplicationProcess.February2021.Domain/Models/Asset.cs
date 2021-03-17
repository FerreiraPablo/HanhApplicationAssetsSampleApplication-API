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
        /// <example>Red Hats</example>
        public string AssetName { get; set; }

        /// <summary>
        /// Asset Department
        /// </summary>
        /// <example>0</example>
        public Department Department { get; set; }

        /// <summary>
        /// Asset Department Country
        /// </summary>
        /// <example>Aruba</example>
        public string CountryOfDepartment { get; set; }

        /// <summary>
        /// Asset Department Email Address
        /// (This one and the previous property look like shared values of the actual department, the deparment entity should be independent, but this is the specification.)
        /// </summary>
        /// <example>arubahq@gmail.com</example>
        public string EmailAddressOfDepartment { get; set; }

        /// <summary>
        /// Asset Purchase Date
        /// </summary>
        /// <example>2021-03-17T18:40:41.702Z</example>
        public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Asset Is Broken (The C#/dotnet naming standard adds the "Is" Prefix to Booleans, but this is the specification)
        /// </summary>
        /// <example>false</example>
        public bool Broken { get; set; } = false;

    }
}
