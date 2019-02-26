using System.ComponentModel.DataAnnotations;

namespace VidCat_Tool.ViewModels
{
    public class LoginViewModel
    {
        [Required, Display(Name ="Username", Prompt = "Username")]
        public string UserName { get; set; }

        [Required, Display(Name = "Password", Prompt = "Password"), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
