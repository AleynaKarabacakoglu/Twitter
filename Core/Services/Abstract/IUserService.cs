using Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Abstract
{
    public interface IUserService
    {
        bool InsertUser(UserDto user);
        UserDto GetUserById(int id);
        UserDto GetUserByUserName(string username);
        bool LoginControl(UserDto userdto);
        
        List<ContactDto> Follow(string username, UserDto me);
       List<ContactDto> UnFollow(string username, UserDto me);




    }
}
