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

namespace Octoller.OrderLineHandler.ServiceObjects
{
    public class ParseElement
    {
        #region Public Properties

        public string[] Arguments { get; private set; }

        public virtual bool IsNull { get => false; }

        public string OrderName { get; private set; }

        public TransitionSign Sign { get; private set; }

        #endregion Public Properties

        #region Public Constructors

        public ParseElement(string order)
            : this(order, null, TransitionSign.None) { }

        public ParseElement(string order, string[] arguments)
            : this(order, arguments, TransitionSign.None) { }

        public ParseElement(string orderName, string[] arguments, TransitionSign sign)
        {
            OrderName = orderName;
            Sign = sign;
            Arguments = arguments;
        }

        #endregion Public Constructors
    }
}