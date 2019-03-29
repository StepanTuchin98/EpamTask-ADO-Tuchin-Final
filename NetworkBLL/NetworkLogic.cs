using Entities;
using INetwork.BLL;
using INetwork.DLL;
using NetworkDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkBLL
{
    public class NetworkLogic : INetworkLogic
    {

        private INetworkDao NetworkDao;


        public NetworkLogic()
        {
            NetworkDao = new NetworkDao();
        }

        public void AddFriend(int? IdUser, int? IdFriend)
        {
            NetworkDao.AddFriend(IdUser, IdFriend);
        }

        public void Edit(User user)
        {
            NetworkDao.Edit(user);
        }

        public IEnumerable<Friend> GetAllFriends(int? id)
        {
            return NetworkDao.GetAllFriends(id);
        }

        public UserSearch GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetMessagesByFriend(Friend friend)
        {
            return NetworkDao.GetMessagesByFriend(friend);
        }

        public string[] GetRoles(string username)
        {
            return NetworkDao.GetRoles(username);
        }

        public bool IsUserInRole(string username, string roleName)
        {
            return NetworkDao.IsUserInRole(username, roleName);
        }

        public User LogIn(string login, string password)
        {
            return NetworkDao.LogIn(login, password);
        }

        public void RemoveUserById(string username)
        {
            NetworkDao.DeleteFriend(username);
        }

        public IEnumerable<UserSearch> SearchByName(string Name, int? idUser)
        {
            return NetworkDao.SearchByName(Name, idUser);
        }

        public IEnumerable<UserSearch> SearchBySurname(string Surname, int? idUser)
        {
            return NetworkDao.SearchBySurname(Surname, idUser);
        }

        public IEnumerable<UserSearch> SearchByTown(string Town, int? idUser)
        {
            return NetworkDao.SearchByTown(Town, idUser);
        }

        public IEnumerable<UserSearch> SearchByYearOfBirth(int YearOfBirth, int? idUser)
        {
            return NetworkDao.SearchByYearOfBirth(YearOfBirth, idUser);
        }

        public void SendMessage(int userId, int friendId, string message)
        {
            NetworkDao.SendMessage(userId, friendId, message);
        }

        public int SingUp(User user)
        {
            return NetworkDao.SingUp(user);
        }
    }
}