﻿using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Core.Entities;
using Entities.Concrete;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfRepositoryBase<Brand,DBContext> ,IBrandDal
    {
 
      
       
    
    }
}
