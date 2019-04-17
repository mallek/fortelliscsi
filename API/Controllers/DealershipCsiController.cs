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
    public class DealershipCsiController : ControllerBase
    {
        /// <summary>
        ///     Used to get mock CSI information
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<DealershipCsi>> Get()
        {
            var results = new List<DealershipCsi>();
            var ds = new DealershipCsi()
            {
                CompanyId = "1",
                CompanyName = "Test Company 1",
                RegionId = "West",
                Score = 89.6f,
                NumberOfSurveys = 151,
                Month = 1,
                Year = 2019,
                Department = "Sales"
            };
            var ds1 = new DealershipCsi()
            {
                CompanyId = "1",
                CompanyName = "Test Company 1",
                RegionId = "West",
                Score = 93.6f,
                NumberOfSurveys = 199,
                Month = 2,
                Year = 2019,
                Department = "Sales"
            };
            var ds2 = new DealershipCsi()
            {
                CompanyId = "1",
                CompanyName = "Test Company 1",
                RegionId = "West",
                Score = 69.4f,
                NumberOfSurveys = 122,
                Month = 3,
                Year = 2019,
                Department = "Sales"
            };
            results.Add(ds);
            results.Add(ds1);
            results.Add(ds2);


            return results;
        }
    }
}