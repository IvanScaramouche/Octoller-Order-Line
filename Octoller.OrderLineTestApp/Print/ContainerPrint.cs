using Octoller.OrderLineHandler.ServiceObjects;
using Octoller.OrderLineHandler.Processor;

namespace Octoller.OrderLineTestApp {
    public sealed class ContainerPrint : IOrderContainer {

        private static string key = "print";
        private static string description = 
            "Выводит на экран строку переданную во входном параметре команды";

        public string Key {
            get => key;
        }

        public string Description {
            get => description;
        }

        public IOrderHandler GetHandler() {
            return new OrderPrint();
        }
    }
}
