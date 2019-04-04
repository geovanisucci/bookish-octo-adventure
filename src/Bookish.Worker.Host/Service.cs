using System;
using System.Threading;
using System.Threading.Tasks;
using Bookish.Worker.Domain.EntityDomain;
using MassTransit;
using Microsoft.Extensions.Hosting;

namespace Bookish.Worker.Host
{
    public class Service : IHostedService
    {
        private readonly IBusControl _busControl;
        public Service(IBusControl busControl)
        {
            _busControl = busControl;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Service started...");
            await _busControl.Publish(new FooEntity { Id = Guid.NewGuid(), Greeting = "Hello!" });
            await _busControl.StartAsync(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Service finished...");
            await _busControl.StopAsync(cancellationToken);
        }
    }
}