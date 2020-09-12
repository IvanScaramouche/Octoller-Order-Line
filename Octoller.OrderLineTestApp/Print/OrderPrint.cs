using Octoller.OrderLineHandler.Processor;
using Octoller.OrderLineHandler.ServiceObjects;
using System;
using System.Text;

namespace Octoller.OrderLineTestApp.Print {
    public sealed class OrderPrint : IOrderHandler {

        private IOrderHandler next;

        private string text = default;

        public void Invoke(IChContext context) {
            if (context.IsError || text is null || text.Length == 0) {
                context.Complite = false;
                context.SetError("Некорректный аргумент.");
            } else {
                context.Complite = true;
                context.Action = GetPrint;
            }

            next?.Invoke(context);
        }

        public void SetArgument(params string[] arg) {
            if (arg != null) {
                var stringBuilder = new StringBuilder();
                foreach (var s in arg) {
                    stringBuilder.Append(s);
                }

                text = stringBuilder.ToString();
            }
        }

        public void SetNext(IOrderHandler handler) {
            next = handler;
        }

        private void GetPrint() =>
            Console.WriteLine(text);
    }
}
