using System;
using System.Collections.Generic;
using System.Text;

namespace Mandy.Blog.HelloWorld.Impl
{
    public class HelloWorldService : MandyBlogApplicationServiceBase, IHelloWorldService
    {
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
