using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelloWorldApi.Controllers
{
    public class CalcHikuController : ApiController
    {
        public int Get(int a, int b)
        {
            return a - b;
        }
    }
}
