﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace ChatRoomWithMediatR.classes
{
    public class SendMessageHandler : IRequestHandler<SendMessage, bool>
    {
        private readonly IMediator _mediator;

        public SendMessageHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> Handle(SendMessage request, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                Participant to = request._ChatRoom.Participants[request._To];
                Participant from = request._ChatRoom.Participants[request._From];
                from.Send(to, request._Message);
                return true;
            }, cancellationToken);
        }
    }
}
