using Core.Helper.DnlibUtils;
using Core.Helper.Generator.Context;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Protections.ReferenceProxy
{
    public class ReferenceProxy
    {
        private List<MethodDef> usedMethods = new List<MethodDef>();
        private Generator generator = new Generator();
        public ReferenceProxy(PandaState pandaState, PandaContext pandaContext)
        {
            switch (pandaState)
            {
                case PandaState.Basic:
                    new RPBasic().Excute(pandaContext);
                    break;
                case PandaState.Normal:
                    new RPNormal().Excute(pandaContext);
                    break;
            }
        }
       
    }
}

