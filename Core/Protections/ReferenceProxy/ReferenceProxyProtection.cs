using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Protections.ReferenceProxy
{
    class ReferenceProxyProtection : PandaProtection
    {
        public override string Name => "Reference Proxy";

        public override string Description => "This protection hides calls.";

        public override string Id => "panda.ReferenceProxy";

        public override string Author => "CodeOfDark";

        public override void Execute(PandaContext pandaContext)
        {
            ReferenceProxy.Execute(pandaContext);
        }

        public override void Register(PandaContext pandaContext)
        {
            pandaContext.register.RegisterModule(this);
        }
    }
}
