using Octoller.OrderLineHandler.ServiceObjects;

namespace Octoller.OrderLineTestApp
{
    public sealed class ContainerMore : BaseHeader<OrderMore>
    {
        #region Public Properties

        public override string Description
        {
            get => "сравнивает два числа и возвращает большее";
        }

        public override string Key
        {
            get => "more";
        }

        #endregion Public Properties
    }
}