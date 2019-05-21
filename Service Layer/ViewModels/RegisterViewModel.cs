using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service_Layer.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Firstname is required."), Display(Name = "FirstName", Prompt = "First Name")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Lastname is required."), Display(Name = "LastName", Prompt = "Last Name")]
        public string Lastname { get; set; }

        [Display(Name = "Country", Prompt = "Country")]
        public string Country { get; set; }

        [Display(Name = "City", Prompt = "City")]
        public string City { get; set; }

        [Display(Name = "StreetName", Prompt = "Street Name")]
        public string Streetname { get; set; }

        [Display(Name = "Housenumber", Prompt = "Housenumber")]
        public string Housenumber { get; set; }

        [Display(Name = "Zip", Prompt = "Zip")]
        public string Zip { get; set; }

        [Display(Name = "PhoneNumber", Prompt = "Phone Number")]
        public string Phonenumber { get; set; }

        [Required(ErrorMessage = "Email is required"), Display(Name = "Email", Prompt = "E-mail")]
        public string Email { get; set; }
    }
}
