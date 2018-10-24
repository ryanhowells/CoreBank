namespace CoreBank.Dtos
{
    public class UserAccountDto
    {
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string Sortcode { get; set; }
        public double Balance { get; set; }
        public double AvailableBalance { get; set; }
        public double? Overdraft { get; set; }
    }
}
