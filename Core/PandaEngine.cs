using Core.Helper.DnlibUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class PandaEngine
    {
        PandaContext _pandaContext;
        PandaModuleManager moduleManager;
        public PandaEngine(PandaContext pandaContext)
        {
            if (pandaContext == null)
                new ArgumentNullException("pandaContext is null!");
            _pandaContext = pandaContext;
            moduleManager = new PandaModuleManager();
            foreach (PandaProtection p in moduleManager.pandaProtections())
                p.Register(pandaContext);
        }
        public List<PandaProtection> GetPandaProtections() { return _pandaContext.GetPandaProtection(); }

        public bool runModules(PandaContext pandaContext)
        {
            new PandaMarker().Execute(pandaContext);
            if (pandaContext.pandaIG.getIGModules() == null)
                return false;
            if (pandaContext.pandaIG.getIGModules().Count == 0)
                return false;

            foreach (PandaProtection p in pandaContext.register.getRegistredModules())
            {
                foreach (PandaProtection panda in pandaContext.pandaIG.getIGModules())
                    if (p.Id == panda.Id)
                        panda.Execute(pandaContext);
            }


            
            return true;
        }
    }
}
