using dnlib.DotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ObfuscationUtils
{
    public class ObfuscationMethodUtil
    {
        
        public static bool canObfuscate(MethodDef methodDef)
        {
            if (!methodDef.HasBody)
                return false;
            if (!methodDef.Body.HasInstructions)
                return false;
            if (methodDef.DeclaringType.IsGlobalModuleType)
                return false;

            return true;

        }
    }
}
