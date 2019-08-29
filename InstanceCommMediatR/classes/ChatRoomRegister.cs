using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstanceCommMediatR.classes
{
    public class ChatRoomRegister : IRequest<bool>
    {
        public ChatRoomRegister(ChatRoom chatRoom, Participant participant)
        {
            _ChatRoom = chatRoom;
            _Participant = participant;
        }

        public ChatRoom _ChatRoom { get; }

        public Participant _Participant { get; }
    }

}
