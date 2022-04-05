using GenericFactory.Factories;
using GenericFactory.Models;
using Microsoft.AspNetCore.Mvc;

namespace Design.Pattern.Examples.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private IGenericFactory _genericFactory;

        public UserController(IGenericFactory genericFactory)
        {
            _genericFactory = genericFactory;
        }

        [HttpGet("{id}")]
        public async Task<UserModel> GetUser([FromRoute] string id)
        {
            var userArgs = new UserFactoryArgs { Id = id };
            var user = await _genericFactory.CreateAsync<UserFactoryArgs, UserModel>(userArgs);
            return user;
        }
    }
}