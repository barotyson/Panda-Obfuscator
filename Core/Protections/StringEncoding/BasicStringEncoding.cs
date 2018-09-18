using Core.Helper.DnlibUtils;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Protections.StringEncoding
{
    public class BasicStringEncoding
    {
        public BasicStringEncoding(PandaContext pandaContext)
        {
            if (pandaContext != null)
                Encoding(pandaContext);
            new ArgumentNullException("PandaContext cannot be null!");
        }
        public void Encoding(PandaContext pandaContext)
        {
            foreach (TypeDef type in pandaContext.moduleDef.Types)
            {
                foreach (MethodDef method in type.Methods)
                {
                    if (method.Body == null) continue;
                    for (int i = 0; i < method.Body.Instructions.Count(); i++)
                    {
                        if (method.Body.Instructions[i].OpCode == OpCodes.Ldstr)
                        {
                            String oldString = method.Body.Instructions[i].Operand.ToString();
                            String newString = Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(oldString));
                            method.Body.Instructions[i].OpCode = OpCodes.Nop;
                            method.Body.Instructions.Insert(i + 1, new Instruction(OpCodes.Call, pandaContext.moduleDef.Import(typeof(System.Text.Encoding).GetMethod("get_UTF8", new Type[] { }))));
                            method.Body.Instructions.Insert(i + 2, new Instruction(OpCodes.Ldstr, newString));
                            method.Body.Instructions.Insert(i + 3, new Instruction(OpCodes.Call, pandaContext.moduleDef.Import(typeof(System.Convert).GetMethod("FromBase64String", new Type[] { typeof(string) }))));
                            method.Body.Instructions.Insert(i + 4, new Instruction(OpCodes.Callvirt, pandaContext.moduleDef.Import(typeof(System.Text.Encoding).GetMethod("GetString", new Type[] { typeof(byte[]) }))));
                            i += 4;
                        }
                    }
                    DnlibUtils.Optimize(method);
                }
            }

        }
    }
}
