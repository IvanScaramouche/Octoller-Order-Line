/*
 * ***************************************************************************************
 * 
 * Octoller.LineCommander
 * 03.10.2020
 *  
 *****************************************************************************************  
 */

namespace Octoller.OrderLineHandler.ServiceObjects {
    public class ParseElement {

        public virtual bool IsNull {
            get => false;
        }

        public TransitionSign Sign {
            get; private set;
        }

        public string Order {
            get; private set;
        }

        public string[] Arguments {
            get; private set;
        }

        public ParseElement(string order)
            : this(order, null, TransitionSign.None) { }

        public ParseElement(string order, string[] arguments)
            : this(order, arguments, TransitionSign.None) { }

        public ParseElement(string order, string[] arguments, TransitionSign sign) {
            Order = order;
            Sign = sign;
            Arguments = arguments;
        }
    }
}
