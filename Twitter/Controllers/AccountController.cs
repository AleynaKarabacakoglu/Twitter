using Common.Dtos;
using Core.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Twitter.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUserService _userService;
        public AccountController(ILogger<AccountController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        
        public IActionResult SignIn()
        {
            return View();
        }
        public IActionResult SignInControl(UserDto userDto)
        {
            bool result = _userService.LoginControl(userDto);
            if (result)
            {
                HttpContext.Session.SetString("Me", userDto.Username);
                UserDto user = _userService.GetUserByUserName(userDto.Username);
                string name = user.Name;
                HttpContext.Session.SetString("MyName", name);
                HttpContext.Session.SetObject("User", userDto);
                
                return Json(true);
            }
            else
                return Json(false);
        }
        public IActionResult SignUp(UserDto newUser)
        {
            string path= HttpContext.Session.GetString("path");
            newUser.ProfileImage= "~/img/"+path;
            bool result=_userService.InsertUser(newUser);
            if (result)
                return Json(true);
            else
              return Json(false);
            

        }
        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file != null)
            {
                string imageExtension = Path.GetExtension(file.FileName);//uzantı

                string imageName = Guid.NewGuid() + imageExtension;//unique filename

                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/img/{imageName}");
                HttpContext.Session.SetString("path", imageName);
                using var stream = new FileStream(path, FileMode.Create);

                await file.CopyToAsync(stream);
            }

            return Json("true");
        }



    }
}
