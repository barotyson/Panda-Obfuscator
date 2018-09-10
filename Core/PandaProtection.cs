using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public abstract class PandaProtection
    {
        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract string Id { get; }
        public abstract string Author { get; }
        public abstract void Register(PandaContext pandaContext);
        public abstract void Execute(PandaContext pandaContext);
    }
}
