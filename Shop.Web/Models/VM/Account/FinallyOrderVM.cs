using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Web.Models.VM.Account
{
    public class FinallyOrderVM
    {
        public long OrderId { get; set; }
        public long UserId { get; set; }

        public bool IsWallet { get; set; }
    }
   
}
