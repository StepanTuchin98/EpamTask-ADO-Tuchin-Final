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

        public IEnumerable<Message> GetMessagesByFriend(User friend)
        {
            throw new NotImplementedException();
        }

        public string GetRole(int? id)
        {
            throw new NotImplementedException();
        }

        public void RemoveUserById(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserSearch> SearchByName(string Name, int? idUser)
        {
            return NetworkDao.SearchByName(Name, idUser);
        }

        public IEnumerable<UserSearch> SearchBySurname(string Surname, int? idUser)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserSearch> SearchByTown(string Town, int? idUser)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserSearch> SearchByYearOfBirth(int YearOfBirth, int? idUser)
        {
            throw new NotImplementedException();
        }

        public int SingUp(User user)
        {
            return NetworkDao.SingUp(user);
        }
    }
}
