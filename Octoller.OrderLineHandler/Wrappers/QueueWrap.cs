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
namespace Octoller.OrderLineHandler.Wrappers {

    public sealed class QueueWrap {

        private Queue<ParseElement> orderContainers;

        public QueueWrap() {

            orderContainers = new Queue<ParseElement>();
        }

        public int Count {
            get => orderContainers.Count;
        }

        public void Enqueue(ParseElement container) {

            orderContainers.Enqueue(container);
        }

        public ParseElement Dequeue() {

            try {

                return orderContainers.Dequeue();

            } catch {

                return new NullParseElement();

            }
        }
    }
}
