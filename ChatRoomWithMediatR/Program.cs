using System;
using System.Threading.Tasks;
using ChatRoomWithMediatR.classes;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ChatRoomWithMediatR
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

            FrontEnd Nancy = new FrontEnd("Nancy");
            FrontEnd Andrew = new FrontEnd("Andrew");
            BackEnd Janet = new BackEnd("Janet");
            BackEnd Michael = new BackEnd("Michael");

            await mediator.Send(new ChatRoomRegister(SSWGroup, Nancy));
            await mediator.Send(new ChatRoomRegister(SSWGroup, Andrew));
            await mediator.Send(new ChatRoomRegister(SSWGroup, Janet));
            await mediator.Send(new ChatRoomRegister(SSWGroup, Michael));

            await mediator.Send(new SendMessage(SSWGroup, "Nancy", "Andrew", "You Idiot"));
            await mediator.Send(new SendMessage(SSWGroup, "Andrew", "Janet", "message 1"));
            await mediator.Send(new SendMessage(SSWGroup, "Janet", "Michael", "message 2"));
            await mediator.Send(new SendMessage(SSWGroup, "Michael", "Nancy", "message 3"));

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
