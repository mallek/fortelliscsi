using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("csi/[controller]")]
    [ApiController]
    public class AssociateCsiController : ControllerBase
    {
        /// <summary>
        ///     Used to get mock CSI information for all Associates
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<AssociateInfo>> Get()
        {
            var results = new List<AssociateInfo>();
            results.AddRange(GetTravisCsi());
            results.AddRange(GetMaxCsi());

            return results;
        }
        private IEnumerable<AssociateInfo> GetTravisCsi()
        {
            var results = new List<AssociateInfo>();

            var a1 = new AssociateInfo()
            {
                UserId = "1",
                CompanyId = "1",
                PayrollId = "1",
                FirstName = "Travis",
                LastName = "Haley"
            };

            a1.Scores.AddRange(CsiScoreGenerator());
            results.Add(a1);

            return results;
        }

         private IEnumerable<AssociateInfo> GetMaxCsi()
        {
            var results = new List<AssociateInfo>();

            var a1 = new AssociateInfo()
            {
                UserId = "2",
                CompanyId = "1",
                PayrollId = "1",
                FirstName = "Max",
                LastName = "Tam"
            };

            a1.Scores.AddRange(CsiScoreGenerator());
            results.Add(a1);

            return results;
        }

        private List<CsiScore> CsiScoreGenerator()
        {

            var results = new List<CsiScore>();
            for (int i = 1; i < 5; i++)
            {
                var score = new CsiScore()
                {
                    Score = new Random().Next(1, 100),
                    Date = new DateTime(2019, i, 1)
                };
                results.Add(score);
            }
            return results;

        }

    }
}