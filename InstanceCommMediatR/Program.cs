using System;
using System.Threading.Tasks;
using InstanceCommMediatR.classes;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace InstanceCommMediatR
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var mediator = BuildMediator();
            var demoTask = DemoRunAsync(mediator);

            Console.ReadKey();
        }

        private static async Task DemoRunAsync(IMediator mediator)
        {
            ChatRoom SSWGroup = new ChatRoom();

            FrontEnd Shane = new FrontEnd("Shane");
            FrontEnd Kristen = new FrontEnd("Kristen");
            BackEnd Issac = new BackEnd("Issac");
            BackEnd Victor = new BackEnd("Victor");

            await mediator.Send(new ChatRoomRegister(SSWGroup, Shane));
            await mediator.Send(new ChatRoomRegister(SSWGroup, Kristen));
            await mediator.Send(new ChatRoomRegister(SSWGroup, Issac));
            await mediator.Send(new ChatRoomRegister(SSWGroup, Victor));

            await mediator.Send(new SendMessage(SSWGroup, "Shane", "Kristen", "You Idiot"));
            await mediator.Send(new SendMessage(SSWGroup, "Kristen", "Issac", "message 1"));
            await mediator.Send(new SendMessage(SSWGroup, "Issac", "Victor", "message 2"));
            await mediator.Send(new SendMessage(SSWGroup, "Victor", "Shane", "message 3"));

        }
        private static IMediator BuildMediator()
        {
            var services = new ServiceCollection();

            services.AddScoped<ServiceFactory>(p => p.GetService);//Pipeline

            //services.AddScoped(typeof(IMediator), typeof(Mediator));
            //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            //servicesCollection.AddScoped(typeof(IRequestPreProcessor<SendMessage>), typeof(GenericRequestPreProcessor<SendMessage>));

            //https://www.c-sharpcorner.com/article/using-asimplementedinterfaces/
            services.Scan(scan => scan
                .FromAssembliesOf(typeof(IMediator), typeof(SendMessage))
                .AddClasses()
                .AsImplementedInterfaces());

            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider.GetRequiredService<IMediator>();
        }
    }
}
