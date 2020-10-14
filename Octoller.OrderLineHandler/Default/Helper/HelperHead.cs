/*
 * ***************************************************************************************
 * 
 * Octoller.LineCommander
 * 27.08.2020
 *  
 *****************************************************************************************  
 */

using Octoller.OrderLineHandler.ServiceObjects;

namespace Octoller.OrderLineHandler.Default {

    public sealed class HelperHead : BaseHeader<HelperHandler> {
        
        public override string Key {
            get => "help";
        }

        public override string Description {
            get => "Отображает подсказку по всем доступным командам";
        }
    }
}
