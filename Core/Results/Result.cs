using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results
{
    public class Result:IResult
    {
        public Result(bool isSucccess)
        {
            IsSucccess = isSucccess;}
        public Result(string message, bool isSucccess):this(isSucccess)
        {
            Message = message;
        }

        public string Message { get; }
        public bool IsSucccess { get; }
    }
}
