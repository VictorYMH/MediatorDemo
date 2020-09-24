using InstanceCommWithoutMediator.classes;
using System;

namespace InstanceCommWithoutMediator
{
    class Program
    {
        static void Main(string[] args)
        {

            FrontEnd Nancy = new FrontEnd("Nancy");
            FrontEnd Andrew = new FrontEnd("Andrew");
            BackEnd Janet = new BackEnd("Janet");
            BackEnd Michael = new BackEnd("Michael");

            Nancy.Send(Janet, "You Idiot");
            Andrew.Send(Nancy, "message 1");
            Janet.Send(Michael, "message 2");
            Michael.Send(Andrew, "message 3");
            Console.ReadKey();
        }
    }
}
