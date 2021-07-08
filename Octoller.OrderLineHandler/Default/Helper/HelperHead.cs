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

using Octoller.OrderLineHandler.ServiceObjects;

namespace Octoller.OrderLineHandler.Default
{
    public sealed class HelperHead : BaseHeader<HelperHandler>
    {
        #region Public Properties

        public override string Description
        {
            get => "Отображает подсказку по всем доступным командам";
        }

        public override string Key
        {
            get => "help";
        }

        #endregion Public Properties
    }
}