using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;

namespace DevTraining.local.Models
{
    public class EventIntro
    {
        public Item PageItem { get; set; }
        public string EventDate { get; set; }
    }
}