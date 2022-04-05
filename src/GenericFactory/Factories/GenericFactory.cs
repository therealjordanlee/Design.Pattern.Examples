using Microsoft.Extensions.DependencyInjection;

namespace GenericFactory.Factories
{
    public class GenericFactory : IGenericFactory
    {
        private readonly IServiceProvider _provider;

        public GenericFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task<TModel?> CreateAsync<TModelArgs, TModel>(TModelArgs args, CancellationToken cancellationToken = default)
        {
            var factory = _provider.GetService<IGenericFactory<TModelArgs, TModel>>();
            return await factory.CreateAsync(args);
        }
    }
}