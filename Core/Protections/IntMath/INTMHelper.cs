using Core.Helper.Generator.Context;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Protections.IntMath
{
    public class INTMHelper
    {
        private Generator generator = new Generator();
        public List<Instruction> Calc(int value)
        {
            List<Instruction> instructions = new List<Instruction>();
            int num = generator.Generate<int>(GeneratorType.Integer, 10000);
            bool once = Convert.ToBoolean(generator.Generate<int>(GeneratorType.Integer, 2));
            int num1 = generator.Generate<int>(GeneratorType.Integer, 10000);
            instructions.Add(Instruction.Create(OpCodes.Ldc_I4, value - num + (once ? (0 - num1) : num1)));
            instructions.Add(Instruction.Create(OpCodes.Ldc_I4, num));
            instructions.Add(Instruction.Create(OpCodes.Add));
            instructions.Add(Instruction.Create(OpCodes.Ldc_I4, num1));
            instructions.Add(Instruction.Create(once ? OpCodes.Add : OpCodes.Sub));
            return instructions;
        }
    }
}
