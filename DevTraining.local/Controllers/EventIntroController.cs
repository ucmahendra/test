using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using DevTraining.local.Models;
using Sitecore.Mvc.Presentation;
using Sitecore.Syndication;
using Sitecore.Web.UI.WebControls;

namespace DevTraining.local.Controllers
{
    public class EventIntroController : Controller
    {
        // GET: EventIntro
        public ActionResult Index()
        {
            return View(CreateModel());
        }
        public static EventIntro CreateModel()
        {
            var item = RenderingContext.Current.ContextItem;
            return new EventIntro()
            {
                PageItem = item,
                EventDate = GetEeventDate()
            };

        }
        public static string GetEeventDate()
        {
            return "test";
        }
    }

}