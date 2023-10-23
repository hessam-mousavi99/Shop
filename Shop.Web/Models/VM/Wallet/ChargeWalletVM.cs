using System.ComponentModel.DataAnnotations;

namespace Shop.Web.Models.VM.Wallet
{
    public class ChargeWalletVM
    {
        [Display(Name = "مبلغ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Amount { get; set; }
    }
}
