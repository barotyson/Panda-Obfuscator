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
    class RPHelper
    {
        private Generator generator = new Generator();
        public MethodDef GenerateMethod(TypeDef declaringType, object targetMethod, bool hasThis = false, bool isVoid = false)
        {
            MemberRef methodReference = (MemberRef)targetMethod;
            MethodDef methodDefinition = new MethodDefUser(System.IO.Path.GetRandomFileName().Replace(".", ""), MethodSig.CreateStatic((methodReference).ReturnType), MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static);
            methodDefinition.Body = new CilBody();
            if (hasThis)
                methodDefinition.MethodSig.Params.Add(declaringType.Module.Import(declaringType.ToTypeSig()));
            foreach (TypeSig current in methodReference.MethodSig.Params)
                methodDefinition.MethodSig.Params.Add(current);
            methodDefinition.Parameters.UpdateParameterTypes();
            foreach (var current in methodDefinition.Parameters)
                methodDefinition.Body.Instructions.Add(Instruction.Create(OpCodes.Ldarg, current));
            methodDefinition.Body.Instructions.Add(Instruction.Create(OpCodes.Call, methodReference));

            methodDefinition.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
            return methodDefinition;
        }
        public MethodDef GenerateMethod(IMethod targetMethod, MethodDef md)
        {

            MethodDef methodDef = new MethodDefUser(generator.Generate<string>(GeneratorType.String, 10), MethodSig.CreateStatic(md.Module.Import(targetMethod.DeclaringType.ToTypeSig())), MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static);
            methodDef.ImplAttributes = MethodImplAttributes.Managed | MethodImplAttributes.IL;
            methodDef.IsHideBySig = true;
            methodDef.Body = new CilBody();
            for (int x = 0; x < targetMethod.MethodSig.Params.Count; x++)
            {
                methodDef.ParamDefs.Add(new ParamDefUser(generator.Generate<string>(GeneratorType.String, 10), (ushort)(x + 1)));
                methodDef.MethodSig.Params.Add(targetMethod.MethodSig.Params[x]);
            }
            methodDef.Parameters.UpdateParameterTypes();
            for (int x = 0; x < methodDef.Parameters.Count; x++)
            {
                Parameter parameter = methodDef.Parameters[x];
                methodDef.Body.Instructions.Add(new Instruction(OpCodes.Ldarg, parameter));
            }
            methodDef.Body.Instructions.Add(new Instruction(OpCodes.Newobj, targetMethod));
            methodDef.Body.Instructions.Add(new Instruction(OpCodes.Ret));
            return methodDef;
        }
        public MethodDef GenerateMethod(FieldDef targetField, MethodDef md)
        {
            MethodDef methodDefinition = new MethodDefUser(generator.Generate<string>(GeneratorType.String, 10), MethodSig.CreateStatic(md.Module.Import(targetField.FieldType)), MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static);
            methodDefinition.Body = new CilBody();
            TypeDef declaringType = md.DeclaringType;
            methodDefinition.MethodSig.Params.Add(md.Module.Import(declaringType).ToTypeSig());

            methodDefinition.Body.Instructions.Add(Instruction.Create(OpCodes.Ldarg_0));
            methodDefinition.Body.Instructions.Add(Instruction.Create(OpCodes.Ldfld, targetField));
            methodDefinition.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
            md.DeclaringType.Methods.Add(methodDefinition);
            return methodDefinition;
        }
    }
}
