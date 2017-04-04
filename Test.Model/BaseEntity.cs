using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model
{
    public interface IEntity<T>
    {
        T Id { get; set; }

        string Name { get; set; }
    }

    public class BaseEntity : IEntity<int>
    {

        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }

        [Column(Order = 2)]
        public string Name { get; set; }

        public DateTime? Created { get; set; }

        [StringLength(100)]
        public string CreatedBy { get; set; }

        public DateTime? Modified { get; set; }

        [StringLength(100)]
        public string ModifiedBy { get; set; }

        public bool Active { get; set; }
    }
}
