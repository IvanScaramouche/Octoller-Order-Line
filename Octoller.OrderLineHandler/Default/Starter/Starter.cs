using Octoller.OrderLineHandler.Processor;
using Octoller.OrderLineHandler.ServiceObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Octoller.OrderLineHandler.Default.Starter {
    public sealed class Starter : IOrderHandler {

        private IOrderHandler next;
        private string errorInfo = null;

        public void Invoke(IChContext context) {
            if (next is null) {
                context.Complite = false;
                context.SetError((errorInfo != null ? errorInfo : "Не установлен стартовый элемент очереди обработки!"));
            } else {
                next.Invoke(context);
            }
        }

        public void SetArgument(params string[] arguments) {

        }

        public void SetErrorInfo(string info) {
            errorInfo = info;
        }

        public void SetNext(IOrderHandler handler) {
            next = handler;
        }
    }
}
