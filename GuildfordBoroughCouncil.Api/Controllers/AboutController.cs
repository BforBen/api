using System;
using System.Web.Http;
using System.Web.Http.Description;

namespace GuildfordBoroughCouncil.Api.Controllers
{
    /// <summary>
    /// About controller
    /// </summary>
    public class ApiAboutController : ApiController
    {
        /// <summary>
        /// Gets the version number of the API
        /// </summary>
        /// <returns>Version number of the API</returns>
        [HttpGet]
        [Route("_about")]
        [ResponseType(typeof(string))]
        public IHttpActionResult About()
        {
            var Ver = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            return Ok(String.Format("{0}.{1}.{2}", Ver.Major, Ver.Minor, Ver.Build));
        }
    }
}