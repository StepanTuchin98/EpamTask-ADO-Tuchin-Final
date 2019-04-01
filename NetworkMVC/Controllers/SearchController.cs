using Entities;
using INetwork.BLL;
using NetworkBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NetworkMVC.Controllers
{
    public class SearchController : Controller
    {

        private readonly INetworkLogic networkLogic;

        public SearchController()
        {
            this.networkLogic = new NetworkLogic();
        }


        [HttpGet]
        public ActionResult SearchByName()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchByName(string Name)
        {
            if (ModelState.IsValid)
            {
                var tmp = networkLogic.SearchByName(Name);
                return View(tmp);
            }

            return View();
        }

        [HttpGet]
        public ActionResult SearchByPhone()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchByPhone(string Phone)
        {
            if (ModelState.IsValid)
            {
                var tmp = networkLogic.SearchByPhone(Phone);
                return View(tmp);
            }

            return View();
        }

        [HttpGet]
        public ActionResult SearchBySurname()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchBySurname(string Surname)
        {
            if (ModelState.IsValid)
            {
                var tmp = networkLogic.SearchBySurname(Surname);
                return View(tmp);
            }

            return View();
        }

        [HttpGet]
        public ActionResult SearchByTown()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchByTown(string Town)
        {
            if (ModelState.IsValid)
            {
                var tmp = networkLogic.SearchByTown(Town);
                return View(tmp);
            }

            return View();
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.isFriend = networkLogic.GetAllFriends(User.Identity.Name).FirstOrDefault(x => x.IDUser == id) == null ? false: true ;
            return View(networkLogic.GetById(id));
        }
        [ActionName("Details")]
        [HttpPost]
        public ActionResult Details_Post([Bind(Include ="idUser")] int? idUser)
        {
            networkLogic.AddFriend(networkLogic.GetByLogin(User.Identity.Name).IDUser, idUser);
            return Redirect("~/MainPage/Friends");
        }
    }
}