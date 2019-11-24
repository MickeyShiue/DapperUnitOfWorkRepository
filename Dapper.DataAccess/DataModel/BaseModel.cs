using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.DataAccess.DataModel
{
    public abstract class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}
