namespace DataAccessLayer.Models
{
    public partial class User
    {
        public User()
        {
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public int AccountNumber { get; set; }
        public int BankNumber { get; set; }
    }
}