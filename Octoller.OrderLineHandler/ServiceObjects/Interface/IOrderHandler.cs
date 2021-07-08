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

using Octoller.OrderLineHandler.ServiceObjects;

namespace Octoller.OrderLineHandler.Processor
{
    public interface IOrderHandler
    {
        #region Public Methods

        bool Invoke(ref IChContext context);

        void SetArgument(params string[] arg);

        #endregion Public Methods
    }
}