/*
 * ***************************************************************************************
 * 
 * Octoller.LineCommander
 * 03.10.2020
 *  
 *****************************************************************************************  
 */

using Octoller.OrderLineHandler.ServiceObjects;

namespace Octoller.OrderLineHandler.Processor {

    public interface IExecution {

        void PrepareHandler(IOrderHandler handler);

        void SetNext(IExecution container, TransitionSign transitionSign);

        IChContext RunHandler(IChContext context);
    }
}
