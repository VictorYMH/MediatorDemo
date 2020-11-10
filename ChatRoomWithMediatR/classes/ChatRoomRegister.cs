using MediatR;

namespace ChatRoomWithMediatR.classes
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
