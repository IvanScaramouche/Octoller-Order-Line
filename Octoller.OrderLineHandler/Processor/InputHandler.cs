/*
 * ***************************************************************************************
 * 
 * Octoller.LineCommander
 * 25.08.2020
 *  
 *****************************************************************************************  
 */

using Octoller.OrderLineHandler.ServiceObjects;
using Octoller.OrderLineHandler.Wrappers;
using Octoller.OrderLineHandler.Default;
using System.Collections.Generic;

namespace Octoller.OrderLineHandler.Processor {
    public sealed class InputHandler {

        private Dictionary<string, IOrderHeader> orderHeaders =
            new Dictionary<string, IOrderHeader>();

        private OrderListCreator creator;
        private static Starter starter;

        static InputHandler() => starter = new Starter();

        public InputHandler() {
            creator = new OrderListCreator();
            AddOrder(new HelperHead());
            ///TODO: добавить возможность установки своих разделителей для комманд и аргументов
        }

        public void AddOrder(IOrderHeader orderContainer) {
            if (orderContainer != null) {
                orderHeaders.Add(orderContainer.Key, orderContainer);
            }
        }

        public IChContext ParseOrderLine(string input, IChContext context) {
            var orderQueue = creator.Parse(input);

            if (orderQueue.Count == 0) {
                context.Complite = false;
                context.SetError("Invalid or empty input string");
                return context;
            }

            return FollowСhainOrders(orderQueue, context);
        }

        private IChContext FollowСhainOrders(QueueWrap orderQueue, IChContext context) {
            QueueWrap queue = orderQueue;
            ParseElement parseElement = queue.Dequeue();
            IExecution previousLink = starter;
            TransitionSign nextSign = TransitionSign.None;

            while (!parseElement.IsNull) {
                if (orderHeaders.TryGetValue(parseElement.OrderName, out IOrderHeader header)) {

                    IExecution nextLink = new ExecutionСontainer();
                    IOrderHandler curentHandler = header.GetHandler(parseElement.Arguments);

                    if (curentHandler is HelperHandler helpHand) {
                        helpHand.SetArgument(orderHeaders);
                        curentHandler = helpHand;
                    }

                    nextLink.PrepareHandler(curentHandler);
                    previousLink.SetNext(nextLink, nextSign);
                    previousLink = nextLink;
                    nextSign = parseElement.Sign;
                } else {
                    context.Complite = false;
                    context.SetError("Input command name error");
                    return context;
                }

                parseElement = queue.Dequeue();
            }
            return starter.RunHandler(context);
        }
    }
}
