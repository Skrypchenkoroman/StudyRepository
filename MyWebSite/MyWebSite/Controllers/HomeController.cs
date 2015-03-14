using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWebSite.Models;

namespace MyWebSite.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Client> clients;
        public HomeController()
        {
            clients = new CustomRepository<Client>();
        }


        public ActionResult Index()
        {
            /*CustomDbContext db = new CustomDbContext();
            IEnumerable<Client> c = (IEnumerable<Client>)db.Clients;
            Client first = c.First();*/

            return View(clients.GetList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}