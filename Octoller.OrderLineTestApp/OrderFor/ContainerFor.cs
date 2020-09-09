using Octoller.OrderLineHandler.Processor;
using Octoller.OrderLineHandler.ServiceObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Octoller.OrderLineTestApp.Default.OrderFor {
    public sealed class ContainerFor : IOrderContainer {

        private static string key = "for";
        public string Key => key;

        public IOrderHandler GetHandler() {
            return new OrderFor();
        }
    }
}
