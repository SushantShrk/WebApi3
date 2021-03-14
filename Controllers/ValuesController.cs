using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMaths maths;
        public ValuesController(IMaths maths)
        {
            this.maths = maths;
        }

        
        [HttpGet]
        [Route("get/{value}")]
        public string GetString(string value)
        {
            return value.ToUpper();
        }

        [HttpGet]
        [Route("Add/{a}/{b}")]
        public int getAdd(int a, int b)
        {
            return maths.addition(a, b);
        }


    }
}
