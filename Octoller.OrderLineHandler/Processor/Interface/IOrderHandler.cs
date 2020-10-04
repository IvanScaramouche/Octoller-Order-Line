/*
 * ***************************************************************************************
 * 
 * Octoller.LineCommander
 * 25.08.2020
 *  
 *****************************************************************************************  
 */

using Octoller.OrderLineHandler.ServiceObjects;

namespace Octoller.OrderLineHandler.Processor {
    public interface IOrderHandler {
        bool Invoke(ref IChContext context);
        void SetArgument(params string[] arg);
    }
}
