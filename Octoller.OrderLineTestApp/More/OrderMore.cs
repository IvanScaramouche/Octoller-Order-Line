using Octoller.OrderLineHandler.ServiceObjects;
using Octoller.OrderLineHandler.Processor;
using System.Collections.Generic;
using System.Linq;

namespace Octoller.OrderLineTestApp {
    public sealed class OrderMore : IOrderHandler {

        private int[] numbers = null;
        private bool isError = false;

        public bool Invoke(ref IChContext context) {
            if (isError) {
                context.Complite = false;
                context.SetError("Invalid argument.");
                return false;
            } else {
                context.Complite = true;
                int max = numbers.Max();
                System.Console.WriteLine(max);
                return true;
            }
        }

        public void SetArgument(params string[] arg) {
            if (arg != null && arg.Length > 0) {
                List<int> temp = new List<int>();
                foreach (var a in arg) {
                    if (int.TryParse(a, out int i)) {
                        temp.Add(i);
                    } else {
                        isError = true;
                        break;
                    }
                }
                numbers = temp.ToArray();
            } else {
                isError = true;
            }
        }
    }
}
