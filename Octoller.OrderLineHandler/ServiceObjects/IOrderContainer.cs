using Octoller.OrderLineHandler.Processor;

namespace Octoller.OrderLineHandler.ServiceObjects {
    public interface IOrderContainer {
        string Key {
            get;
        }

        IOrderHandler GetHandler();
    }
}
