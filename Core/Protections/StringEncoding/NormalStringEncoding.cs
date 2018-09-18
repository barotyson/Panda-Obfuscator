using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Protections.StringEncoding
{
    public class NormalStringEncoding
    {
        
        public NormalStringEncoding(PandaContext pandaContext)
        {
            if (pandaContext != null)
                Encoding(pandaContext);
            new ArgumentNullException("PandaContext cannot be null!");
        }
        public void Encoding(PandaContext pandaContext)
        {
            StringHelper stringHelper = new StringHelper();
            MethodDef DecryptMethod = stringHelper.Inject(pandaContext.moduleDef);
            foreach (TypeDef type in pandaContext.moduleDef.Types)
            {
                foreach (MethodDef method in type.Methods)
                {
                    if (method.Body == null) continue;
                    if (method == DecryptMethod) continue;
                    for (int i = 0; i < method.Body.Instructions.Count(); i++)
                    {
                        if (method.Body.Instructions[i].OpCode == OpCodes.Ldstr)
                        {
                            string oldStr = method.Body.Instructions[i].Operand.ToString();
                            method.Body.Instructions[i].Operand = stringHelper.Encrypt(oldStr);
                            method.Body.Instructions.Insert(i + 1, new Instruction(OpCodes.Call, DecryptMethod));
                            i++;
                        }
                    }
                }
            }
        }
    }
}
