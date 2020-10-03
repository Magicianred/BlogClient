using System.Threading.Tasks;
using BlogClient.ApiSerices.Interfaces;
using BlogClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogClient.Controllers
{
    public class AccountController : Controller{
        
        private readonly IAuthApiService _authService;
        public AccountController(IAuthApiService authService)
        {
            _authService=authService;    
        }
        public IActionResult SignIn(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserLoginModel model){
            if(await _authService.SignIn(model))
            {
                return RedirectToAction("Index","Home", new {@area="Admin"});
            }
            return View();
        }
    }
}