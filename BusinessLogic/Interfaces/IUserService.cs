using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface IUserService : IService<User>
    {
        HttpWebResponse GetAPIStreamReader(string getUserAccountUrl);
    }
}
