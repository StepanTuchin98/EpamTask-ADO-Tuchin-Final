using INetwork.BLL;
using NetworkBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NetworkMVC.Views
{
    public class MessageController : Controller
    {

        private readonly INetworkLogic networkLogic;

        public MessageController()
        {
            this.networkLogic = new NetworkLogic();
        }

        // GET: Message
        [Authorize]
        [HttpGet]
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(networkLogic.GetMessagesByFriend(networkLogic.GetByLogin(User.Identity.Name).IDUser, id));
        }

        [Authorize]
        [HttpPost]
        public ActionResult Index()
        {
            return View();
        }
    }
}