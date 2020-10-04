/*
 * ***************************************************************************************
 * 
 * Octoller.LineCommander
 * 04.10.2020
 *  
 *****************************************************************************************  
 */

using Octoller.OrderLineHandler.Processor;

namespace Octoller.OrderLineHandler.ServiceObjects {
    public abstract class BaseHeader<TOrderHandler> : IOrderHeader where TOrderHandler : IOrderHandler, new() {
        
        public abstract string Key {
            get;
        }

        public abstract string Description {
            get;
        }

        public IOrderHandler GetHandler(params string[] arg) {
            IOrderHandler handler = new TOrderHandler();
            handler.SetArgument(arg);
            return handler;
        }
    }
}
