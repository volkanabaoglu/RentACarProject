using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Results;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data) : base(data, true)
        {
        }
        public SuccessDataResult(T data, string message) : base(data, message, true)
        {
        }

        public SuccessDataResult() : base(default, true)
        {
        }
    }
}
