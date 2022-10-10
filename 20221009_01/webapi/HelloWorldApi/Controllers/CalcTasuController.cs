using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelloWorldApi.Controllers
{
    public class CalcTasuController : ApiController
    {
        public int Get(int a, int b, int? c = null)
        {
            return a + b + (c ?? 0);
        }
    }
}
