﻿namespace Shop.Web.Models.VM.Account
{
    public class FinallyOrderVM
    {
        public long OrderId { get; set; }
        public long UserId { get; set; }

        public bool IsWallet { get; set; }
    }
   
}
