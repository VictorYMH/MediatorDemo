using System;
using ChatRoomWithMediator.classes;

namespace ChatRoomWithMediator
{
    /// <summary>

    /// 模式 （对象间显式地相互引用）
    /// 1. 中介者实例, 在不同的聊天室实例中可以存在不同的聊天格式
    /// 2. 实例的通信规范，只允许同一聊天室实例中的成员通信
    /// 3. 相较于对象间直接通信，
    ///     存在中介者的程序使用中介者的来调用实例的Receive方法，从而集中类间的沟通逻辑
    ///     无中介者的程序需要传入收件人的实例以调用对应实例的Receive方法
    /// 4. 考虑更加复杂的通信，在某个对象的事件产生（方法调用）时需要去操作其它多个对象，而操作以及调用的逻辑则写入到mediator中

    /// </summary>

    class MainApp
    {
        static void Main()
        {

            Chatroom SSWGroup = new Chatroom();

            FrontEnd Nancy = new FrontEnd("Nancy");
            FrontEnd Andrew = new FrontEnd("Andrew");
            BackEnd Janet = new BackEnd("Janet");
            BackEnd Michael = new BackEnd("Michael");

            SSWGroup.Register(Nancy);
            SSWGroup.Register(Andrew);
            SSWGroup.Register(Janet);
            SSWGroup.Register(Michael);

            Nancy.Send("Janet", "Idiot");
            Andrew.Send("Nancy", "message 1");
            Janet.Send("Michael", "message 2");
            Michael.Send("Andrew", "message 3");

            Console.ReadKey();
        }
    }

}
