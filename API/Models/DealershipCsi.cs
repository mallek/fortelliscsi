using System;

namespace API.Models
{
    public class DealershipCsi
    {
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string RegionId { get; set; }
        public float Score { get; set; }
        public int NumberOfSurveys { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string Department { get; set; }
        public DateTime CsiDateTime => new DateTime(this.Year, this.Month, 1);
    }
}