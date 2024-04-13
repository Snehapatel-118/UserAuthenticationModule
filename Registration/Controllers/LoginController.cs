using Registration.Models;
using Registration.Repository;
using Registration.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        LoginRepository _lrepository = new LoginRepository();
        public ActionResult Index()
        {
            EMPRegistration model = new EMPRegistration();
            return View();
        }
        [HttpPost]
        public ActionResult Login(EMPRegistration model)
        {

                Security secu = new Security();
                EMPRegistration u = _lrepository.GetEmployee(model.Email, secu.Encrypt(model.Password));
                if (u == null)
                {
                    ViewBag.Message = "Email Id or Password does not match";
                    return View("Index");
                }
                else
                {
             
                    return View("Home");
                }
            }

        public ActionResult Home()
        {
            return View();
        }
          

        
    }
}
