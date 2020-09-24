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
            //preprocess
            Console.WriteLine("entered pre processor");

            if (_participants[to] != null)
            {
                _participants[to].Receive(from, message);
            }
        }

        public override void SendAll(
  string from, string message)
        {
            throw new NotImplementedException();
        }
    }
}
