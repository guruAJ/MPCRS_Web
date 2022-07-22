using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace MPCRS1.Controllers
{
    public class ChartInMVCRuntimeController : Controller
    {
        public object JsonRequestBehavior { get; private set; }

        public IActionResult Index()
        {
            //return View("~/Views/RuntimeChart/ChartInMVC.cshtml");
            return View();  
        }

        //public ActionResult ChartInMVC()
        //{
        //    int male = context.HighCharts.Where(x => x.Gender == "Male").Count();
        //    int female = context.HighCharts.Where(x => x.Gender == "Female").Count();
        //    int other = context.HighCharts.Where(x => x.Gender == "Other").Count();
        //    Ratio obj = new Ratio();
        //    obj.Male = male;
        //    obj.Female = female;
        //    obj.Other = other;

        //    return Json(obj, JsonRequestBehavior.AllowGet);
        //}
    }
}

