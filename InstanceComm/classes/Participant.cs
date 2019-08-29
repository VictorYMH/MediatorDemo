using System;
using System.Collections.Generic;
using System.Text;

namespace InstanceCommMediator.classes
{

    class Participant

    {
        private Chatroom _chatroom;
        private string _name;

        // Constructor

        public Participant(string name)
        {
            this._name = name;
        }
        

        public string Name
        {
            get { return _name; }
        }
        

        public Chatroom Chatroom
        {
            set { _chatroom = value; }
            get { return _chatroom; }
        }
        

        public void Send(string to, string message)
        {
            _chatroom.Send(_name, to, message);
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
