using Core.Protections.ConstantMelting;
using Core.Protections.ControlFlow;
using Core.Protections.IntMath;
using Core.Protections.ReferenceProxy;
using Core.Protections.StringEncoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
   public class PandaModuleManager
    {
        public List<PandaProtection> pandaProtections()
        {
            return new List<PandaProtection>()
            {
                new StringEncodingProtection(),
                new ConstantMeltingProtection(),
                new IntMathProtection(),
                new ControlFlowProtection(),
                new ReferenceProxyProtection()
            };
        }
    }
}
