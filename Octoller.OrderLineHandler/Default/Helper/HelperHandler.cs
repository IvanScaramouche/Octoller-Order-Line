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
using System.Text;

namespace Octoller.OrderLineHandler.Default {
    public sealed class HelperHandler : IOrderHandler {

        private StringBuilder orderHelpList;

        public bool Invoke(ref IChContext context) {
            System.Console.WriteLine(orderHelpList.ToString());
            context.Complite = true;
            return true;
        }

        public void SetArgument(Dictionary<string, IOrderHeader> containers) {
            if (containers != null && containers.Count > 0) {
                orderHelpList = new StringBuilder();
                foreach (var container in containers.Values) {
                    var simpleString = $" #: {container.Key} \t {container.Description} \n";
                    orderHelpList.Append(simpleString);
                }
            }
        }

        public void SetArgument(params string[] arg) {
            return;
        }
    }
}
