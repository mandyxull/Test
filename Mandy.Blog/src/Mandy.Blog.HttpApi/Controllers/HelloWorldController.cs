﻿using Mandy.Blog.HelloWorld;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.AspNetCore.Mvc;
using static Mandy.Blog.Domain.Shared.MandyBlogConsts;

namespace Mandy.Blog.HttpApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = Grouping.GroupName_v3)]
    public class HelloWorldController : AbpController
    {
        private readonly IHelloWorldService _helloWorldService;

        public HelloWorldController(IHelloWorldService helloWorldService)
        {
            _helloWorldService = helloWorldService;
        }

        [HttpGet]
        public string HelloWorld()
        {
            return _helloWorldService.HelloWorld();
        }

        [HttpGet]
        [Route("Exception")]
        public string Exception()
        {
            throw new NotImplementedException("这是一个未实现的异常接口");
        }
    }
}
