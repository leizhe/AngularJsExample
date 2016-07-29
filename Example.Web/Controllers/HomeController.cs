using Example.Application.ServiceContract;
using Example.Domain.Model;
using Example.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Example.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult UnLogin()
        {
            return Redirect("Login");
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            //if (username.Equals("admin")&&password.Equals("admin"))
            //{
            //    User loginUser = new User {
            //        Name = "admin",
            //        UserRoles = new List<UserRole> {
            //            new UserRole {

            //                Role=new Role
            //                {
            //                    RoleName="Admin",
            //                    RolePermissions=new List<RolePermission> {
            //                            new RolePermission {
            //                                Permission=new Permission
            //                                {
            //                                    Name="可以查看的Url",
            //                                    Url="/users/list"
            //                                }
            //                            }
            //                    }
            //                }
            //            }
            //        }
            //    };

            //    return Json(loginUser,JsonRequestBehavior.AllowGet);
            //}
            if (_userService.Exist(username, password))
                return RedirectToAction("Index", "Home");
            else
                return View("error");
        }
    }
}