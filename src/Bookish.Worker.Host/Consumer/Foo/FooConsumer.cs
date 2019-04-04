using System;
using System.Threading.Tasks;
using Bookish.Worker.Domain.BusinessDomain.Foo.Interface;
using Bookish.Worker.Domain.EntityDomain;
using MassTransit;

namespace Bookish.Worker.Host.Consumer.Foo
{
    public class FooConsumer : IConsumer<FooEntity>
    {
        private readonly IFooBusiness _business;

        public FooConsumer(IFooBusiness business)
        {
            _business = business;
        }
        public Task Consume(ConsumeContext<FooEntity> context)
        {
            return Task.Run(async () =>
            {
                await Console.Out.WriteLineAsync("Receiving message . . .");
                await _business.ShowGreeting(context.Message);
            });
        }
    }
}