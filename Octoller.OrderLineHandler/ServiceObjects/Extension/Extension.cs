/*
 * ************************************************************
 *   _     _              _   _                 _ _
 *  | |   (_)_ __   ___  | | | | __ _ _ __   __| | | ___ _ __
 *  | |   | | '_ \ / _ \ | |_| |/ _` | '_ \ / _` | |/ _ \ '__|
 *  | |___| | | | |  __/ |  _  | (_| | | | | (_| | |  __/ |
 *  |_____|_|_| |_|\___| |_| |_|\__,_|_| |_|\__,_|_|\___|_|
 *
 * Octoller.LineCommander
 * 02.10.2020
 *
 **************************************************************
 */

namespace Octoller.OrderLineHandler.ServiceObjects
{
    public static class Extension
    {
        #region Public Methods

        public static bool CheckPpossibility(this TransitionSign sign, bool handlerResult)
            => sign switch
            {
                TransitionSign.None => false,
                TransitionSign.NextAny => true,
                TransitionSign.NextFalse => !handlerResult,
                TransitionSign.NextTrue => handlerResult,
                _ => false
            };

        #endregion Public Methods
    }
}