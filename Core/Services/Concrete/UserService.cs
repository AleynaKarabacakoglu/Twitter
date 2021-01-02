using Common.Dtos;
using Core.Services.Abstract;
using Domain.Context;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Core.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly TwitterContext _context;
        public UserService(TwitterContext context)
        {
            _context = context;
        }
        
        //Kayit ekleme
        public bool InsertUser(UserDto userdto)
        {
           
            User user = new User();
            user.Name = userdto.Name;
            user.Surname = userdto.Surname;
            user.Username = userdto.Username;
            user.Email = userdto.Email;
            user.Password = userdto.Password;
            user.FollowerCount = 0;
            user.FollowingCount = 0;
            user.ProfileImage = userdto.ProfileImage;
            _context.Users.Add(user); //.users ekledim
            var result = _context.SaveChanges();
            if (result > default(int))
                return true;
            return false;
        }
        //Email-Password Control
        public bool LoginControl(UserDto userdto)
        {
            User user = _context.Users.Where
                (x => (x.Username == userdto.Username 
                || x.Email == userdto.Username) && x.Password
                == userdto.Password).FirstOrDefault();
            
            bool result = user != null ? true : false;
            return result;           
        }

        public UserDto GetUserByUserName(string username)
        {
            UserDto user = _context.Users.Where(x => x.Username == username).Select(x => new UserDto
            {
                UserId = x.UserId,
                Username = x.Username,
                Name = x.Name,
                Email = x.Email,
                Surname = x.Surname,

            }).FirstOrDefault();
            return user;
        }
        public List<ContactDto> Follow(string username,UserDto me)
        {
            
            UserDto following = GetUserByUserName(username);
            UserDto follower = GetUserByUserName(me.Username);
            FollowTempDto _user = new FollowTempDto();           
            

            var connection = _context.Contacts.FirstOrDefault(x => x.FollowerId == follower.UserId && x.FollowingId == following.UserId && x.IsActive == false && x.IsDeleted == true);
            if (connection != null)
            {
                connection.IsActive = true;
                connection.IsDeleted = false;
                _context.Contacts.Update(connection);
            }
            else
            {
                ContactDto newcontact = new ContactDto();
                newcontact.FollowingId = following.UserId;
                newcontact.FollowerId = follower.UserId;
                newcontact.IsActive = true;
                newcontact.IsDeleted = false;
                _user.connections.Add(newcontact);
                Contact contact = new Contact();
                contact.FollowerId = newcontact.FollowerId;
                contact.FollowingId = newcontact.FollowingId;
                contact.IsActive = true;
                contact.IsDeleted = false;
                _context.Contacts.Add(contact);
            }

            User u = _context.Users.Find(follower.UserId);
            if (u != null)
            {
                u.FollowingCount += 1;
                _context.Users.Update(u);
            }
           

            User u2= _context.Users.Find(following.UserId);
            if (u2 != null)
            {
                u2.FollowerCount += 1;
                _context.Users.Update(u2);
            }
            _context.SaveChanges();

            return _user.connections;

        }
        public List<ContactDto> UnFollow(string username, UserDto me)
        {

            UserDto following = GetUserByUserName(username);
            UserDto follower = GetUserByUserName(me.Username);
            FollowTempDto _user = new FollowTempDto();


            var connection = _context.Contacts.FirstOrDefault(x => x.FollowerId == follower.UserId && x.FollowingId == following.UserId && x.IsActive == true && x.IsDeleted == false);
            if (connection != null)
            {
                connection.IsActive = false;
                connection.IsDeleted = true;
                _context.Contacts.Update(connection);
            }
            else
            {
                ContactDto newcontact = new ContactDto();
                newcontact.FollowingId = following.UserId;
                newcontact.FollowerId = follower.UserId;
                newcontact.IsActive = false;
                newcontact.IsDeleted = true;
                _user.connections.Remove(newcontact);
                Contact contact = new Contact();
                contact.FollowerId = newcontact.FollowerId;
                contact.FollowingId = newcontact.FollowingId;
                contact.IsActive = false;
                contact.IsDeleted = true;
                _context.Contacts.Remove(contact);
            }

            User u = _context.Users.Find(follower.UserId);
            if (u != null)
            {
                u.FollowingCount -= 1;
                _context.Users.Update(u);
            }


            User u2 = _context.Users.Find(following.UserId);
            if (u2 != null)
            {
                u2.FollowerCount -= 1;
                _context.Users.Update(u2);
            }
            _context.SaveChanges();

            return _user.connections;

        }

        public UserDto GetUserById(int id)
        {
            UserDto user = _context.Users.Where(x => x.UserId == id).Select(x => new UserDto
            {
                UserId = x.UserId,
                Username = x.Username,
                Name = x.Name,
                Email = x.Email,
                Surname = x.Surname,

            }).FirstOrDefault();

            return user;
        }

      
    }
}
