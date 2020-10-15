/*
 * ************************************************************
 *   _     _              _   _                 _ _           
 *  | |   (_)_ __   ___  | | | | __ _ _ __   __| | | ___ _ __ 
 *  | |   | | '_ \ / _ \ | |_| |/ _` | '_ \ / _` | |/ _ \ '__|
 *  | |___| | | | |  __/ |  _  | (_| | | | | (_| | |  __/ |   
 *  |_____|_|_| |_|\___| |_| |_|\__,_|_| |_|\__,_|_|\___|_|   
 *
 * Octoller.LineCommander
 * 03.10.2020
 *  
 ************************************************************** 
 */

namespace Octoller.OrderLineHandler.ServiceObjects {

    public class ParseElement {

        public virtual bool IsNull {
            get => false;
        }

        public TransitionSign Sign {
            get; private set;
        }

        public string OrderName {
            get; private set;
        }

        public string[] Arguments {
            get; private set;
        }

        public ParseElement(string order)
            : this(order, null, TransitionSign.None) { }

        public ParseElement(string order, string[] arguments)
            : this(order, arguments, TransitionSign.None) { }

        public ParseElement(string orderName, string[] arguments, TransitionSign sign) {

            OrderName = orderName;
            Sign = sign;
            Arguments = arguments;
        }
    }
}
