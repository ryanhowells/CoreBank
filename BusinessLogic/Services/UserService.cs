using BusinessLogic.Interfaces;
using DataAccessLayer.Models;
using System.Net;

namespace BusinessLogic.Services
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IRepository<User> _userRepository;
        
        public UserService(IRepository<User> userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public HttpWebResponse GetAPIStreamReader(string getUserAccountUrl)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(getUserAccountUrl);
            httpWebRequest.Accept = "application/json";
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            return (HttpWebResponse)httpWebRequest.GetResponse();
        }
    }
}
