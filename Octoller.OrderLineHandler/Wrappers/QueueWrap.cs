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
using System.Collections.Generic;

/// <summary>
/// Данная обертка над коллецей Queule необходима для отлова ошибки при попытке получить
/// последний элемент очереди при пустой очереди.
/// Теперь вовращается объект NullParseElement
/// </summary>
namespace Octoller.OrderLineHandler.Wrappers
{
    public sealed class QueueWrap
    {
        #region Private Fields

        private Queue<ParseElement> _orderContainers;

        #endregion Private Fields

        #region Public Properties

        public int Count
        {
            get => _orderContainers.Count;
        }

        #endregion Public Properties

        #region Public Constructors

        public QueueWrap()
        {
            _orderContainers = new Queue<ParseElement>();
        }

        #endregion Public Constructors

        #region Public Methods

        public ParseElement Dequeue()
        {
            if (_orderContainers.Count > 0)
            {
                return _orderContainers.Dequeue();
            }
            else
            {
                return new NullParseElement();
            }
        }

        public void Enqueue(ParseElement container)
        {
            _orderContainers.Enqueue(container);
        }

        #endregion Public Methods
    }
}