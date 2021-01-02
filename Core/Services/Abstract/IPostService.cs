using Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Abstract
{
    public interface IPostService
    {
        bool Tweet(PostDto post);
        List<TemplateDto> GetPostList(UserDto user);
        List<TemplateDto> GetProfileList(UserDto _user);
        List<TemplateDto> GetListById(int id);
        void Like(int postId);
    }
}
