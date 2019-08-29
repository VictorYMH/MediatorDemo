using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InstanceCommMediatR.classes
{
    public class SendMessage: IRequest<bool>
    {
        //DI
        public SendMessage(ChatRoom chatRoom, string to, string from, string message)
        {
            _ChatRoom = chatRoom;
            _To = to;
            _From = from;
            _Message = message;
        }

        public ChatRoom _ChatRoom { get; }
        
        public string _From { get; }

        public string _To { get; }

        public string _Message { get; }
    }
}
