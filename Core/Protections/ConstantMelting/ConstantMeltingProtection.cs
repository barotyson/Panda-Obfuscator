using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Protections.ConstantMelting
{
    class ConstantMeltingProtection : PandaProtection
    {
        public override string Name => "Constant Melting";

        public override string Description => "Melting String and Integer (Copy it into another method and call it)";

        public override string Id => "panda.ConstantMelting";

        public override string Author => "CodeOfDark";

        public override void Execute(PandaContext pandaContext)
        {
            ConstantMelting.Melting(pandaContext);
        }

        public override void Register(PandaContext pandaContext)
        {
            pandaContext.register.RegisterModule(this);
        }
    }
}
