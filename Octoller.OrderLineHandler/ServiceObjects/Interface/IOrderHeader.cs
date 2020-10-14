/*
 * ***************************************************************************************
 * 
 * Octoller.LineCommander
 * 27.08.2020
 *  
 *****************************************************************************************  
 */

using Octoller.OrderLineHandler.Processor;

namespace Octoller.OrderLineHandler.ServiceObjects {

    public interface IOrderHeader {

        string Key { get; }

        string Description { get; }

        IOrderHandler GetHandler(params string[] arg);
    }
}
