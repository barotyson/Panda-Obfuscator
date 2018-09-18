using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Protections.StringEncoding
{
    public class RuntimeHelper
    {
        public static string k(string str)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string strings in str.Split(new char[] { 'A' }))
            {
                stringBuilder.Append(Convert.ToChar(strings.Length) + "");
            }
            return UTF8Encoding.UTF8.GetString(Convert.FromBase64String(stringBuilder.ToString().Substring(0, stringBuilder.ToString().Length - 1)));
        }
    }
}
