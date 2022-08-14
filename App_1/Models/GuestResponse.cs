using System.ComponentModel.DataAnnotations;
using PartyInvites.Scripts;

namespace PartyInvites.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "● Please enter your name")]
        [CustomAnnotations.ExcludeChar("#!#?><.,:@%^&", ErrorMessage = "● Name contains invalid character")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "● Please enter your email address")]
        [CustomAnnotations.HasAt("@", ErrorMessage = "● Incorrect formatting for the email address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "● Please enter your phone number")]
        [CustomAnnotations.ExcludeChar("abcdefhijklmnopqrstuvwxyz", ErrorMessage = "● A phone number can't contain any letters")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "● Please tell me whether you're coming or not")]
        public bool? WillAttend {get; set;}
    }
}
