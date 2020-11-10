using System.Collections.Generic;

namespace ChatRoomWithMediatR.classes
{
    public abstract class AbstractChatroom
    {
        public abstract void Register(Participant participant);
    }
    public class ChatRoom : AbstractChatroom
    {
        public Dictionary<string, Participant> Participants { get; set; } = new Dictionary<string, Participant>();
        public override void Register(Participant participant)
        {
            if (!Participants.ContainsValue(participant))
            {
                Participants[participant.Name] = participant;
            }

            participant.Chatroom = this;
        }
    }
}
