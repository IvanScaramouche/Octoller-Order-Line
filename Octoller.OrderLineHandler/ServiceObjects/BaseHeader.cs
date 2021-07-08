/*
 * ************************************************************
 *   _     _              _   _                 _ _
 *  | |   (_)_ __   ___  | | | | __ _ _ __   __| | | ___ _ __
 *  | |   | | '_ \ / _ \ | |_| |/ _` | '_ \ / _` | |/ _ \ '__|
 *  | |___| | | | |  __/ |  _  | (_| | | | | (_| | |  __/ |
 *  |_____|_|_| |_|\___| |_| |_|\__,_|_| |_|\__,_|_|\___|_|
 *
 * Octoller.LineCommander
 * 04.10.2020
 *
 **************************************************************
 */

using Octoller.OrderLineHandler.Processor;

namespace Octoller.OrderLineHandler.ServiceObjects
{
    public abstract class BaseHeader<TOrderHandler>
        : IOrderHeader where TOrderHandler : IOrderHandler, new()
    {
        #region Public Properties

        public abstract string Description { get; }
        public abstract string Key { get; }

        #endregion Public Properties

        #region Public Methods

        IOrderHandler IOrderHeader.GetHandler(params string[] arg)
        {
            IOrderHandler handler = new TOrderHandler();
            handler.SetArgument(arg);

            return handler;
        }

        #endregion Public Methods
    }
}