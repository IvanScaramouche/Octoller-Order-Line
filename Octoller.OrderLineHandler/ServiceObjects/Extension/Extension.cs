/*
 * ***************************************************************************************
 * 
 * Octoller.LineCommander
 * 02.10.2020
 *  
 *****************************************************************************************  
 */

namespace Octoller.OrderLineHandler.ServiceObjects {
    public static class Extension {
        public static bool CheckPpossibility(this TransitionSign sign, bool handlerResult) 
            => sign switch {

            TransitionSign.None => false,
            TransitionSign.NextAny => true,
            TransitionSign.NextFalse => !handlerResult,
            TransitionSign.NextTrue => handlerResult,
            _ => false
        };
    }
}
