using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBank.Dtos
{
    public class UserAccounts
    {
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string Sortcode { get; set; }
        public double Balance { get; set; }
        public double AvailableBalanace { get; set; }
        public double? Overdraft { get; set; }
    }
}
