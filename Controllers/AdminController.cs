using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystemWebApplication.Models;
using LibraryManagementSystemWebApplication.GenericRepository;

namespace LibraryManagementSystemWebApplication.Controllers
{
    public class AdminController : Controller
    {
        private readonly IGenericRepositoryLMS<Admin> _AdminObj;

        public AdminController(IGenericRepositoryLMS<Admin> AdminObj)
        {
            _AdminObj = AdminObj;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login_Model(Admin model)
        {
            try
            {
				var v1 = _AdminObj.Read().FirstOrDefault(x => x.userName == model.userName && x.password == model.password);
				if (v1 == null)
				{
					return View("Login", model);
				}
				else
					return RedirectToAction("BookList", "Books");
			}
            catch (Exception)
            {

                throw;
            }
            
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration_model(Admin model)
        {
            //if (ModelState.IsValid)
            if (model != null)
            {
                bool temp = _AdminObj.Create(model);
                if (temp)
                {
                    return RedirectToAction("Index","Home");
                }
            }
            return View();

        }

    }
}
