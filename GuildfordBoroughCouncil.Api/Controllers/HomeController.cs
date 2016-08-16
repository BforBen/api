using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GuildfordBoroughCouncil.Api.Controllers
{
    public class HomeController : ApiController
    {
        [Route("~/")]
        [HttpGet]
        public HttpResponseMessage Home()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            //response.Headers.Location = new Uri("https://www2.guildford.gov.uk/developers");

            return response;
        }
    }
}
