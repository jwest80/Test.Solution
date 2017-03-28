using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Model.Entities;
using Test.Repo;

namespace Test.Data.Repositories
{
    public class BlogRepository : GenericRepository<Blog>
    {
        public BlogRepository() : base(new BloggingContext())
        {
        }
    }
}
