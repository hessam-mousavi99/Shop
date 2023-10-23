using System.ComponentModel.DataAnnotations;

namespace Shop.Application.DTOs.Wallet
{
    public class ChargeWalletDto
    {
        [Display(Name = "مبلغ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Amount { get; set; }
    }
}
