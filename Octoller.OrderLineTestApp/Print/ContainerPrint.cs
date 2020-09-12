using Octoller.OrderLineHandler.Processor;
using Octoller.OrderLineHandler.ServiceObjects;

namespace Octoller.OrderLineTestApp.Print {
    public sealed class ContainerPrint : IOrderContainer {

        private static string key = "print";
        public string Key => key;

        public IOrderHandler GetHandler() {
            return new OrderPrint();
        }
    }
}
