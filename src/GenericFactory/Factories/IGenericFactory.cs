namespace GenericFactory.Factories
{
    public interface IGenericFactory<TModelArgs, TModel>
    {
        Task<TModel> CreateAsync(TModelArgs args, CancellationToken cancellationToken = default);
    }

    public interface IGenericFactory
    {
        Task<TModel> CreateAsync<TModelArgs, TModel>(TModelArgs args, CancellationToken cancellationToken = default);
    }
}