using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Registration.Repository;
using Registration.Models;


namespace Registration.Controllers
{
    public class RegistrationController : Controller
    {
        //
        // GET: /Registration/
        RegistrationRepository _rrepository = new RegistrationRepository();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Manage(EMPRegistration model)
        {
            int num = _rrepository.ManageUsers(model);
            if (num > 0)
            {
                TempData["message"] = "Employee Register Successfully.";
                return RedirectToAction("Index");
            }
            if (num == -1)
            {
                TempData["message"] = "Emailid or Contact Number already exists";
                return View("Index");
            }
            TempData["message"] = "Something went wrong";
            return View("Index");
        }

    }
}
