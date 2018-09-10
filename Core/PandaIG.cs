using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class PandaIG
    {
        private List<PandaProtection> pandaProtections;
        public PandaIG()
        {
            pandaProtections = new List<PandaProtection>();
        }
        public void RegisterIGModule(PandaProtection pandaProtection)
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
            pandaProtections.Add(pandaProtection);
        }
        public void UnRegisterIGModule(PandaProtection pandaProtection)
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
            pandaProtections.Remove(pandaProtection);
        }
        public bool contains(String pandaProtectionID)
        {
            foreach (PandaProtection panda in getIGModules())
                if (panda.Id == pandaProtectionID)
                    return true;
            return false;
        }
        public List<PandaProtection> getIGModules() { return pandaProtections; }
    }
}
