using LinksApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinksApp.Controllers
{
    public class ShrinkLinksController : Controller
    {
        // GET: Links
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Get(string id)
        {
            using (var context = new LinksEntities())
            {
                var original = context.Links.Where(x => x.ShortLink == id).FirstOrDefault();
                if (original != null)
                {
                    original.RedirectCount += 1;
                    context.SaveChanges();
                    return Redirect(original.OriginLink);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }


        [HttpPost]
        public ActionResult ZipUrl(string link)
        {
            Guid guid = Guid.Empty;
            while (Guid.Empty == guid)
            {
                guid = Guid.NewGuid();
            }

            var newGuid = Convert.ToBase64String(guid.ToByteArray());
            var path = HttpContext.Request.Url.GetLeftPart(UriPartial.Authority) + Url.Content("~/");
            var newLink = path + "ShrinkLinks/Get?id=" + newGuid;

            using (var context = new LinksEntities())
            {
                var newUrl = new Link
                {
                    OriginLink = link,
                    CreateDate = DateTime.Now,
                    RedirectCount = 0,
                    ShortLink = newGuid
                };
                context.Links.Add(newUrl);
                context.SaveChanges();
            }

            return Json(newLink);
        }
    }
}