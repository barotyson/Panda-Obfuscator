using Core.Helper.DnlibUtils;
using Core.Protections.ReferenceProxy;
using dnlib.DotNet;
using dnlib.DotNet.Writer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class PandaContext
    {
        public List<PandaProtection> pandaProtections;
        public ModuleDef moduleDef;
        public ModuleWriterOptions moduleWriterOptions;
        public Register register;
        public PandaIG pandaIG;
        string _path;
        public PandaContext(String path)
        {
            moduleDef = ModuleDefMD.Load(path);
            _path = path;
            pandaProtections = new List<PandaProtection>();
            register = new Register();
            pandaIG = new PandaIG();
        }
        public string newPath()
        {
            string basePath = Path.GetDirectoryName(_path);
            string newDirectoryName = Directory.CreateDirectory(Path.Combine(basePath, "PandaObfuscator\\")).FullName;
            return Path.Combine(newDirectoryName + Path.GetFileName(_path));
        }
        
        public bool Write()
        {
            return Write(newPath());
        }
        public bool Write(string path)
        {
            try{
                
                moduleWriterOptions = new ModuleWriterOptions(moduleDef);
                moduleWriterOptions.Logger = DummyLogger.NoThrowInstance;
                moduleDef.Write(path, moduleWriterOptions);
                return true;
            }catch(Exception e) {
                return false;
            }
        }
        public List<PandaProtection> GetPandaProtection() { return register.getRegistredModules(); }
        public List<PandaProtection> getIGModules() { return pandaIG.getIGModules(); }
        public void addIGModule(PandaProtection pandaProtection)
        {
            pandaIG.RegisterIGModule(pandaProtection);
        }
        public void removeIGModule(PandaProtection pandaProtection)
        {
            pandaIG.UnRegisterIGModule(pandaProtection);
        }
    }
}
