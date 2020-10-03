﻿/*
 * ***************************************************************************************
 * 
 * Octoller.LineCommander
 * 27.08.2020
 *  
 *****************************************************************************************  
 */

using Octoller.OrderLineHandler.ServiceObjects;
using Octoller.OrderLineHandler.Processor;

namespace Octoller.OrderLineHandler.Default {
    public sealed class HelperHead : IOrderHeader {

        private static string key = "help";
        private static string description = 
            "Отображает подсказку по всем доступным командам";

        public string Key {
            get => key;
        }

        public string Description {
            get => description;
        }

        public IOrderHandler GetHandler() =>
            new HelperHandler();
    }
}
