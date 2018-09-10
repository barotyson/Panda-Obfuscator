using dnlib.DotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    class PandaMarker : PandaProtection
    {
        public override string Name => "PandaMarker";

        public override string Description => "PandaMarker an simple class to make sure this app protected by PandaObfuscator";

        public override string Id => "panda.PandaObfuscator";

        public override string Author => "CodeOfDark";

        public override void Execute(PandaContext pandaContext)
        {
            pandaContext.moduleDef.GlobalType.NestedTypes.Add(new TypeDefUser("PandaObfuscator"));
        }

        public override void Register(PandaContext pandaContext)
        {
            //...
        }
    }
}
