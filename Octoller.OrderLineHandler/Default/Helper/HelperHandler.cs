/*
 * ***************************************************************************************
 * 
 * Octoller.LineCommander
 * 27.08.2020
 *  
 *****************************************************************************************  
 */

using Octoller.OrderLineHandler.ServiceObjects;
using Octoller.OrderLineHandler.Processor;
using System.Collections.Generic;
using System;

namespace Octoller.OrderLineHandler.Default {

    public sealed class HelperHandler : IOrderHandler {

        private List<string> helpList = new List<string>();

        public bool Invoke(ref IChContext context) {

            helpList.ForEach((helpString) => {
                Console.WriteLine($"\t# {helpString}");
            });

            context.Complite = true;
            return true;
        }

        public void SetArgument(Dictionary<string, IOrderHeader> headers) {

            if (headers == null) {

                throw new ArgumentNullException(nameof(headers));
            }

            foreach (var h in headers.Values) {

                helpList.Add(String.Concat(h.Key, "\t", h.Description));
            }
        }

        public void SetArgument(params string[] arg) {

            return;
        }
    }
}
