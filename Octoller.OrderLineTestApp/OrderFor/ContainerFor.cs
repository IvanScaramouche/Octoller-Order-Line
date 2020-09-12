using Octoller.OrderLineHandler.Processor;
using Octoller.OrderLineHandler.ServiceObjects;

namespace Octoller.OrderLineTestApp.OrderFor {
    public sealed class ContainerFor : IOrderContainer {

        private static string key = "for";
        public string Key => key;

        public IOrderHandler GetHandler() {
            return new OrderFor();
        }
    }
}
