/*
 * ***************************************************************************************
 * 
 * Octoller.LineCommander
 * 25.08.2020
 *  
 *****************************************************************************************  
 */

using Octoller.OrderLineHandler.ServiceObjects;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Octoller.OrderLineHandler.Processor {
    public sealed class OrderListCreator {

        private readonly string spaceSeparator = " ";
        private readonly string orderSeparator = ":";
        private readonly string argSeparator = ",";

        private Dictionary<string, TransitionSign> transitionSeparator = 
            new Dictionary<string, TransitionSign> {
            ["&"] = TransitionSign.NextAny, 
            ["&&"] = TransitionSign.NextTrue, 
            ["||"] = TransitionSign.NextFalse
        };

        public OrderListCreator() { }

        public Queue<OrderContainer> Parse(string input) {
            string[] advance = LineSplit(input, spaceSeparator);
            Queue<OrderContainer> resultQueue = new Queue<OrderContainer>();

            for (int i = 0; i < advance.Length; i++) {
                string[] lineOrder = LineSplit(advance[i], orderSeparator);
                string nameOrder = lineOrder[0];

                List<string> arguments = default;
                if (lineOrder.Length > 1) {
                    arguments = LineSplit(lineOrder[1], argSeparator)
                        .ToList();
                }

                int next = i + 1;
                if (next < advance.Length) {
                    if (transitionSeparator.ContainsKey(advance[next])) {
                        resultQueue.Enqueue(new OrderContainer(nameOrder, 
                            arguments?.ToArray(), 
                            transitionSeparator[advance[next]]));
                        i = next;
                    } else {
                        throw new ArgumentException("Ошибка в строке команды");
                    }
                } else {
                    resultQueue.Enqueue(new OrderContainer(nameOrder, 
                        arguments?.ToArray()));
                }
            }
            return resultQueue;
        }

        private string[] LineSplit(string line, string separator) =>
            line.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries)
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .ToArray();

        private string[] LineSplit(string line, char separator) =>
            line.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries)
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .ToArray();
    }
}

