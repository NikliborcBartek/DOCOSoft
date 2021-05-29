using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class Entity
    {
        public long Id { get; private set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
