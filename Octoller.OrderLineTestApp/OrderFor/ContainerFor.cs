﻿using Octoller.OrderLineHandler.ServiceObjects;
using Octoller.OrderLineHandler.Processor;

namespace Octoller.OrderLineTestApp {
    public sealed class ContainerFor : IOrderHeader {

        private static string key = "for";
        private static string description = 
            "Выполняет команду повторное число раз заданное во входном параметре";

        public string Key {
            get => key;
        }

        public string Description {
            get => description;
        }

        public IOrderHandler GetHandler() {
            return new OrderFor();
        }
    }
}
