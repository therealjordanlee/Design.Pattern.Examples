using GenericFactory.Entities;

namespace GenericFactory.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private Dictionary<string, AddressEntity> _addresses;

        public AddressRepository()
        {
            _addresses = new Dictionary<string, AddressEntity>
            {
                {"ADD001", new AddressEntity
                           {
                               Street = "1 Fake Street",
                               State = "VIC",
                               PostCode = "3000",
                               Country = "AUSTRALIA",
                           }
                }
            };
        }

        public AddressEntity? GetAddressById(string id)
        {
            return _addresses.ContainsKey(id) ? _addresses[id] : null;
        }
    }
}