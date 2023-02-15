using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;

namespace ChatAPI.Controllers;

var container = new Container();
container.Register<IUserService, UserService>(Lifestyle.Singleton);