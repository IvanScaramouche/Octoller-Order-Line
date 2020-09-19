using Octoller.OrderLineHandler.ServiceObjects;
using Octoller.OrderLineHandler.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Octoller.OrderLineHandler.Processor {
    public sealed class OrderListCreator {

        private string commandSeparator;
        private string argumentSeparator;
        private string argumentLineSeparator;


        public OrderListCreator() {
            commandSeparator = "!";
            argumentSeparator = ":";
            argumentLineSeparator = ",";
        }

        public OrderList Parse(string input) {

            string[] advance = LineSplit(input, commandSeparator);
            OrderList result = new OrderList();

            for (int i = 0; i < advance.Length; i++) {
                string[] preArguments = LineSplit(advance[i], argumentSeparator);
                string command = preArguments[0];

                List<string> arguments = default;
                if (preArguments.Length > 1) {
                    arguments = new List<string>();
                    for (int j = 1; j < preArguments.Length; j++) {
                        arguments.AddRange(LineSplit(preArguments[j], argumentLineSeparator));
                    }
                }
                result.Add(new SimpleOrder(command, arguments?.ToArray()));
            }

            return result;
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
