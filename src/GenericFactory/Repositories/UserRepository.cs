using GenericFactory.Entities;

namespace GenericFactory.Repositories
{
    public class UserRepository : IUserRepository
    {
        private Dictionary<string, UserEntity> _users;

        public UserRepository()
        {
            _users = new Dictionary<string, UserEntity>
            {
                {"U001", new UserEntity
                         {
                             FirstName = "John",
                             LastName = "Doe",
                             AddressId = "ADD001"
                         }
                }
            };
        }

        public UserEntity? GetUserById(string id)
        {
            return _users.ContainsKey(id) ? _users[id] : null;
        }
    }
}