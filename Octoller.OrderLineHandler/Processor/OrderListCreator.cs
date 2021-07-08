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
using Octoller.OrderLineHandler.Wrappers;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Octoller.OrderLineHandler.Processor
{
    public sealed class OrderListCreator
    {
        #region Private Fields

        private readonly string ARG_SEPARATOR = ",";
        private readonly string ORDER_SEPARATOR = ":";
        private readonly string SPACE_SEPARATOR = " ";

        private Dictionary<string, TransitionSign> _transitionSeparator =
            new Dictionary<string, TransitionSign>
            {
                ["&"] = TransitionSign.NextAny,
                ["&&"] = TransitionSign.NextTrue,
                ["||"] = TransitionSign.NextFalse
            };

        #endregion Private Fields

        #region Public Constructors

        public OrderListCreator()
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public QueueWrap Parse(string input)
        {
            string[] advance = LineSplit(input, SPACE_SEPARATOR);
            QueueWrap resultQueue = new QueueWrap();

            for (int i = 0; i < advance.Length; i++)
            {
                string[] lineOrder = LineSplit(advance[i], ORDER_SEPARATOR);
                string nameOrder = lineOrder[0];

                List<string> arguments = default;

                if (lineOrder.Length > 1)
                {
                    arguments = LineSplit(lineOrder[1], ARG_SEPARATOR)
                        .ToList();
                }

                int next = i + 1;

                if (next < advance.Length)
                {
                    if (_transitionSeparator.ContainsKey(advance[next]))
                    {
                        resultQueue.Enqueue(new ParseElement(nameOrder,
                            arguments?.ToArray(),
                            _transitionSeparator[advance[next]]));

                        i = next;
                    }
                    else
                    {
                        throw new ArgumentException("Error in line command.");
                    }
                }
                else
                {
                    resultQueue.Enqueue(new ParseElement(nameOrder,
                        arguments?.ToArray()));
                }
            }

            return resultQueue;
        }

        #endregion Public Methods

        #region Private Methods

        private string[] LineSplit(string line, string separator) =>
            line.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries)
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .ToArray();

        private string[] LineSplit(string line, char separator) =>
            line.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries)
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .ToArray();

        #endregion Private Methods
    }
}