using Octoller.OrderLineHandler.Processor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Octoller.OrderLineHandler.ServiceObjects {
    public interface IOrderContainer {
        string Key {
            get;
        }

        IOrderHandler GetHandler();
    }
}
