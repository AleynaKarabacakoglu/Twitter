
using Common.Dtos;
using Core.Services.Abstract;
using Core.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Twitter.Controllers
{
    public class TwitterController : Controller
    {
        private readonly ILogger<TwitterController> _logger;
        private readonly IPostService _postService;
        private readonly IUserService _userService;
        public TwitterController(ILogger<TwitterController> logger, IPostService postService,IUserService userService)
        {
            _logger = logger;
            _postService = postService;
            _userService = userService;
        }
        public IActionResult Home()
        {
            UserDto user = HttpContext.Session.GetObject<UserDto>("User");
            return View(_postService.GetPostList(user));
        }
        
        public IActionResult ProfileControl(UserDto user)
        {
            
            HttpContext.Session.SetObject("Search", user);
            HttpContext.Session.SetString("FriendUserName",user.Username);
            UserDto userDto=_userService.GetUserByUserName(user.Username);
            HttpContext.Session.SetString("Name", userDto.Name);
            return Json(true);
        }
        public IActionResult Profile()
        {
            UserDto user = HttpContext.Session.GetObject<UserDto>("User");
            UserDto userdto = HttpContext.Session.GetObject<UserDto>("Search");
           if(userdto==null)
            {
                userdto = new UserDto();
                userdto.Username = user.Username;
            }
            return View(_postService.GetProfileList(userdto));
            
        }
        public IActionResult GetMyProfile()
        {
            UserDto user = HttpContext.Session.GetObject<UserDto>("User");
            UserDto user2 = _userService.GetUserByUserName(user.Username);
            int id = user2.UserId;
            return Json(true);
        }

        public IActionResult PostControl(PostDto post)
        {
            UserDto obj = HttpContext.Session.GetObject<UserDto>("User");
            UserDto data=_userService.GetUserByUserName(obj.Username);
            post.UserId = data.UserId;
            _postService.Tweet(post);
           
            return Json(true);
        }
        public IActionResult Follow()
        {
            UserDto userdto = HttpContext.Session.GetObject<UserDto>("Search");
            UserDto user = HttpContext.Session.GetObject<UserDto>("User");
            _userService.Follow(userdto.Username, user);

            return PartialView("ProfilePartialView", _postService.GetProfileList(userdto));
        }
        public IActionResult UnFollow()
        {
            UserDto userdto = HttpContext.Session.GetObject<UserDto>("Search");
            UserDto user = HttpContext.Session.GetObject<UserDto>("User");
            _userService.UnFollow(userdto.Username, user);         
            return PartialView("ProfilePartialView",_postService.GetProfileList(userdto));

        }
        public IActionResult Like(TemplateDto post)
        {
           
            this._postService.Like(post.PostId);
            UserDto user = HttpContext.Session.GetObject<UserDto>("User");

            return PartialView("PostPartialView", _postService.GetPostList(user));
        }
       
    }
}
