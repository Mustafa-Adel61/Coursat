using FARAHAT.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FARAHAT.Controllers
{
    [Authorize(Roles = "Admin")]

    public class RoleController : Controller
    {
        public ActionResult NewRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> NewRole(string RoleName)
        {
            ViewBag.RoleName = RoleName;
            if (RoleName != null)
            {
                ApplicationDbContext context = new ApplicationDbContext();
                RoleStore<IdentityRole> store = new RoleStore<IdentityRole>(context);
                RoleManager<IdentityRole> manager = new RoleManager<IdentityRole>(store);
                IdentityRole role = new IdentityRole();
                role.Name = RoleName;
                IdentityResult result = await manager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return Content($"Mission complete /n Role {RoleName} is Added");

                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}