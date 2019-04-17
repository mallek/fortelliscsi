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

        /// <summary>
        /// This is the unique identifer of the Associate
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// This is the unique identifier of the Company
        /// </summary>
        public string CompanyId { get; set; }

        /// <summary>
        /// This is the unique payroll identifier for the Associate
        /// </summary>
        public string PayrollId { get; set; }

        /// <summary>
        /// This is the Associates First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// This is the Associates Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// This is the list of scores for the associate
        ///  Also know as: CSI, SSI, MBEP, Customer Experience Index, Survey Quality Index, Net Promoter Score (NPS)
        /// </summary>
        public List<CsiScore> Scores { get; set; }
    }
}