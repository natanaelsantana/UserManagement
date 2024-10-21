using System.Collections.Generic;
using UserManagement.Domain;
using UserManagement.Infrastructure;

namespace UserManagement.Application
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public void CreateUser(string name, string email)
        {
            var user = new User { Name = name, Email = email };
            _userRepository.Add(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }

        public void UpdateUser(int id, string name, string email)
        {
            var user = new User { Id = id, Name = name, Email = email };
            _userRepository.Update(user);
        }

        public void DeleteUser(int id)
        {
            _userRepository.Delete(id);
        }
    }
}
