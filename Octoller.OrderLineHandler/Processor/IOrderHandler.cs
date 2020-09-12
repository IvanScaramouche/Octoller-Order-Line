using Octoller.OrderLineHandler.ServiceObjects;

namespace Octoller.OrderLineHandler.Processor {
    public interface IOrderHandler {
        void Invoke(IChContext context);
        void SetNext(IOrderHandler handler);
        void SetArgument(params string[] arg);
    }
}
