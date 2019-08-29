using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InstanceCommMediatR.classes
{

    public class ChatRoomRegisterHandler : IRequestHandler<ChatRoomRegister, bool>
    {
        private readonly IMediator _mediator;

        public ChatRoomRegisterHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> Handle(ChatRoomRegister request, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                request._ChatRoom.Register(request._Participant);
                return true;
            }, cancellationToken);
        }
    }
}
