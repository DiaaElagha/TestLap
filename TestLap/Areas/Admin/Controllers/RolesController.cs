using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TestLap.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public RolesController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> CreateRoles()
        {
            IdentityResult result2 = await _roleManager.CreateAsync(new IdentityRole("Admin"));
            IdentityResult result3 = await _roleManager.CreateAsync(new IdentityRole("User"));

            if (result2.Succeeded && result3.Succeeded)
            {
                return new JsonResult("Succeeded");
            }
            return NotFound();
        }

    }
}