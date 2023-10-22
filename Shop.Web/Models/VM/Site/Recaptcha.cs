
using System.ComponentModel.DataAnnotations;

namespace Shop.Web.Models.VM.Site
{
    public class Recaptcha
    {
        [Required()]
        public string Token { get; set; } = string.Empty;
    }
}
