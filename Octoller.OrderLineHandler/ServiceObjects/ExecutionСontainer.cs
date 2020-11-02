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

namespace Octoller.OrderLineHandler.ServiceObjects {

    public sealed class ExecutionСontainer : IExecution {
        
        private IOrderHandler curentHandler;
        private TransitionSign sign;
        private IExecution next;

        public ExecutionСontainer() {

            sign = TransitionSign.None;
        }

        public void PrepareHandler(IOrderHandler handler) {

            if (handler is null) {

                throw new ArgumentNullException(nameof(handler), "Handler is null.");
            }

            curentHandler = handler;
        }

        public void SetNext(IExecution container, TransitionSign transitionSign) {

            next = container;
            sign = transitionSign;
        }

        public IChContext RunHandler(IChContext context) {

            bool result = curentHandler.Invoke(ref context);

            if (sign.CheckPpossibility(result)) {

                next?.RunHandler(context);
            }

            return context;
        }
    }
}
