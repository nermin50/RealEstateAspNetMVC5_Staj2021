using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateAspNetMVC5_Staj2021.Models
{
    public class AdvPhoto
    {

        /*bu tabloda her ilanın resimlerini kaydedecez sadce resimin adını */
        public int AdvPhotoId { get; set; }
        public string AdvPhotoName { get; set; }

        /*Many To One Many photo to one ilan*/
        public int AdvId { get; set; }
        public Advertisement Advertisement { get; set; }
    }
}