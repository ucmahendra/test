using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevTraining.local.Models;
using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Mvc.Extensions;
using Sitecore.Mvc.Presentation;
using Sitecore.Sites;

namespace DevTraining.local.Controllers
{
    public class BreadcrumbController : Controller
    {
        // GET: Breadcrumb
        public ActionResult Index()
        {
            return View(GetBreadcrumbs(Context.Item, Context.Site));
        }

        public List<NavigationItem> GetBreadcrumbs(Item current, SiteContext site)
        {
            Item homeItem = Sitecore.Context.Database.GetItem(site.ContentStartPath + site.StartItem);
            List<NavigationItem> breadcrumbs = new List<NavigationItem>();

            while (current != null)
            {
                var itemLink = Sitecore.Links.LinkManager.GetItemUrl(current);
                var isActive = false;
                if (current.Fields["ExcludeFromNavigation"] != null)
                {
                    isActive = current.Fields["ExcludeFromNavigation"].Value.ToBool();
                }

                var breadcrumb = new NavigationItem(current.DisplayName, itemLink, isActive);
                breadcrumbs.Add(breadcrumb);
                if (current.ID == homeItem.ID)
                    break;
                current = current.Parent;
            }

            breadcrumbs.Reverse();

            return breadcrumbs;
        }
    }
}