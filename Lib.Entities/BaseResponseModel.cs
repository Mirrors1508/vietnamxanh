using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Entities
{
    public class BaseResponseModel<T>
    {
        public int status { get; set; }
        public string msg { get; set; }
        public T data { get; set; }

    }
}
