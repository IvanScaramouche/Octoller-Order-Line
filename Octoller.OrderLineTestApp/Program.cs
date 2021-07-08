using Octoller.OrderLineHandler.Processor;
using System;

namespace Octoller.OrderLineTestApp
{
    internal class Program
    {
        #region Private Methods

        private static void Main()
        {
            InputHandler handler = new InputHandler();
            handler.AddOrder(new ContainerMore());

            while (true)
            {
                string line = Console.ReadLine();

                var context = handler.ParseOrderLine(line, new ChContext());

                if (context.Complite)
                {
                    context.Action?.Invoke();

                    if (context.IsMessage)
                    {
                        Console.WriteLine(context.GetMessage());
                    }
                }

                if (context.IsError)
                {
                    ConsoleColor oldColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(context.GetError());
                    Console.ForegroundColor = oldColor;
                }
            }
        }

        #endregion Private Methods
    }
}