using System;
using System.Threading.Tasks;
using Bookish.Worker.Domain.BusinessDomain.Foo.Interface;
using Bookish.Worker.Domain.EntityDomain;

namespace Bookish.Worker.Domain.BusinessDomain.Foo.Implementation
{
    public class FooBusiness : IFooBusiness
    {
        public async Task ShowGreeting(FooEntity entity)
        {
             await Console.Out.WriteLineAsync($"Id: {entity.Id.ToString()} Greeting: {entity.Greeting}");
        }
    }
} 