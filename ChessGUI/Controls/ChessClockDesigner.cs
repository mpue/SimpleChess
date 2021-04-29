using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGUI.Controls
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ChessClockDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        private ChessClock clock = null;

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            clock = component as ChessClock;
            EnableDesignMode(clock, clock.Name);
        }

        
    }
}
