
namespace Octoller.OrderLineHandler.ServiceObjects {
    public class SimpleOrder {

        private string order;
        private string[] arguments;

        public string Order {
            get => order;
            private set => order = value;
        }

        public string[] Arguments {
            get => arguments;
            private set {
                arguments = value;
            }
        }

        public bool EmptyArguments {
            get => (arguments is null) || (arguments.Length == 0); 
        }

        public SimpleOrder(string order) : this (order, null) { }

        public SimpleOrder(string order, string[] arguments) {
            Order = order;
            Arguments = arguments;
        }
    }
}
