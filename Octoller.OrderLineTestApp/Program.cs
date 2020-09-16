using Octoller.OrderLineHandler.Processor;
using Octoller.OrderLineTestApp.OrderFor;
using Octoller.OrderLineTestApp.Print;
using System;

namespace Octoller.OrderLineTestApp {
    class Program {
        static void Main() {

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

                context.Clear();
            }
        }
    }
}
