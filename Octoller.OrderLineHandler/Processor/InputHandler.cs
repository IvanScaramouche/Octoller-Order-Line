﻿using Octoller.OrderLineHandler.Default.Starter;
using Octoller.OrderLineHandler.ServiceObjects;
using Octoller.OrderLineHandler.Collections;
using System.Collections.Generic;
using Octoller.OrderLineHandler.Default.Helper;

namespace Octoller.OrderLineHandler.Processor {
    public sealed class InputHandler {

        private Dictionary<string, IOrderContainer> orderContainers =
            new Dictionary<string, IOrderContainer>();

        private OrderListCreator creator;

        private static Starter starter;
        static InputHandler() => starter = new Starter();

        public InputHandler() {
            creator = new OrderListCreator();
            AddOrder(new HelperHead());
            ///TODO: добавить возможность установки своих разделителей для комманд и аргументов
            ///TODO: установка разделителей через строку json 
        }

        public void AddOrder(IOrderContainer orderContainer) {
            if (orderContainer != null) {
                orderContainers.Add(orderContainer.Key, orderContainer);
            }
        }

        public IChContext ReadLine(string input, IChContext context) {
            var list = creator.Parse(input);

            if (!list.Empty) {
                CreateChain(list);
                starter?.Invoke(context);
            } else {
                context.Complite = false;
                context.SetError("Неверная, либо пустая входная строка комманд");
            }
            return context;
        }

        private void CreateChain(OrderList line) {
            IOrderHandler handler = starter;
            SimpleOrder order = line.GetNext();

            while (order != null) {
                if (orderContainers.TryGetValue(order.Order, out IOrderContainer value)) {
                    var temp = value.GetHandler();
                    temp.SetArgument(order.Arguments);
                    if (temp is HelperHandler hh) {
                        hh.SetArgument(orderContainers);
                        temp = hh;
                    }
                    handler.SetNext(temp);
                    handler = temp;
                } else {
                    starter.SetNext(null);
                    starter.SetErrorInfo("Ошибка в входной строке комманды");
                    break;
                }
                order = line.GetNext();
            }
        }
    }
}
