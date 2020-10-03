/*
 * ***************************************************************************************
 * 
 * Octoller.LineCommander
 * 03.10.2020
 *  
 *****************************************************************************************  
 */

namespace Octoller.OrderLineHandler.ServiceObjects {
    public sealed class OrderContainer {

        public TransitionSign Sign {
            get; private set;
        }

        public string Order {
            get; private set;
        }

        public string[] Arguments {
            get; private set;
        }

        public OrderContainer(string order)
            : this(order, null, TransitionSign.None) { }

        public OrderContainer(string order, string[] arguments)
            : this(order, arguments, TransitionSign.None) { }

        public OrderContainer(string order, string[] arguments, TransitionSign sign) {
            Order = order;
            Sign = sign;
            Arguments = arguments;
        }
    }
}
