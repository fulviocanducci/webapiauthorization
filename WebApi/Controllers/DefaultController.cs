using System.Collections.Generic;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Authorize]
    public class DefaultController : ApiController
    {

        public DefaultController()
        {
                
        }

        public IHttpActionResult Get()
        {

            return Ok(new List<Credit>
            {
                new Credit("Credit 1"),
                new Credit("Credit 2"),
                new Credit("Credit 3"),
                new Credit("Credit 4")
            });

        }

    }

}
