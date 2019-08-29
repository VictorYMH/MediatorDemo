using InstanceCommMediator.classes;
using System;

namespace InstanceCommMediator
{
    /// <summary>

    /// 模式 （对象间显式地相互引用）
    /// 1. 考虑中介者实例, 在不同的聊天室实例中可以存在不同的聊天格式
    /// 2. 考虑实例的通信规范，只允许同一聊天室实例中的成员通信
    /// 3. 相较于对象间直接通信，
    ///     存在中介者的程序使用中介者的来调用实例的Receive方法，从而集中类间的沟通逻辑
    ///     无中介者的程序需要传入收件人的实例以调用对应实例的Receive方法
    /// 4. 考虑更加复杂的通信，在某个对象的事件产生（方法调用）时需要去操作其它多个对象，而操作以及调用的逻辑则写入到mediator中
    /// 
    /// 功能
    /// 5. 考虑群发功能，较于在中介者实例中注册与在外部注册
    /// 6. 发送前验证方法
    
    /// Mediator Design Pattern.

    /// </summary>

    class MainApp
    {
        static void Main()
        {

            Chatroom SSWGroup = new Chatroom();
            
            FrontEnd Shane = new FrontEnd("Shane");
            FrontEnd Kristen = new FrontEnd("Kristen");
            BackEnd Issac = new BackEnd("Issac");
            BackEnd Victor = new BackEnd("Victor");

            SSWGroup.Register(Shane);
            SSWGroup.Register(Kristen);
            SSWGroup.Register(Issac);
            SSWGroup.Register(Victor);

            Shane.Send("Issac", "You Idiot");
            Kristen.Send("Shane", "message 1");
            Issac.Send("Victor", "message 2");
            Victor.Send("Kristen", "message 3");

            Console.ReadKey();
        }
    }
    
}
