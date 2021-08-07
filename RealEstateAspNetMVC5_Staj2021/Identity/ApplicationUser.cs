using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateAspNetMVC5_Staj2021.Identity
{
    public class ApplicationUser : IdentityUser
    {
        // Burda Microsoftun Idenitiy User Class'ini hazır olarak kullandık 
        //bütün Idenitiy User'deki özelikleri bu sınıf üzerinden kullanabiliriz
        // iki tane değişken fazla ekledik - burada eklenen değişkenler User Tablosuna eklenecek ve istedğimiz değişkenleri ekleyebiliriz 
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}