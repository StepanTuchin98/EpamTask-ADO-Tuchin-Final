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

        public IEnumerable<Friend> GetAllFriends(string username)
        {
            return NetworkDao.GetAllFriends(username);
        }

        public User GetByLogin(string username)
        {
            return NetworkDao.GetByLogin(username);
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

        public IEnumerable<UserSearch> SearchByName(string Name)
        {
            return NetworkDao.SearchByName(Name);
        }

        public IEnumerable<UserSearch> SearchBySurname(string Surname)
        {
            return NetworkDao.SearchBySurname(Surname);
        }

        public IEnumerable<UserSearch> SearchByTown(string Town)
        {
            return NetworkDao.SearchByTown(Town);
        }

        public IEnumerable<UserSearch> SearchByPhone(string Phone)
        {
            return NetworkDao.SearchByPhone(Phone);
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