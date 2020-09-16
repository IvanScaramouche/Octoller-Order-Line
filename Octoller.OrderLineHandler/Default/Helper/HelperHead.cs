using Octoller.OrderLineHandler.Processor;
using Octoller.OrderLineHandler.ServiceObjects;


namespace Octoller.OrderLineHandler.Default.Helper {
    public sealed class HelperHead : IOrderContainer {

        private string key = "help";
        private string description = "Отображает подсказку по всем доступным командам";

        public string Key {
            get => key;
        }

        public string Description {
            get => description;
        }

        public IOrderHandler GetHandler() =>
            new HelperHandler();
    }
}
