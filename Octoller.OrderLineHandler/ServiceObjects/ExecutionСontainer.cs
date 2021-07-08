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

using Octoller.OrderLineHandler.Processor;
using System;

namespace Octoller.OrderLineHandler.ServiceObjects
{
    public sealed class ExecutionСontainer : IExecution
    {
        #region Private Fields

        private IOrderHandler _curentHandler;
        private IExecution _next;
        private TransitionSign _sign;

        #endregion Private Fields

        #region Public Constructors

        public ExecutionСontainer()
        {
            _sign = TransitionSign.None;
        }

        #endregion Public Constructors

        #region Public Methods

        public void PrepareHandler(IOrderHandler handler)
        {
            if (handler is null)
            {
                throw new ArgumentNullException(nameof(handler), "Handler is null.");
            }

            _curentHandler = handler;
        }

        public IChContext RunHandler(IChContext context)
        {
            bool result = _curentHandler.Invoke(ref context);

            if (_sign.CheckPpossibility(result))
            {
                _next?.RunHandler(context);
            }

            return context;
        }

        public void SetNext(IExecution container, TransitionSign transitionSign)
        {
            _next = container;
            _sign = transitionSign;
        }

        #endregion Public Methods
    }
}