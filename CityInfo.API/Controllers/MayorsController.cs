using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{   [ApiController]
    public class MayorsController  : ControllerBase
    {
        public JsonResult GetMayors() {
            return new JsonResult(
                new List<object>()
                {
                    new {id = 1, Name = "Isko Moreno " , age =45},
                     new {id = 1, Name = "Vico Sotto " , age =41}
                }
                );
        }

    }
}
