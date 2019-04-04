using System;
using System.Threading.Tasks;
using Bookish.Worker.Domain.BusinessDomain.Foo.Implementation;
using Bookish.Worker.Domain.BusinessDomain.Foo.Interface;
using Bookish.Worker.Host.Consumer;
using Bookish.Worker.Host.Consumer.Foo;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bookish.Worker.Host
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var hostBuilder = new HostBuilder()
             .ConfigureServices((hostContext, services) =>
            {
                //Configuring MassTransit Message BUS
                services.AddMassTransit(c =>
                {
                    //Add Foo Consumer
                    c.AddConsumer<FooConsumer>();

                    c.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                    {
                        var host = cfg.Host(new Uri("rabbitmq://172.17.0.2"), h =>
                        {
                            
                            h.Username("guest");
                            h.Password("guest");
                        });

                        //Configure some consumer to queue.
                        cfg.ReceiveEndpoint(host, "bookish-foo", e =>
                        {
                            e.ConfigureConsumer<FooConsumer>(provider);
                        });
                    }));

                    services.AddScoped<IHostedService, Service>();
                    services.AddScoped<IFooBusiness, FooBusiness>();

                });
            });

               await hostBuilder.RunConsoleAsync();
        }
    }
}

