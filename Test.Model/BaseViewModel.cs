using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model
{
    public interface IViewModel<T>
    {
        T Id { get; set; }
        string Name { get; set; }

    }

    public class BaseViewModel : IViewModel<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
