using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service_Layer.ViewModels
{
    public class AddUserViewModel
    {
        [Required, Display(Name = "FirstName", Prompt = "First Name")]
        public string Firstname { get; set; }

        [Required, Display(Name = "LastName", Prompt = "Last Name")]
        public string Lastname { get; set; }

        [Required, Display(Name = "Country", Prompt = "Country")]
        public string Country { get; set; }

        [Required, Display(Name = "StreetName", Prompt = "Street Name")]
        public string Streetname { get; set; }

        [Required, Display(Name = "Housenumber", Prompt = "Housenumber")]
        public string Housenumber { get; set; }

        [Required, Display(Name = "Zip", Prompt = "Zip")]
        public string Zip { get; set; }

        [Required, Display(Name = "PhoneNumber", Prompt = "Phone Number")]
        public string Phonenumber { get; set; }

        [Required, Display(Name = "Email", Prompt = "E-mail")]
        public string Email { get; set; }
    }
}
