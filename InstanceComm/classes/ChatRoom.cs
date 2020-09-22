using System;
using System.Collections.Generic;
using System.Text;

namespace InstanceCommMediator.classes
{
    /// <summary>
    ///
    /// </summary>

    abstract class AbstractChatroom

    {
        public abstract void Register(Participant participant);
        public abstract void Send(
          string from, string to, string message);
        public abstract void SendAll(
            string from, string message);
    }

    /// <summary>
    /// 
    /// </summary>

    class Chatroom : AbstractChatroom

    {
        private Dictionary<string, Participant> _participants =
          new Dictionary<string, Participant>();

        public override void Register(Participant participant)
        {
            if (!_participants.ContainsValue(participant))
            {
                _participants[participant.Name] = participant;
            }

            participant.Chatroom = this;
        }

        public override void Send(
          string from, string to, string message)
        {
            Participant participant = _participants[to];
            if (participant != null)
            {
                participant.Receive(from, message);
            }
            //preprocess
            switch (participant.GetType().Name)
            {
                case "BackEnd":
                    if (participant.Name == "George")
                    {
                        participant.Send("John", "DAMN");
                    }
                    break;
                case "FrontEnd":
                    break;
                default:
                    break;
            }

        }

        public override void SendAll(
  string from, string message)
        {
            throw new NotImplementedException();
        }
    }
}
