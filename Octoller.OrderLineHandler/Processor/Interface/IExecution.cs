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

namespace Octoller.OrderLineHandler.Processor {

    public interface IExecution {

        void PrepareHandler(IOrderHandler handler);

        void SetNext(IExecution container, TransitionSign transitionSign);

        IChContext RunHandler(IChContext context);
    }
}
