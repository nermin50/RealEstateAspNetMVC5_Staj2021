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

        public System.Data.Entity.DbSet<RealEstateAspNetMVC5_Staj2021.Models.Status> Status { get; set; }

        public System.Data.Entity.DbSet<RealEstateAspNetMVC5_Staj2021.Models.Tip> Tips { get; set; }
    }
}