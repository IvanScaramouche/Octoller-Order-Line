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
using Octoller.OrderLineHandler.Default;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Octoller.OrderLineHandler.Processor
{
    public sealed class InputHandler
    {
        #region Private Fields

        private static Starter _starter;

        private OrderListCreator _creator;

        private Dictionary<string, IOrderHeader> _orderHeaders =
                            new Dictionary<string, IOrderHeader>();

        #endregion Private Fields

        #region Public Constructors

        static InputHandler() => _starter = new Starter();

        public InputHandler()
        {
            _creator = new OrderListCreator();
            AddOrder(new HelperHead());
            ///TODO: добавить возможность установки своих разделителей для комманд и аргументов
        }

        #endregion Public Constructors

        #region Public Methods

        public void AddOrder(IOrderHeader header)
        {
            if (header != null)
            {
                _orderHeaders.Add(header.Key, header);
            }
        }

        public void AddOrderes(params IOrderHeader[] headers)
        {
            if (headers != null || headers.Length > 0)
            {
                Array.ForEach<IOrderHeader>(headers, header =>
                {
                    _orderHeaders.Add(header.Key, header);
                });
            }
        }

        public void AddOrderRange(IEnumerable<IOrderHeader> headers)
        {
            if (headers != null || headers.Count() > 0)
            {
                Array.ForEach<IOrderHeader>(headers.ToArray(), header =>
                {
                    _orderHeaders.Add(header.Key, header);
                });
            }
        }

        public IChContext ParseOrderLine(string input, IChContext context)
        {
            IChContext ansver;

            try
            {
                ansver = Parse(input, context);
            }
            catch (Exception ex)
            {
                ansver = context;
                ansver.Complite = false;
                ansver.SetError($"Error: {ex.Message}");
            }

            return ansver;
        }

        #endregion Public Methods

        #region Private Methods

        private IChContext FollowСhainOrders(QueueWrap orderQueue, IChContext context)
        {
            QueueWrap queue = orderQueue;
            ParseElement parseElement = queue.Dequeue();
            IExecution previousLink = _starter;
            TransitionSign nextSign = TransitionSign.None;

            while (!parseElement.IsNull)
            {
                if (_orderHeaders.TryGetValue(parseElement.OrderName, out IOrderHeader header))
                {
                    IExecution nextLink = new ExecutionСontainer();
                    IOrderHandler curentHandler = header.GetHandler(parseElement.Arguments);

                    if (curentHandler is HelperHandler helpHand)
                    {
                        helpHand.SetArgument(_orderHeaders);
                        curentHandler = helpHand;
                    }

                    nextLink.PrepareHandler(curentHandler);
                    previousLink.SetNext(nextLink, nextSign);
                    previousLink = nextLink;
                    nextSign = parseElement.Sign;
                }
                else
                {
                    throw new ArgumentException("Input command name error.");
                }

                parseElement = queue.Dequeue();
            }

            return _starter.RunHandler(context);
        }

        private IChContext Parse(string input, IChContext context)
        {
            var orderQueue = _creator.Parse(input);

            if (orderQueue.Count == 0)
            {
                throw new ArgumentException("Invalid or empty input string.");
            }

            return FollowСhainOrders(orderQueue, context);
        }

        #endregion Private Methods
    }
}