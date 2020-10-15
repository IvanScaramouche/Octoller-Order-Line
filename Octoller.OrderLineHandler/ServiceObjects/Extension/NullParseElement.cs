/*
 * ************************************************************
 *   _     _              _   _                 _ _           
 *  | |   (_)_ __   ___  | | | | __ _ _ __   __| | | ___ _ __ 
 *  | |   | | '_ \ / _ \ | |_| |/ _` | '_ \ / _` | |/ _ \ '__|
 *  | |___| | | | |  __/ |  _  | (_| | | | | (_| | |  __/ |   
 *  |_____|_|_| |_|\___| |_| |_|\__,_|_| |_|\__,_|_|\___|_|   
 *
 * Octoller.LineCommander
 * 04.10.2020
 *  
 ************************************************************** 
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
