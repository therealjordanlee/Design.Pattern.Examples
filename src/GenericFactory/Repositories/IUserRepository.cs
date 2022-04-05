using GenericFactory.Entities;

namespace GenericFactory.Repositories
{
    public interface IUserRepository
    {
        UserEntity? GetUserById(string id);
    }
}