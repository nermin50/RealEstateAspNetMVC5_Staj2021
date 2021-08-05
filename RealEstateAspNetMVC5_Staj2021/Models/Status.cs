using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealEstateAspNetMVC5_Staj2021.Models
{
    public class Status
    {
        [Key] /*Primary Key*/
        public int StatusId { get; set; }
        public string StatusName { get; set; }

        /*Emlakın tiplerini listelemek için */
        public List<Tip> Tips { get; set; }
    }
}