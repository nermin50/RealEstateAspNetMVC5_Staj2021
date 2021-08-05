using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateAspNetMVC5_Staj2021.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }

        //Many to one = Many District(semt) in one city (şehir)
        public List<District> Districts { get; set; }
    }
}