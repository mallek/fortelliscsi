using System;
using System.Collections.Generic;

namespace API.Models
{
    public class CsiScore
    {

        /// <summary>
        /// This is the score for the associate
        ///  Also know as: CSI, SSI, MBEP, Customer Experience Index, Survey Quality Index, Net Promoter Score (NPS)
        /// </summary>
         public float Score { get; set; }

        /// <summary>
        /// This is the reporting period date
        /// </summary>
         public DateTime Date { get; set; }
    }
}