using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Customer:User
    {
        public int UserId { get; set; }
        public string CompanyName { get; set; }
    }
}
