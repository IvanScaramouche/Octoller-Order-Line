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
using Octoller.OrderLineHandler.Processor;
using System.Collections.Generic;
using System;

namespace Octoller.OrderLineHandler.Default
{
    public sealed class HelperHandler : IOrderHandler
    {
        #region Private Fields

        private List<string> _helpList = new List<string>();

        #endregion Private Fields

        #region Public Methods

        public bool Invoke(ref IChContext context)
        {
            _helpList.ForEach((helpString) =>
            {
                Console.WriteLine($"\t# {helpString}");
            });

            context.Complite = true;
            return true;
        }

        public void SetArgument(Dictionary<string, IOrderHeader> headers)
        {
            if (headers == null)
            {
                throw new ArgumentNullException(nameof(headers));
            }

            foreach (var h in headers.Values)
            {
                _helpList.Add(String.Concat(h.Key, "\t", h.Description));
            }
        }

        public void SetArgument(params string[] arg)
        {
            return;
        }

        #endregion Public Methods
    }
}