using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealEstateAspNetMVC5_Staj2021.Models
{
    public class Tip
    {
        [Key] /*Primary Key */
        public int TypeId { get; set; }
        public string TypeName { get; set; }


        /*Status Type Many to one **/
        public int StatusId { get; set; }
        public Status Status { get; set; }
    }
}