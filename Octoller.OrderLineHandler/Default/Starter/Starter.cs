/*
 * ***************************************************************************************
 * 
 * Octoller.LineCommander
 * 03.10.2020
 *  
 *****************************************************************************************  
 */

using Octoller.OrderLineHandler.ServiceObjects;
using Octoller.OrderLineHandler.Processor;

namespace Octoller.OrderLineHandler.Default {

    public sealed class Starter : IExecution {

        private IExecution next;

        public Starter() { }

        public void PrepareHandler(IOrderHandler handler) {
            return;
        }

        public IChContext RunHandler(IChContext context) {

            if (next is null) {

                context.Complite = false;
                context.SetError("Execution chain error");
                return context;
            }

            return next?.RunHandler(context); 
        }

        public void SetNext(IExecution container, TransitionSign transitionSign) =>
            next = container;
    }
}
