using Core.Helper;
using Core.Helper.DnlibUtils;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Protections.ControlFlow
{
    public class ControlFlow
    {
        public ControlFlow(PandaState pandaState, PandaContext pandaContext)
        {
            if (pandaContext != null)
                Execute(pandaState, pandaContext);

            new ArgumentNullException("pandaContext cannot be null");
        }
        public void Execute(PandaState pandaState, PandaContext pandaContext)
        {
            CFHelper cFHelper = new CFHelper();
            foreach (TypeDef type in pandaContext.moduleDef.Types)
            {
                foreach (MethodDef method in type.Methods)
                {
                    if (method.HasBody && method.Body.Instructions.Count > 0 && !method.IsConstructor)
                    {
                        if (!cFHelper.HasUnsafeInstructions(method))
                        {
                            if (DnlibUtils.Simplify(method))
                            {
                                Blocks blocks = cFHelper.GetBlocks(method);
                                if (blocks.blocks.Count != 1)
                                {
                                    switch (pandaState)
                                    {
                                        case PandaState.Basic:
                                            toDoSwitcher(cFHelper, method, blocks, pandaContext);
                                            break;
                                        case PandaState.Normal:
                                            toDoBody(cFHelper, method, blocks, pandaContext);
                                            break;
                                    }
                                }
                                DnlibUtils.Optimize(method);
                            }
                        }
                    }

                }
            }
        }
        public void toDoSwitcher(CFHelper cFHelper, MethodDef method, Blocks blocks, PandaContext pandaContext)
        {
            List<Instruction> instructionsOperand = new List<Instruction>();
            method.Body.Instructions.Clear();

            Local local = new Local(pandaContext.moduleDef.CorLibTypes.Int32);
            method.Body.Variables.Add(local);
            foreach (Instruction instruction in cFHelper.Calc(0))
                method.Body.Instructions.Add(instruction);
            method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
            Instruction target = Instruction.Create(OpCodes.Nop);
            method.Body.Instructions.Add(target);
            method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
            Instruction targetSwitch = Instruction.Create(OpCodes.Switch, instructionsOperand);
            method.Body.Instructions.Add(targetSwitch);
            method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, blocks.getBlock((blocks.blocks.Count - 1)).instructions[blocks.getBlock((blocks.blocks.Count - 1)).instructions.Count - 1]));

            foreach (Block block in blocks.blocks)
            {
                if (block != blocks.getBlock((blocks.blocks.Count - 1)))
                {

                    Instruction instr = Instruction.Create(OpCodes.Stloc, local);
                    instructionsOperand.Add(block.instructions[0]);
                    Instruction instruction4 = Instruction.Create(OpCodes.Nop);
                    foreach (Instruction instruction in block.instructions)
                        method.Body.Instructions.Add(instruction);
                    foreach (Instruction instruction in cFHelper.Calc(block.nextBlock))
                        method.Body.Instructions.Add(instruction);
                    method.Body.Instructions.Add(instr);
                    method.Body.Instructions.Add(instruction4);
                    method.Body.Instructions.Add(new Instruction(OpCodes.Br, target));
                    method.Body.Instructions.Add(instruction4);
                }
            }
            method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, blocks.getBlock((blocks.blocks.Count - 1)).instructions[0]));
            method.Body.Instructions.Add(new Instruction(OpCodes.Br, target));
            foreach (Instruction lastBlock in blocks.getBlock((blocks.blocks.Count - 1)).instructions)
                method.Body.Instructions.Add(lastBlock);

            instructionsOperand.Add(blocks.getBlock((blocks.blocks.Count - 1)).instructions[0]);

            targetSwitch.Operand = instructionsOperand;
        }
        public void toDoBody(CFHelper cFHelper, MethodDef method, Blocks blocks, PandaContext pandaContext)
        {
            blocks.Scramble(out blocks);
            method.Body.Instructions.Clear();
            Local local = new Local(pandaContext.moduleDef.CorLibTypes.Int32);
            method.Body.Variables.Add(local);
            Instruction target = Instruction.Create(OpCodes.Nop);
            Instruction instr = Instruction.Create(OpCodes.Br, target);
            foreach (Instruction instruction in cFHelper.Calc(0))
                method.Body.Instructions.Add(instruction);
            method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
            method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, instr));
            method.Body.Instructions.Add(target);
            foreach (Block block in blocks.blocks)
            {
                if (block != blocks.getBlock((blocks.blocks.Count - 1)))
                {
                    method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
                    foreach (Instruction instruction in cFHelper.Calc(block.ID))
                        method.Body.Instructions.Add(instruction);
                    method.Body.Instructions.Add(Instruction.Create(OpCodes.Ceq));
                    Instruction instruction4 = Instruction.Create(OpCodes.Nop);
                    method.Body.Instructions.Add(Instruction.Create(OpCodes.Brfalse, instruction4));
                    foreach (Instruction instruction in block.instructions)
                        method.Body.Instructions.Add(instruction);
                    foreach (Instruction instruction in cFHelper.Calc(block.nextBlock))
                        method.Body.Instructions.Add(instruction);

                    method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
                    method.Body.Instructions.Add(instruction4);
                }
            }
            method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
            foreach (Instruction instruction in cFHelper.Calc(blocks.blocks.Count - 1))
                method.Body.Instructions.Add(instruction);
            method.Body.Instructions.Add(Instruction.Create(OpCodes.Ceq));
            method.Body.Instructions.Add(Instruction.Create(OpCodes.Brfalse, instr));
            method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, blocks.getBlock((blocks.blocks.Count - 1)).instructions[0]));
            method.Body.Instructions.Add(instr);
            foreach (Instruction lastBlock in blocks.getBlock((blocks.blocks.Count - 1)).instructions)
                method.Body.Instructions.Add(lastBlock);

        }
    }
}
