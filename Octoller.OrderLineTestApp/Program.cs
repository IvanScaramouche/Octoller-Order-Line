using Octoller.OrderLineTestApp.OrderFor;
using Octoller.OrderLineTestApp.Print;
using Octoller.OrderLineHandler.Processor;
using System;
using System.Reflection;
using System.Linq;

namespace Octoller.OrderLineTestApp {
    class Program {
        static void Main(string[] args) {
            InputHandler handler = new InputHandler();
            handler.AddOrder(new ContainerPrint());
            handler.AddOrder(new ContainerFor());

            while (true) {

                string line = Console.ReadLine();

                var context = handler.ReadLine(line, new ChContext());

                if (context.Complite) {
                    context.Action();
                }

                if (context.IsError) {
                    Console.WriteLine(context.GetError());
                }
            }
        }
    }
}
