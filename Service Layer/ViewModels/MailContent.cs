using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service_Layer.ViewModels
{
    public class MailContent
    {
        [Required, Display(Name = "Subject", Prompt = "Subject")]
        public string Subject { get; set; }
        [Required, Display(Name = "Content", Prompt = "Content*")]
        public string Content { get; set; }
    }
}
