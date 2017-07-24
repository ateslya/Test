using LinksApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinksApp.Controllers
{
    public class InfoController : Controller
    {
        // GET: Info
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Get()
        {
            using (var context = new LinksEntities())
            {
                var path = HttpContext.Request.Url.GetLeftPart(UriPartial.Authority) + Url.Content("~/") + "ShrinkLinks/Get?id=";
                var links = context.Links.ToList();
                links.AsParallel().ForAll(x =>
                {
                    x.ShortLink = x.ShortLink.Insert(0, path);
                });

                var jsonSettings = new JsonSerializerSettings();
                jsonSettings.Converters.Add(new IsoDateTimeConverter());

                var result = JsonConvert.SerializeObject(links, Formatting.Indented, new IsoDateTimeConverter());

                return Content(result, "application/json");
            }
        }
    }
}