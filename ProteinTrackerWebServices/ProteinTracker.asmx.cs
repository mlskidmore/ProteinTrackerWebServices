using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ProteinTrackerWebServices
{
    /// <summary>
    /// Summary description for ProteinTracker1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ProteinTracker_Test : System.Web.Services.WebService
    {

        [WebMethod]
        public List<User> ListUsers()
        {
            return new List<User> { new User() { Goal = 100, Name = "Joe", Total = 50, UserID = 5 } };
        }
    }
}
