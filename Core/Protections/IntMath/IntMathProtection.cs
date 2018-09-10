using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Protections.IntMath
{
    class IntMathProtection : PandaProtection
    {
        public override string Name => "Integer Math";

        public override string Description => "Protecting your integer by math operators Example { + and - }.";

        public override string Id => "panda.IntMath";

        public override string Author => "CodeOfDark";

        public override void Execute(PandaContext pandaContext)
        {
            IntMath.Execute(pandaContext);
        }

        public override void Register(PandaContext pandaContext)
        {
            pandaContext.register.RegisterModule(this);
        }
    }
}
