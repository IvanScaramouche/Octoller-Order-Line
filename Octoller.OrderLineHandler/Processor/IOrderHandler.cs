using Octoller.OrderLineHandler.ServiceObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Octoller.OrderLineHandler.Processor {
    public interface IOrderHandler {
        void Invoke(IChContext context);
        void SetNext(IOrderHandler handler);
        void SetArgument(params string[] arg);
    }
}
