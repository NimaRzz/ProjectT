using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Entities.BaseEntity
{
    public class BaseEntity<TKey>
    {
        public TKey Id { get; set; }

        public DateTime InsertTime { get; set; } = DateTime.Now;

        public DateTime? UpdateTime { get; set; }
       
        public DateTime? RemoveTime { get; set; }

        public bool IsRemoved { get; set; } = false;
    }

    public class BaseEntity : BaseEntity<long> { }
}
