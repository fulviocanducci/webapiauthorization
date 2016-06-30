using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [System.Web.Http.Authorize]
    [System.Web.Http.RoutePrefix("api/v1")]
    public class CreditsController : ApiController
    {
        protected DataContext dataContext;
        
        public CreditsController()
        {
            dataContext = new DataContext();
        }

        protected override void Dispose(bool disposing)
        {
            dataContext?.Dispose();
        }

        [System.Web.Http.Route("credits")]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public IEnumerable<Credit> Get()
        {
            return dataContext.Credits.ToList();
        }

        // GET: api/Credits/5
        [System.Web.Http.Route("credits/{id}")]
        public async Task<HttpResponseMessage> Get(int id)
        {
            Credit credit = await dataContext.Credits.FindAsync(id);
            return Request.CreateResponse(HttpStatusCode.OK, credit);
        }

        // POST: api/Credits
        [System.Web.Http.Route("credits")]
        public async Task<HttpResponseMessage> Post(Credit credit)
        {
            dataContext.Credits.Add(credit);
            await dataContext.SaveChangesAsync();
            return Request.CreateResponse(HttpStatusCode.Created, credit);
        }

        // PUT: api/Credits/5
        [System.Web.Http.Route("credits/{id}")]
        public async Task<HttpResponseMessage> Put(int id, Credit credit)
        {
            dataContext.Entry(credit).State = EntityState.Modified;
            await dataContext.SaveChangesAsync();
            return Request.CreateResponse(HttpStatusCode.OK, credit);

        }

        // DELETE: api/Credits/5
        [System.Web.Http.Route("credits/{id}")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            Credit credit = await dataContext.Credits.FindAsync(id);
            dataContext.Credits.Remove(credit);
            int i = await dataContext.SaveChangesAsync();
            return Request.CreateResponse(HttpStatusCode.OK, new {rows = i, deleted = (i > 0)});
        }
    }
}
