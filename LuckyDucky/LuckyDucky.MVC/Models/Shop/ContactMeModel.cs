using System.ComponentModel.DataAnnotations;

namespace LuckyDucky.MVC.Models
{
    public class ContactMeModel
    {
        [Required(ErrorMessage = "Name not specified")]
        //^[A-Za-z]*[[A-Za-z]*|[ ]?]*[A-Za-z]+$ spaces in name?
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Name should consist only of letters")]
        [Display(Description = "Name", Prompt = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email not specified")]
        [EmailAddress(ErrorMessage = "Incorrect email")]
        [Display(Description = "Email", Prompt = "example@example.org")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Message not specified")]
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "Message must be less than 1000 characters")] 
        [Display(Description = "Message", Prompt = "Your message here")]
        public string Message { get; set; }

        public ShopAPIModel ContactMeInfo { get; set; }
    }
}
