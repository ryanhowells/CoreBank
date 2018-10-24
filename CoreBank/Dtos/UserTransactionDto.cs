using System;

namespace CoreBank.Dtos
{
    public class UserTransactionDto
    {
        public double Amount { get; set; }
        public string Merchant { get; set; }
        public DateTime ClearedDate { get; set; }
    }
}
