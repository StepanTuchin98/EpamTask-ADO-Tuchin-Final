using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INetwork.DLL
{
    public interface INetworkDao
    {
        int SingUp(User user);

        void AddFriend(int? IdUser, int? IdFriend);

        IEnumerable<UserSearch> SearchByName(string Name);

        IEnumerable<UserSearch> SearchBySurname(string Surname);

        IEnumerable<UserSearch> SearchByTown(string Town);

        IEnumerable<UserSearch> SearchByPhone(string Phone);

        IEnumerable<Message> GetMessagesByFriend(Friend friend);

        IEnumerable<Friend> GetAllFriends(string username);

        User GetByLogin(string username);

        void Edit(User user);

        string[] GetRoles(string username);
        bool IsUserInRole(string username, string roleName);

        void DeleteFriend(string username);

        Message SendMessage(int userId, int friendId, string message);

        User LogIn(string login, string password);
    }
}
