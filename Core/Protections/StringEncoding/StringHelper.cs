using Core.Helper.DnlibUtils;
using dnlib.DotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Protections.StringEncoding
{
    public class StringHelper
    {
        public string Encrypt(string str)
        {
            int key = 8204;
            StringBuilder stringBuilder = new StringBuilder();
            string based = Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(str));
            foreach (char strings in based.ToCharArray())
            {
                for (int i = 0; i < strings; i++)
                {
                    stringBuilder.Append(Convert.ToChar(key));
                }
                stringBuilder.Append("A");
            }
            return stringBuilder.ToString();
        }

        public MethodDef Inject(ModuleDef asmDef)
        {
            ModuleDefMD typeModule = ModuleDefMD.Load(typeof(RuntimeHelper).Module);
            TypeDef typeDef = typeModule.ResolveTypeDef(MDToken.ToRID(typeof(RuntimeHelper).MetadataToken));
            TypeDef panda = new TypeDefUser("Panda", asmDef.CorLibTypes.Object.TypeDefOrRef);
            panda.Attributes = TypeAttributes.Public | TypeAttributes.AutoLayout |
                                    TypeAttributes.Class | TypeAttributes.AnsiClass;
            asmDef.Types.Add(panda);
            IEnumerable<IDnlibDef> members = InjectHelper.Inject(typeDef, panda, asmDef);
            var init = (MethodDef)members.Single(methodddd => methodddd.Name == "k");
            return init;
        }
    }
}
