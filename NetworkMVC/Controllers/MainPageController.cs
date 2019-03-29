﻿using Entities;
using INetwork.BLL;
using NetworkBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetworkMVC.Controllers
{
    public class MainPageController : Controller
    {

        private readonly INetworkLogic networkLogic;

        public MainPageController()
        {
            this.networkLogic = new NetworkLogic();
        }

        // GET: MainPage
        
        [HttpGet]
        public ActionResult SingUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SingUp(User user)
        {
            networkLogic.SingUp(user);

            return Redirect("Index");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}