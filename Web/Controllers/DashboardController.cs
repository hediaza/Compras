using BusinessLogic.TIENDAS;
using Common.Utils;
using Models.TIENDAS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class DashboardController : Controller {

        public ActionResult Index() {
            
            return View();
        }

        
    }
}