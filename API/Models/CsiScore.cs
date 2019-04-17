using System;

namespace API.Models
{
    public class CsiScore
    {
        public string UserId { get; set; }
        public string CompanyId { get; set; }
        public string PayrollId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float Score { get; set; }
        public DateTime Date { get; set; }

    }
}