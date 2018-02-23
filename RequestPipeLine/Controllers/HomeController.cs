using System.Web;
using System.Web.Mvc;

namespace RequestPipeLine.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [PipelineFilter]
        public ActionResult Pipeline()
        {
            return View();
        }

        public ActionResult Application()
        {
            int count = (int)(HttpContext.Application["Count"] ?? 0);
            HttpContext.Application.Lock();
            HttpContext.Application["Count"] = count + 1;
            HttpContext.Application.UnLock();

            return View();
        }

        public ActionResult Cookie()
        {
            var cookie = Request.Cookies["Count"];
            int count = cookie == null ? 1 : int.Parse(cookie.Value) + 1;
            var newCookie = new HttpCookie("Count", count.ToString());
            Response.Cookies.Add(newCookie);

            return View(count);
        }

        public ActionResult SessionStorage()
        {
            return View();
        }
    }
}