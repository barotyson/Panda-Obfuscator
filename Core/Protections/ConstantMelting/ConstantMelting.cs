using Core.Helper.Generator.Context;
using Core.ObfuscationUtils;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Protections.ConstantMelting
{
    public class ConstantMelting
    {
        private Generator generator = new Generator();
        public ConstantMelting(PandaContext pandaContext)
        {
            Melting(pandaContext);
        }
        public void Melting(PandaContext pandaContext)
        {
            foreach(TypeDef type in pandaContext.moduleDef.Types.ToArray())
            {
                foreach(MethodDef method in type.Methods.ToArray())
                {
                    StringOutliner(method);
                    IntegerOutliner(method);
                }
            }
        }
        private void StringOutliner(MethodDef methodDef)
        {
            if (ObfuscationMethodUtil.canObfuscate(methodDef))
            {
                foreach(Instruction instruction in methodDef.Body.Instructions)
                {
                    if (instruction.OpCode != OpCodes.Ldstr) continue;
                    MethodDef meth = new MethodDefUser(generator.Generate<string>(GeneratorType.String, 10), MethodSig.CreateStatic(methodDef.DeclaringType.Module.CorLibTypes.String), MethodImplAttributes.IL | MethodImplAttributes.Managed, MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.HideBySig) { Body = new CilBody() };
                    meth.Body.Instructions.Add(new Instruction(OpCodes.Ldstr, instruction.Operand.ToString()));
                    meth.Body.Instructions.Add(new Instruction(OpCodes.Ret));
                    methodDef.DeclaringType.Methods.Add(meth);
                    instruction.OpCode = OpCodes.Call;
                    instruction.Operand = meth;
                }
            }
        }
        private void IntegerOutliner(MethodDef methodDef)
        {
            if (ObfuscationMethodUtil.canObfuscate(methodDef))
            {
                foreach (Instruction instruction in methodDef.Body.Instructions)
                {
                    if (instruction.OpCode != OpCodes.Ldc_I4) continue;
                    MethodDef meth = new MethodDefUser(generator.Generate<string>(GeneratorType.String, 10), MethodSig.CreateStatic(methodDef.DeclaringType.Module.CorLibTypes.Int32), MethodImplAttributes.IL | MethodImplAttributes.Managed, MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.HideBySig) { Body = new CilBody() };
                    meth.Body.Instructions.Add(new Instruction(OpCodes.Ldc_I4, instruction.GetLdcI4Value()));
                    meth.Body.Instructions.Add(new Instruction(OpCodes.Ret));
                    methodDef.DeclaringType.Methods.Add(meth);
                    instruction.OpCode = OpCodes.Call;
                    instruction.Operand = meth;
                }
            }
        }


    }
}
