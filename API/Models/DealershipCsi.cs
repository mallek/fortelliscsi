using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class DealershipCsi
    {
        /// <summary>
        /// This is the unique identifier of the company
        /// </summary>
        public string CompanyId { get; set; }

        /// <summary>
        /// This is the name of the company
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// This is the unique identifer of the Region
        /// </summary>
        public string RegionId { get; set; }

        /// <summary>
        /// This is the score for the company or region.
        ///  Also know as: CSI, SSI, MBEP, Customer Experience Index, Survey Quality Index, Net Promoter Score (NPS)
        /// </summary>
        public float Score { get; set; }

        /// <summary>
        /// The number of surveys included in this reporting period
        /// </summary>
        public int NumberOfSurveys { get; set; }

        /// <summary>
        /// The month of the reporting period as an integer
        /// </summary>
        [Range(1, 12, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Month { get; set; }

        /// <summary>
        /// The year of the reporting period as an integer
        /// </summary>
        [Range(1950, 2100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Year { get; set; }

        /// <summary>
        /// The department that the score is for.
        /// EX: Sales, F&amp;I, Parts, Service
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// The date of the reporting period
        /// </summary>
        [ReadOnly(true)]
        public DateTime CsiDateTime => new DateTime(this.Year, this.Month, 1);
    }
}