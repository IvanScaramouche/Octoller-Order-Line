using Octoller.OrderLineHandler.ServiceObjects;
using Octoller.OrderLineHandler.Processor;

namespace Octoller.OrderLineTestApp {
    public sealed class ContainerFor : BaseHeader<OrderFor> {

        private static string key = "for";
        private static string description = 
            "Выполняет команду повторное число раз заданное во входном параметре";

        public override string Key {
            get => key;
        }

        public override string Description {
            get => description;
        }
    }
}
