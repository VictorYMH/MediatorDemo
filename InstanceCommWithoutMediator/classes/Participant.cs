using System;
using System.Collections.Generic;
using System.Text;

namespace InstanceCommWithoutMediator.classes
{
    /// <summary>
    /// 
    /// </summary>

    class Participant
    {
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

    /// <summary>
    /// 考虑三个不同的类的实例
    /// a有bcd三个类有调用 
    /// 1. 发布一个任务 简单调用b即可 
    /// 2. 调用b前需要先调用c 
    /// 3. b中的方法调用了d
    /// 普遍的解决方式是1. 在类中调用 2. 编写子类 在子类中写新方法调用
    /// 而这些逻辑应包含在中介者中
    /// 若A类实例a需要对b的调用较于c有不同的逻辑 （比如需要调用b时必须要先调用d中的方法）
    /// 则需要在A内修改，当数量逻辑增大，A则变得越来越臃肿
    /// </summary>
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
            Console.Write("To a BackEnd: ");
            base.Receive(from, message);
        }
    }
}
