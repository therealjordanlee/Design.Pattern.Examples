using GenericFactory.Entities;

namespace GenericFactory.Repositories
{
    public interface IAddressRepository
    {
        AddressEntity? GetAddressById(string id);
    }
}