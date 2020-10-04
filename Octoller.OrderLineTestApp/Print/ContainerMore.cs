using Octoller.OrderLineHandler.ServiceObjects;
using Octoller.OrderLineHandler.Processor;

namespace Octoller.OrderLineTestApp {
        public sealed class ContainerMore : BaseHeader<OrderMore> {

            private static string key = "more";
            private static string description =
                "сравнивает два числа и возвращает большее";

            public override string Key {
                get => key;
            }

            public override string Description {
                get => description;
            }
        }
    }
