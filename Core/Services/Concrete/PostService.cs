using Common.Dtos;
using Core.Services.Abstract;
using Domain.Context;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Core.Services.Concrete
{
    public class PostService : IPostService
    {
        private readonly TwitterContext _context;
        private readonly IUserService _userService;
        public PostService(TwitterContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public bool Tweet(PostDto postdto)
        {
            Post post = new Post();
            post.Text = postdto.Text;
            post.UserId = postdto.UserId;
            post.RetweetCount = 0;
            post.ReplyCount = 0;
            post.LikeCount = 0;
            post.CreatedDate = DateTime.Now;
            _context.Posts.Add(post); 
            var result = _context.SaveChanges();
            if (result > default(int))
                return true;
            return false;
        }
        public List<TemplateDto> GetPostList(UserDto _user)
        {
            
            UserDto user = _userService.GetUserByUserName(_user.Username);
            int id = user.UserId;
            List<TemplateDto> listdto = new List<TemplateDto>();
            List<Contact> Followinglist = _context.Contacts.Where(x => x.FollowerId == id && x.IsActive==true && x.IsDeleted==false).ToList();
            foreach (var flw in Followinglist)
            {
                foreach (var item in GetListById(flw.FollowingId))
                {
                    listdto.Add(item);
                }
            }
            listdto = listdto.OrderByDescending(x => x.CreatedDate).ToList();

            return listdto;
        }
        public List<TemplateDto> GetProfileList(UserDto _user)
        {

            UserDto user = _userService.GetUserByUserName(_user.Username);
            int id = user.UserId;

            var posts = (from u in _context.Users
                         join p in _context.Posts
                      on
                          u.UserId equals p.UserId
                         select new
                         {
                             u.Username,
                             u.UserId,
                             u.Posts,
                             u.Name,
                             u.Surname,
                             p.LikeCount,
                             p.ReplyCount,
                             p.RetweetCount,
                             p.Text,
                             p.CreatedDate
                         }).OrderByDescending(x => x.CreatedDate);


            var list = posts.Where(x => x.UserId == id).ToList();
            List<TemplateDto> listdto = new List<TemplateDto>();
            foreach (var item in list)
            {
                TemplateDto u = new TemplateDto();
                u.Name = item.Name;
                u.Username = item.Username;
                u.Surname = item.Surname;
                u.ReplyCount = (int)item.ReplyCount;
                u.RetweetCount = (int)item.RetweetCount;
                u.LikeCount = (int)item.LikeCount;
                u.Text = item.Text;
                u.CreatedDate = item.CreatedDate;
                listdto.Add(u);
            }

            return listdto;

        }
        public List<TemplateDto> GetListById(int id)
        {
            var posts = (from u in _context.Users
                         join p in _context.Posts
                         on
                          u.UserId equals p.UserId
                         select new
                         {
                             u.Username,
                             u.UserId,
                             u.Posts,
                             u.Name,
                             u.Surname,
                             p.LikeCount,
                             p.ReplyCount,
                             p.RetweetCount,
                             p.Text,
                             p.CreatedDate,
                             p.PostId,
                             
                         }).OrderByDescending(x => x.CreatedDate);

            var list = posts.Where(x => x.UserId == id).ToList();

            List<TemplateDto> listdto = new List<TemplateDto>();

            foreach (var item in list)
            {
                TemplateDto u = new TemplateDto();
                u.Name = item.Name;
                u.Username = item.Username;
                u.Surname = item.Surname;
                u.ReplyCount = (int)item.ReplyCount;
                u.RetweetCount = (int)item.RetweetCount;
                u.LikeCount = (int)item.LikeCount;
                u.Text = item.Text;
                u.CreatedDate = item.CreatedDate;
                u.PostId = item.PostId;
               
                listdto.Add(u);
            }
            return listdto;
        }
        public void Like(int postId)
        {
            //if (this.Exists(postId))
            //{
            Post post = _context.Posts.Find(postId);
            post.LikeCount++;
            //Like like = new Like();
            //like.PostId = postId;
            _context.Posts.Update(post);
            this._context.SaveChanges();
            //}
        }
    }
}
