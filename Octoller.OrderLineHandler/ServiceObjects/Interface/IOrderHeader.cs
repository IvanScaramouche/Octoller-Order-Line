/*
 * ************************************************************
 *   _     _              _   _                 _ _           
 *  | |   (_)_ __   ___  | | | | __ _ _ __   __| | | ___ _ __ 
 *  | |   | | '_ \ / _ \ | |_| |/ _` | '_ \ / _` | |/ _ \ '__|
 *  | |___| | | | |  __/ |  _  | (_| | | | | (_| | |  __/ |   
 *  |_____|_|_| |_|\___| |_| |_|\__,_|_| |_|\__,_|_|\___|_|   
 *
 * Octoller.LineCommander
 * 27.08.2020
 *  
 ************************************************************** 
 */

using Octoller.OrderLineHandler.Processor;

namespace Octoller.OrderLineHandler.ServiceObjects {

    public interface IOrderHeader {

        string Key { get; }

        string Description { get; }

        IOrderHandler GetHandler(params string[] arg);
    }
}
