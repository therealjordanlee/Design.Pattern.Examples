using CachedFactory.Factories;
using GenericFactory.Factories;
using GenericFactory.Models;
using GenericFactory.Repositories;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();

// Factories
builder.Services.AddScoped<IGenericFactory, GenericFactory.Factories.GenericFactory>();

// We no longer register the UserFactory as an instance of IGenericFactory<>.
//builder.Services.AddScoped<IGenericFactory<UserFactoryArgs, UserModel>, UserFactory>();

// Instead, we register an instancce of the InMemoryCachcedFactory
builder.Services.AddScoped<IGenericFactory<UserFactoryArgs, UserModel>>(builder =>
{
    var cache = builder.GetRequiredService<IMemoryCache>();
    var factory = new UserFactory(builder.GetRequiredService<IAddressRepository>(),
                                  builder.GetRequiredService<IUserRepository>());
    return new InMemoryCachedFactory<UserFactoryArgs, UserModel>(cache, factory);
});

// Repositories
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();