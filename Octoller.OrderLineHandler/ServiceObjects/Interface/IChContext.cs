/*
 * ************************************************************
 *   _     _              _   _                 _ _           
 *  | |   (_)_ __   ___  | | | | __ _ _ __   __| | | ___ _ __ 
 *  | |   | | '_ \ / _ \ | |_| |/ _` | '_ \ / _` | |/ _ \ '__|
 *  | |___| | | | |  __/ |  _  | (_| | | | | (_| | |  __/ |   
 *  |_____|_|_| |_|\___| |_| |_|\__,_|_| |_|\__,_|_|\___|_|   
 *
 * Octoller.LineCommander
 * 25.08.2020
 *  
 ************************************************************** 
 */

using System;

namespace Octoller.OrderLineHandler.ServiceObjects {

    public interface IChContext {

        bool Complite { get; set; }

        bool IsError { get; set; }

        bool IsMessage { get; set; }

        Action Action { get; set; }

        void SetError(string message, bool isError = true);
        void SetMessage(string message, bool isMessage = true);

        string GetError();
        string GetMessage();
    }
}
