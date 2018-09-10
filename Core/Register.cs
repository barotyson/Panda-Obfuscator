using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Register
    {
        private List<PandaProtection> registredModules;
        public Register()
        {
            if (registredModules == null)
                registredModules = new List<PandaProtection>();
        }
        public void RegisterModule(PandaProtection pandaProtection)
        {
            if (pandaProtection == null)
                new ArgumentNullException("pandaProtection cannot be null!");
            if (pandaProtection.Name == null)
                new ArgumentNullException("pandaProtection.Name cannot be null!");
            if (pandaProtection.Description == null)
                new ArgumentNullException("pandaProtection.Description cannot be null!");
            if (pandaProtection.Id == null)
                new ArgumentNullException("pandaProtection.Id cannot be null!");
            if (pandaProtection.Author == null)
                new ArgumentNullException("pandaProtection.Author cannot be null!");
            registredModules.Add(pandaProtection);
        }
        public List<PandaProtection> getRegistredModules() { return registredModules; }
    }
}
