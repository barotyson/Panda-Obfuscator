using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Protections.IntMath
{
    public class IntMath
    {
        public IntMath(PandaContext pandaContext)
        {
            Execute(pandaContext);
        }
        public void Execute(PandaContext panda)
        {
            INTMHelper IMHelper = new INTMHelper();
            foreach (TypeDef type in panda.moduleDef.Types)
            {
                foreach(MethodDef method in type.Methods)
                {
                    if (ObfuscationUtils.ObfuscationMethodUtil.canObfuscate(method))
                    {
                        for(int i = 0; i < method.Body.Instructions.Count; i++)
                        {
                            Instruction instruction = method.Body.Instructions[i];
                            if (instruction.Operand is int)
                            {
                                List<Instruction> instructions = IMHelper.Calc(Convert.ToInt32(instruction.Operand));
                                instruction.OpCode = OpCodes.Nop;
                                foreach (Instruction instr in instructions)
                                {
                                    method.Body.Instructions.Insert(i + 1, instr);
                                    i++;
                                }
                                
                            }
                        }
                    }
                }
            }
        }

    }
}
