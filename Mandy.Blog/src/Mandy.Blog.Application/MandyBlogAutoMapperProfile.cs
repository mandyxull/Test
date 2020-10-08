using AutoMapper;
using Mandy.Blog.Blog;
using Mandy.Blog.Domain.Blog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mandy.Blog
{
    /// <summary>
    /// 定义一种映射的方法是创建一个Profile 类
    /// </summary>
    public class MandyBlogAutoMapperProfile: Profile
    {
        public MandyBlogAutoMapperProfile()
        {
            CreateMap<Post, PostDto>();

            CreateMap<PostDto, Post>().ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
