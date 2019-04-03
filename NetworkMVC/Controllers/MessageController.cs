using Entities;
using INetwork.BLL;
using NetworkBLL;
using NetworkMVC.Models;
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
            var ms = new List<MessageWithNames>();
            int? idUser = networkLogic.GetByLogin(User.Identity.Name).IDUser;
            foreach (Message m in networkLogic.GetMessagesByFriend(idUser, id))
            {
                ms.Add(new MessageWithNames(m, networkLogic.GetById(id).Name, networkLogic.GetById(idUser).Name));
            }
            return View(ms.AsEnumerable());
        }

        [Authorize]
        [HttpPost]
        public ActionResult Index([Bind(Include = "idFriend, message")] int? idFriend, string message)
        {
            int? id = networkLogic.GetByLogin(User.Identity.Name).IDUser;
            networkLogic.SendMessage(id, idFriend, message);
            var ms = new List<MessageWithNames>();
            foreach(Message m in networkLogic.GetMessagesByFriend(id, idFriend)){
                ms.Add(new MessageWithNames(m, networkLogic.GetById(idFriend).Name, networkLogic.GetById(id).Name));
            }
            return View(ms.AsEnumerable());
        }
    }
}