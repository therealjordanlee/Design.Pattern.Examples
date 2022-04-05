using GenericFactory.Models;
using GenericFactory.Repositories;

namespace GenericFactory.Factories
{
    public class UserFactory : IGenericFactory<UserFactoryArgs, UserModel>
    {
        private IAddressRepository _addressRepository;
        private IUserRepository _userRepository;

        public UserFactory(IAddressRepository addressRepository, IUserRepository userRepository)
        {
            _addressRepository = addressRepository;
            _userRepository = userRepository;
        }

        public Task<UserModel> CreateAsync(UserFactoryArgs args, CancellationToken cancellationToken = default)
        {
            var user = _userRepository.GetUserById(args.Id);
            var address = _addressRepository.GetAddressById(user.AddressId);
            var userModel = new UserModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = $"{address.Street} {address.State} {address.PostCode} {address.Country}"
            };

            return Task.FromResult(userModel);
        }
    }
}