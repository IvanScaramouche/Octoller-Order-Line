/*
 * ***************************************************************************************
 * 
 * Octoller.LineCommander
 * 25.08.2020
 *  
 *****************************************************************************************  
 */

using Octoller.OrderLineHandler.ServiceObjects;
using Octoller.OrderLineHandler.Default;
using System.Collections.Generic;
using System;

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

        private IChContext FollowСhainOrders(Queue<OrderContainer> orderQueue, IChContext context) {
            OrderContainer order = orderQueue.Dequeue();
            ICallLinked previousLink = starter;
            TransitionSign nextSign = TransitionSign.None;

            while (order != null) {
                if (orderHeaders.TryGetValue(order.Order, out IOrderHeader header)) {

                    ICallLinked nextLink = new CallLink();
                    IOrderHandler curentHandler = header.GetHandler();

                    if (curentHandler is HelperHandler helpHand) {
                        helpHand.SetArgument(orderHeaders);
                        curentHandler = helpHand;
                    }

                    nextLink.PrepareHandler(curentHandler, order.Arguments);
                    previousLink.SetNext(nextLink, nextSign);
                    previousLink = nextLink;
                    nextSign = order.Sign;
                } else {
                    context.Complite = false;
                    context.SetError("Input command name error");
                    return context;
                }

                try {
                    order = orderQueue.Dequeue();
                } catch {
                    break;
                } 
            }
            return starter.RunHandler(context);
        }
    }
}
