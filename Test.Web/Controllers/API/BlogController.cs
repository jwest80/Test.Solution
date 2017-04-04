using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test.Model.Entities;
using Test.Services;

namespace Test.Web.Controllers.API
{
    public class BlogController : BaseAPIController<Blog, BlogService>
    {
    }
}