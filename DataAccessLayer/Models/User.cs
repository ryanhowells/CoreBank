using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public partial class User
    {
        public User()
        {
        }

        public int UserId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public int AccountNumber { get; set; }
        [Required]
        public int BankNumber { get; set; }
    }
}