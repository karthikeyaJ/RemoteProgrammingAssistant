using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace try2.Controllers
{
    public class WorkShiftsController : Controller
    {
        //
        // GET: /WorkShifts/
        [Authorize(Users="admin,employee")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "employee")]
        public ActionResult OnLeave()
        {
            return View();
        }
	}
}