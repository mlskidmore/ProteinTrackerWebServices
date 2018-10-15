using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ProteinTrackerWebServices
{
    /// <summary>
    /// Summary description for ProteinTrackerWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ProteinTrackerWebService : WebService
    {
        private UserRepository repository = new UserRepository();

        [WebMethod(Description ="Increments total.", EnableSession =true)]
        public int AddProtein(int amount, int userID)
        {
            var user = repository.GetByUserID(userID);

            if (user == null)
                return -1;

            user.Total += amount;
            repository.Save(user);
            return user.Total;
        }

        [WebMethod(EnableSession = true)]
        public int AddUser(string name, int goal)
        {
            var user = new User { Goal = goal, Name = name, Total = 0 };
            repository.Add(user);

            return user.UserID;
        }

        [WebMethod(EnableSession = true)]
        public List<User> UsersList()
        {
            return new List<User>(repository.GetAllUsers());
        }
    }
}
