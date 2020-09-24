using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InstanceCommMediatR.classes
{
    public class SendMessagePreProcessor : IRequestPreProcessor<SendMessage>
    {
        //private readonly TextWriter _writer;

        public SendMessagePreProcessor()//TextWriter writer)
        {
            //_writer = writer;
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

            },cancellationToken);
            //return Task.Delay(1000, cancellationToken);
        }
    }
}
