using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model.Entities
{
    public class Blog : BaseEntity
    {

        public string Url { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
