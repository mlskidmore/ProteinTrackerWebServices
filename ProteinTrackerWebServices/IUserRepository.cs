using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProteinTrackerWebServices
{
    public interface IUserRepository
    {
        void Add(User user);
        IReadOnlyCollection<User> GetAllUsers();
        User GetByUserID(int ID);
        void Save(User updatedUser);
    }
}
