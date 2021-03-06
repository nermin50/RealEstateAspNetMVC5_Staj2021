using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealEstateAspNetMVC5_Staj2021.Models
{
    public class Register
    {
        // Required zorunlu alan demektir 
        //DisplayName kullancıya girelecek alanın adını gösterir ,
        // Email Adress : Text Field'e sadece email adresi tipinden girlir 
        //Compare Password : girilen iki şifrenin karşılaştırmasını yapar
        [Required]
        [DisplayName("Adı")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter student name.")]
        [DisplayName("Soyadı")]
        public string Surname { get; set; }
        [Required]
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "Geçersiz Email adresi")]
        public string Email { get; set; }
        [Required]
        [DisplayName("KullanıcıAdı")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Min 3 Max 15")]

        public string Username { get; set; }
        [Required]
        [DisplayName("Şifre")]
        public string Password { get; set; }
        [Required]
        [DisplayName("Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifreler Aynı Değil")]
        public string RePassword { get; set; }

    }
}