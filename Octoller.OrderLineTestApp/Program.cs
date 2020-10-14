using Octoller.OrderLineHandler.Processor;
using System;

namespace Octoller.OrderLineTestApp {

    class Program {

        static void Main() {

            InputHandler handler = new InputHandler();
            handler.AddOrder(new ContainerMore());

            while (true) {

                string line = Console.ReadLine();

                var context = handler.ParseOrderLine(line, new ChContext());

                if (context.Complite) {

                    context.Action?.Invoke();

                    if (context.IsMessage) {

                        Console.WriteLine(context.GetMessage());
                    }
                }

                if (context.IsError) {

                    Console.WriteLine(context.GetError());
                }
            }
        }
    }
}
