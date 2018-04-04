using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Account
    {
        public int Id { get; set; }

        public int MessengerId { get; set; }

        public decimal Balance { get; set; }
    }
}