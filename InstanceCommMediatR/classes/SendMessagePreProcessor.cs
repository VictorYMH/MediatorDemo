using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;

namespace InstanceCommMediatR.classes
{
    public class SendMessagePreProcessor : IRequestPreProcessor<SendMessage>
    {
        public SendMessagePreProcessor()
        {
        }

        public Task Process(SendMessage request, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() =>
            {
                Console.WriteLine("entered pre processor");
                Participant to = request._ChatRoom.Participants[request._To];
                Participant from = request._ChatRoom.Participants[request._From];
                if (from == null || to == null)
                {
                    throw new ArgumentNullException("user not exist");
                }

            }, cancellationToken);
            //return Task.Delay(1000, cancellationToken);
        }
    }
}
