using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BaseObject
{
    public class ServiceResult
    {
        public ServiceResult()
        {
            this.State = true;
        }

        public string Msg { get; set; }

        public bool State { get; set; }
    }

    public class ServiceResult<T>
    {
        public ServiceResult()
        {
            this.State = true;
        }

        public string Msg { get; set; }

        public bool State { get; set; }

        public T Data { get; set; }   
    }
}
