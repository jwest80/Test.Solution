using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data;
using Test.Model.Entities;
using Test.Repo;

namespace Test.Services
{
    public class BlogService : BaseService<Blog>
    {
        public BlogService()
        {
        }

        public BlogService(DbContext context) : base(context)
        {
            //_context = new BloggingContext();
        }
    }
}
