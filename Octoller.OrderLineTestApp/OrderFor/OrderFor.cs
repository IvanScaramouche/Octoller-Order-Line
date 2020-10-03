using Octoller.OrderLineHandler.ServiceObjects;
using Octoller.OrderLineHandler.Processor;
using System;

namespace Octoller.OrderLineTestApp {
    public sealed class OrderFor : IOrderHandler {

        private int? iterate = default;
        private Action printOperation;

        public bool Invoke(IChContext context) {
            if (iterate is null || context.Action is null) {
                context.Complite = false;
                context.SetError("Некорректный аргумент.");
                return false;
            } else {
                printOperation = context.Action;
                context.Action = For;
                context.Complite = true;
                return true;
            }
        }

        public void SetArgument(params string[] arg) {
            if (arg.Length < 2) {
                if (int.TryParse(arg[0], out int i)) {
                    iterate = i;
                }
            }
        }

        private void For() {
            for (int i = 0; i < iterate; i++) {
                printOperation();
            }
        }
    }
}
