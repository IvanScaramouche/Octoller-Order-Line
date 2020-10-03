using Octoller.OrderLineHandler.ServiceObjects;
using Octoller.OrderLineHandler.Processor;

namespace Octoller.OrderLineTestApp {
        public sealed class ContainerMore : IOrderHeader {

            private static string key = "more";
            private static string description =
                "сравнивает два числа и возвращает большее";

            public string Key {
                get => key;
            }

            public string Description {
                get => description;
            }

            public IOrderHandler GetHandler() {
                return new OrderMore();
            }
        }
    }
