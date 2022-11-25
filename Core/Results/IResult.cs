using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results
{
    public interface IResult
    {
        string Message { get; }
        bool IsSucccess { get; }

    }
}
