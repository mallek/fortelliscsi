using System;
using System.Collections.Generic;

namespace API.Models
{
    public class AssociateInfo
    {
        public AssociateInfo()
        {
            Scores = new List<CsiScore>();
        }
        public string UserId { get; set; }
        public string CompanyId { get; set; }
        public string PayrollId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<CsiScore> Scores { get; set; }
    }


    public class CsiScore
    {
         public float Score { get; set; }
        public DateTime Date { get; set; }
    }
}