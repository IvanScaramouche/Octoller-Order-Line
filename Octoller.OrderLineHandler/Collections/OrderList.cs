using Octoller.OrderLineHandler.ServiceObjects;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Octoller.OrderLineHandler.Collections {
    public sealed class OrderList : IEnumerable<SimpleOrder> {

        private Stack<SimpleOrder> orders = new Stack<SimpleOrder>();

        public int Count {
            get => orders.Count;
        }

        public bool Empty {
            get => (orders is null) || (orders.Count == 0);
        }

        public void Add(SimpleOrder order) {
            if (order != null) {
                orders.Push(order);
            }
        }

        public void AddRange(SimpleOrder[] array) {
            foreach (var order in array) {
                orders.Push(order);
            }
        }

        public SimpleOrder GetNext() {
            if (orders.Count > 0) {
                return orders.Pop();
            }

            return null;
        }

        public IEnumerator<SimpleOrder> GetEnumerator() =>
            orders.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            this.GetEnumerator();

    }
}
