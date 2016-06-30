using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Models;
namespace WebApi.Controllers
{
    [Authorize]
    public class LoginController : ApiController
    {
        protected DataContext dataContext;

        public LoginController()
        {
            dataContext = new DataContext();
        }

        public IHttpActionResult Get()
        {

            return Ok(new List<Credit>
            {
                new Credit("Login 1"),
                new Credit("Login 2")
            });

        }

        public IHttpActionResult Get(int id)
        {

            return Ok(new List<Credit>
            {
                new Credit("Login 1"),
                new Credit("Login 2")
            }.First(c => c.Id == id));

        }

        [HttpPost]
        public bool Post(_user u)
        {
            return true;
        }

        protected override void Dispose(bool disposing)
        {
            dataContext?.Dispose();
        }
    }

    public class _user
    {
        public string name { get; set; }
        public  string password { get; set; }
    }
}
