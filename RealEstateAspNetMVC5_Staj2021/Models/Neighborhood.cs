using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateAspNetMVC5_Staj2021.Models
{
    public class Neighborhood
    {
        public int NeighborhoodId { get; set; }
        public string NeighborhoodName { get; set; }

        // Many to one  Many Neighborhood (mahalla) in one District (semt)
        public int DistrictId { get; set; }
        public virtual District District { get; set; }
    }
}