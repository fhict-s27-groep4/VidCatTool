using System.ComponentModel.DataAnnotations;

namespace VidCat_Tool.ViewModels
{
    public class ResetCredentialsViewModel
    {
        [Required, Display(Name = "EMail", Prompt = "EMail"), DataType(DataType.EmailAddress)]
        public string EMail { get; set; }

        [Required, Display(Name = "ResetType", Prompt = "ResetType")]
        public string ResetType { get; set; }
    }
}
