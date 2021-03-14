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
    public class MultiImpinterfaceController : ControllerBase
    {
        IService service;
      public MultiImpinterfaceController(Func<ServiceEnum, IService> serviceResolver)
        //public MultiImpinterfaceController(IEnumerable<IService> services)
        {
            var serviced = serviceResolver(ServiceEnum.A);
        }

        [HttpGet]
        public int operation( )
        {
            return service.GetData(15);
        }


    }

    public interface IService
    {
        int GetData(int a);
    }

    public class ServiceA : IService
    {
        public int GetData(int a)
        {
            return a * a;
        }
    }
    public class ServiceB : IService
    {
        public int GetData(int a)
        {
            return a + a;
        }
    }
    public class ServiceC : IService
    {
        public int GetData(int a)
        {
            return a / a;
        }
    }


    public enum ServiceEnum
    {
        A,
        B,
        C
    }
}
