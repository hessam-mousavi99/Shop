
using System.ComponentModel.DataAnnotations;

namespace Shop.Web.VM.Site
{
    public class Recaptcha
    {
        [Required()]
        public string Token { get; set; }=string.Empty;
    }
}
