using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogTrakerHttpClient.Controllers
{
    public class DashBoardController : Controller
    {
        // GET: DashBoard
       public ActionResult dash()
        {
            return View();
        }
    }
}