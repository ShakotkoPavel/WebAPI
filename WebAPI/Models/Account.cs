using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Account
    {
        public int Id{ get; set; }

        public string MessengerID { get; set; }

        public decimal Balance { get; set; }
    }
}