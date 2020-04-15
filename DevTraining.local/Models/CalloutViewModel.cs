using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;

namespace DevTraining.local.Models
{
    public class CalloutViewModel : RenderingModel
    {
        public Item CalloutDatasource { get; set; }
        public string CssClass { get; set; }
        public override void Initialize(Rendering rendering)
        {
            CalloutDatasource = Sitecore.Context.Database.GetItem(rendering.DataSource);
            CssClass = rendering.Parameters["CssClass"];
        }
    }
}