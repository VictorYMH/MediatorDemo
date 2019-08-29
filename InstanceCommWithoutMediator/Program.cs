using InstanceCommWithoutMediator.classes;
using System;

namespace InstanceCommWithoutMediator
{
    class Program
    {
        static void Main(string[] args)
        {

            FrontEnd Shane = new FrontEnd("Shane");
            FrontEnd Kristen = new FrontEnd("Kristen");
            BackEnd Issac = new BackEnd("Issac");
            BackEnd Victor = new BackEnd("Victor");

            Shane.Send(Issac, "You Idiot");
            Kristen.Send(Shane, "message 1");
            Issac.Send(Victor, "message 2");
            Victor.Send(Shane, "message 3");
            Console.ReadKey();
        }
    }
}
