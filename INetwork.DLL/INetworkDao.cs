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

        IEnumerable<UserSearch> SearchByName(string Name, int? idUser);

        IEnumerable<UserSearch> SearchBySurname(string Surname, int? idUser);

        IEnumerable<UserSearch> SearchByTown(string Town, int? idUser);

        IEnumerable<UserSearch> SearchByYearOfBirth(int YearOfBirth, int? idUser);

        IEnumerable<Message> GetMessagesByFriend(Friend friend);

        IEnumerable<Friend> GetAllFriends(int? id);

        UserSearch GetById(int? id);

        void Edit(User user);

        string[] GetRoles(string username);
        bool IsUserInRole(string username, string roleName);

        void DeleteFriend(string username);

        void SendMessage(int userId, int friendId, string message);
    }
}
