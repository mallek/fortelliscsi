using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealershipCsiController : ControllerBase
    {
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
            results.Add(ds);

            return results;
        }
    }
}