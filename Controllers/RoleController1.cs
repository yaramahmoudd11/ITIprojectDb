using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ITIprojectDb.Controllers
{
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            
        }

        public IActionResult Index() 
        {
            return View();
        
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(string roleName)
        {
            var exist= await _roleManager.RoleExistsAsync(roleName);
            if (!exist) 
            {
                TempData["error"] = "role is already exist";
                return View();
            }
            IdentityRole role= new IdentityRole();
            role.Name = roleName;
            var result= await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            TempData["error"] = "failed Process";
            return View();


        }
    }
}
