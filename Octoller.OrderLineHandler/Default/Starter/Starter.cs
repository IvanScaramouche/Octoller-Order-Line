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

using Octoller.OrderLineHandler.ServiceObjects;
using Octoller.OrderLineHandler.Processor;

namespace Octoller.OrderLineHandler.Default
{
    public sealed class Starter : IExecution
    {
        #region Private Fields

        private IExecution _next;

        #endregion Private Fields

        #region Public Constructors

        public Starter()
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public void PrepareHandler(IOrderHandler handler)
        {
            return;
        }

        public IChContext RunHandler(IChContext context)
        {
            if (_next is null)
            {
                context.Complite = false;
                context.SetError("Execution chain error");
                return context;
            }

            return _next?.RunHandler(context);
        }

        public void SetNext(IExecution container, TransitionSign transitionSign) =>
            _next = container;

        #endregion Public Methods
    }
}