using System;

namespace InstanceCommMediator.classes
{

    class Participant
    {
        // Constructor
        public Participant(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public Chatroom Chatroom { set; get; }

        public void Send(string to, string message)
        {
            Chatroom.Send(Name, to, message);
        }

        public virtual void Receive(
          string from, string message)
        {
            Console.WriteLine("{0} to {1}: '{2}'",
              from, Name, message);
        }
    }

    class FrontEnd : Participant
    {
        // Constructor
        public FrontEnd(string name)
          : base(name)
        {
        }

        public override void Receive(string from, string message)
        {
            Console.Write("To a FontEnd: ");
            base.Receive(from, message);
        }
    }


    class BackEnd : Participant
    {
        // Constructor

        public BackEnd(string name)
          : base(name)
        {
        }

        public override void Receive(string from, string message)
        {
            Console.Write("To a BackEnd: ");
            base.Receive(from, message);
        }
    }
}
