using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    public class ImageController : Controller
    {
        // GET api/image/machinename
        [HttpGet("{name}")]
        public string Get(string name)
        {
            return Utils.GetPlaceHoldImg(24, 400, 200, name).ToString();
        }

        // // GET api/image
        // //Return the webapi container name
        // [HttpGet]
        // public string Get()
        // {
        //     return Utils.GetPlaceHoldImg(24, 400, 200, Microsoft.AspNetCore.Http.HttpContext.Request.Host).ToString();
        // }
    }
}