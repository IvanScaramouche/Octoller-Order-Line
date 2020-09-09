using Octoller.OrderLineTestApp.Default.OrderFor;
using Octoller.OrderLineTestApp.Default.Print;
using Octoller.OrderLineHandler.Processor;
using System;

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
