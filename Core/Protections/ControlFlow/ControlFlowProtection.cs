using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Protections.ControlFlow
{
    class ControlFlowProtection : PandaProtection
    {
        public override string Name => "Control Flow";

        public override string Description => "This protection mangles the code in the methods.";

        public override string Id => "panda.ControlFlow";

        public override string Author => "CodeOfDark";

        public override void Execute(PandaContext pandaContext)
        {
            ControlFlow.Execute(pandaContext);
        }

        public override void Register(PandaContext pandaContext)
        {
            pandaContext.register.RegisterModule(this);
        }
    }
}
