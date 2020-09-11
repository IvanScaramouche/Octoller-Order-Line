using Octoller.OrderLineHandler.Processor;
using Octoller.OrderLineHandler.ServiceObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Octoller.OrderLineTestApp.OrderFor {
    public sealed class OrderFor : IOrderHandler {

        private IOrderHandler next;

        private int? iterate = default;
        private Action printOperation;

        public void Invoke(IChContext context) {
            if (context.IsError || iterate is null || context.Action is null) {
                context.Complite = false;
                context.SetError("Некорректный аргумент.");
            } else {
                printOperation = context.Action;
                context.Action = For;
                context.Complite = true;
            }
            next?.Invoke(context);
        }

        public void SetArgument(params string[] arg) {
            if (arg.Length < 2) {
                if (int.TryParse(arg[0], out int i)) {
                    iterate = i;
                }
            }
        }

        public void SetNext(IOrderHandler handler) {
            next = handler;
        }

        private void For() {
            for (int i = 0; i < iterate; i++) {
                printOperation();
            }
        }
    }
}
