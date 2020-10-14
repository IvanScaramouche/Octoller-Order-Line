/*
 * ***************************************************************************************
 * 
 * Octoller.LineCommander
 * 04.10.2020
 *  
 *****************************************************************************************  
 */

namespace Octoller.OrderLineHandler.ServiceObjects {

    public class NullParseElement : ParseElement {
        
        public override bool IsNull {
            get => true;
        }

        public NullParseElement() 
            : base(null, null, TransitionSign.None) { /*  */}

    }
}
