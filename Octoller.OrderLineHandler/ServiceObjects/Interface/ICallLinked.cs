/*
 * ***************************************************************************************
 * 
 * Octoller.LineCommander
 * 03.10.2020
 *  
 *****************************************************************************************  
 */

using Octoller.OrderLineHandler.Processor;

namespace Octoller.OrderLineHandler.ServiceObjects {
    public interface ICallLinked {
        void PrepareHandler(IOrderHandler handler, string[] arguments);
        void SetNext(ICallLinked container, TransitionSign transitionSign);
        IChContext RunHandler(IChContext context);
    }
}
