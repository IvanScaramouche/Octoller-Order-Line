using Octoller.OrderLineHandler.ServiceObjects;
using Octoller.OrderLineHandler.Processor;
using System.Collections.Generic;
using System.Text;

namespace Octoller.OrderLineHandler.Default {
    public sealed class HelperHandler : IOrderHandler {

        private IOrderHandler next;
        private StringBuilder orderHelpList;

        public void Invoke(IChContext context) {
            context.Action = PrintHelp;
            context.Complite = true;
            next?.Invoke(context);
        }

        public void SetArgument(Dictionary<string, IOrderContainer> containers) {
            if (containers != null && containers.Count > 0) {
                orderHelpList = new StringBuilder();
                foreach (var container in containers.Values) {
                    var simpleString = $" #: {container.Key} \t {container.Description} \n";
                    orderHelpList.Append(simpleString);
                }
            }
        }

        public void SetArgument(params string[] arg) {
            return;
        }

        public void SetNext(IOrderHandler handler) =>
            next = handler;

        private void PrintHelp() {
            System.Console.WriteLine(orderHelpList.ToString());
        }
    }
}
