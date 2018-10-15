using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace ProteinTrackerWebServices
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> users = new List<User>();
        private static int nextID = 0;
        public void Add(User user)
        {
            user.UserID = nextID;
            nextID++;
            users.Add(user);
        }

        public IReadOnlyCollection<User> GetAllUsers()
        {
            return users.AsReadOnly();
        }

        public User GetByUserID(int ID)
        {
            var user = users.SingleOrDefault(u => u.UserID == ID);

            if (user == null)
                return null;

            return new User { Goal = user.Goal, Name = user.Name, UserID = user.UserID, Total = user.Total };
        }

        public void Save(User updatedUser)
        {
            var originalUser = users.SingleOrDefault(u => u.UserID == updatedUser.UserID);

            if (originalUser == null)
                return;

            originalUser.Name = updatedUser.Name;
            originalUser.Total = updatedUser.Total;
            originalUser.Goal = updatedUser.Goal;
        }
    }
}