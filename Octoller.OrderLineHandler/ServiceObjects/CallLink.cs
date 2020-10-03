/*
 * ***************************************************************************************
 * 
 * Octoller.LineCommander
 * 03.10.2020
 *  
 *****************************************************************************************  
 */

using Octoller.OrderLineHandler.ServiceObjects.Extension;
using Octoller.OrderLineHandler.Processor;
using System;
/*
 * ***************************************************************************************
 * 
 * Octoller.LineCommander
 * 03.10.2020
 *  
 *****************************************************************************************  
 */

namespace Octoller.OrderLineHandler.ServiceObjects {
    public sealed class CallLink : ICallLinked {
        
        private IOrderHandler curentHandler;
        private TransitionSign sign;
        private ICallLinked next;

        public CallLink() {
            sign = TransitionSign.None;
        }

        public void PrepareHandler(IOrderHandler handler, string[] arguments) {
            if (handler is null) {
                throw new ArgumentNullException(nameof(handler), "Handler is null");
            }

            curentHandler = handler;
            curentHandler.SetArgument(arguments);
        }

        public void SetNext(ICallLinked container, TransitionSign transitionSign) {
            next = container;
            sign = transitionSign;
        }

        public IChContext RunHandler(IChContext context) {
            bool result = curentHandler.Invoke(context);
            if (sign.CheckPpossibility(result)) {
                next?.RunHandler(context);
            }
            return context;
        }

    }
}
