using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data;
using Test.Model.Entities;

namespace Test.Services
{
    class BlogService
    {
        private DbContext _context;

        public BlogService()
        {
            _context = new BloggingContext();
        }

        public int Create(Blog blog)
        {
            //var repo = new GenericRepository(_context);

            //return blog.Id;

            throw new NotImplementedException();
        }
    }
}
