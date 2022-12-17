using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results
{
    public class DataResult <T>:Result,IDataResult<T>
    {
        public T Data { get; }


        public DataResult(T data,bool isSucccess) : base(isSucccess)
        {
            Data = data;
        }

        public DataResult(T data,string message, bool isSucccess) : base(message, isSucccess)
        {
            Data = data;
        }
    }
}
