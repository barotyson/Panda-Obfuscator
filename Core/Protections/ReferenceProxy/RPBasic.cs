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
    public class RPBasic
    {
        private List<MethodDef> usedMethods = new List<MethodDef>();
        private Generator generator = new Generator();
        public void Excute(PandaContext pandaContext)
        {
            RPHelper rPHelper = new RPHelper();
            DnlibUtils.fixProxy(pandaContext.moduleDef);
            foreach (TypeDef type in pandaContext.moduleDef.Types.ToArray())
            {
                foreach (MethodDef method in type.Methods.ToArray())
                {
                    if (usedMethods.Contains(method)) continue;
                    if (ObfuscationUtils.ObfuscationMethodUtil.canObfuscate(method))
                    {
                        foreach (Instruction instruction in method.Body.Instructions.ToArray())
                        {

                            if (instruction.OpCode == OpCodes.Newobj)
                            {
                                IMethodDefOrRef methodDefOrRef = instruction.Operand as IMethodDefOrRef;
                                if (methodDefOrRef.IsMethodSpec) continue;
                                if (methodDefOrRef == null) continue;
                                MethodDef methodDef = rPHelper.GenerateMethod(methodDefOrRef, method);
                                if (methodDef == null) continue;
                                method.DeclaringType.Methods.Add(methodDef);
                                usedMethods.Add(methodDef);
                                instruction.OpCode = OpCodes.Call;
                                instruction.Operand = methodDef;
                                usedMethods.Add(methodDef);
                            }
                            else if (instruction.OpCode == OpCodes.Stfld)
                            {
                                FieldDef targetField = instruction.Operand as FieldDef;
                                if (targetField == null) continue;
                                CilBody body = new CilBody();
                                body.Instructions.Add(OpCodes.Nop.ToInstruction());
                                body.Instructions.Add(OpCodes.Ldarg_0.ToInstruction());
                                body.Instructions.Add(OpCodes.Ldarg_1.ToInstruction());
                                body.Instructions.Add(OpCodes.Stfld.ToInstruction(targetField));
                                body.Instructions.Add(OpCodes.Ret.ToInstruction());

                                var sig = MethodSig.CreateInstance(pandaContext.moduleDef.CorLibTypes.Void, targetField.FieldSig.GetFieldType());
                                sig.HasThis = true;
                                MethodDefUser methodDefUser = new MethodDefUser(generator.Generate<string>(GeneratorType.String, 10), sig)
                                {
                                    Body = body,
                                    IsHideBySig = true
                                };
                                usedMethods.Add(methodDefUser);
                                method.DeclaringType.Methods.Add(methodDefUser);
                                instruction.Operand = methodDefUser;
                                instruction.OpCode = OpCodes.Call;
                            }
                            
                        }

                    }
                }
            }
        }
    }
}
