using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RealEstateAspNetMVC5_Staj2021.Models
{
    public class DataContext : DbContext
    {
        //Database Connection 

        public DataContext() : base ("defaultCon")
        {

        }
    }
}