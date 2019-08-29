using System;
using System.Collections.Generic;
using System.Text;

namespace InstanceCommMediatR.classes
{
    /// <summary>
    /// 
    /// </summary>

    public class Participant
    {
        private string _name;
        private ChatRoom _chatroom;

        // Constructor

        public Participant(string name)
        {
            this._name = name;
        }
        

        public string Name
        {
            get { return _name; }
        }
        

        public ChatRoom Chatroom
        {
            set { _chatroom = value; }
            get { return _chatroom; }
        }
        

        public void Send(Participant to, string message)
        {
            to.Receive(this.Name, message);
        }
        

        public virtual void Receive(
          string from, string message)
        {
            Console.WriteLine("{0} to {1}: '{2}'",
              from, Name, message);
        }
    }

    class FrontEnd: Participant
    {
        // Constructor

        public FrontEnd(string name)
          : base(name)
        {
        }

        public override void Receive(
          string from, string message)
        {
            Console.Write("To a FrontEnd: ");
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

        public override void Receive(
            string from, string message)
        {
            Console.Write("To a FrontEnd: ");
            base.Receive(from, message);
        }
    }
}
