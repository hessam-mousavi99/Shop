﻿using Shop.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Shop.Application.DTOs.Wallet
{
    public class WalletDto:BaseDto.BaseDto
    {
        #region properties

        [Display(Name = "کاربر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long UserId { get; set; }

        [Display(Name = "نوع تراکنش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public WalletType WalletType { get; set; }

        [Display(Name = "مبلغ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Amount { get; set; }

        [Display(Name = "شرح")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "پرداخت شده / نشده")]
        public bool IsPay { get; set; }
        #endregion 
    }
}
