using Octoller.OrderLineHandler.ServiceObjects;

namespace Octoller.OrderLineTestApp {
    public sealed class ContainerMore : BaseHeader<OrderMore> {

        public override string Key {
            get => "more";
        }

        public override string Description {
            get => "сравнивает два числа и возвращает большее";
        }
    }
}
