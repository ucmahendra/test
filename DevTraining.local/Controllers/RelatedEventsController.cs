using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevTraining.local.Models;
using Sitecore.Data.Items;
using Sitecore.Mvc.Extensions;
using Sitecore.Sites;

namespace DevTraining.local.Controllers
{
    public class RelatedEventsController : Controller
    {
        // GET: RelatedEvents
        public ActionResult Index()
        {
            return View(GetRelatedEvents(Sitecore.Context.Item));
        }
        public List<NavigationItem> GetRelatedEvents(Item current)
        {
            List<NavigationItem> relatedEvents = new List<NavigationItem>();
            Sitecore.Data.Fields.MultilistField refMultilistField = current.Fields["Related Events"];
            if (refMultilistField != null)
            {
                var items = refMultilistField.GetItems();

                foreach (var itm in items)
                {
                    var itemLink = Sitecore.Links.LinkManager.GetItemUrl(itm);
                    var isActive = itm.Fields["Exclude from navigation"].Value.ToBool();
                    var related = new NavigationItem(itm.DisplayName, itemLink, isActive);
                    relatedEvents.Add(related);
                }

            }
            return relatedEvents;
        }
    }
}