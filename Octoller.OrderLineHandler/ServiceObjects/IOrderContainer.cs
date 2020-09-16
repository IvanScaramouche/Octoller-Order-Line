using Octoller.OrderLineHandler.Processor;

namespace Octoller.OrderLineHandler.ServiceObjects {
    public interface IOrderContainer {

        string Key {
            get;
        }

        string Description {
            get;
        }

        IOrderHandler GetHandler();
    }
}
