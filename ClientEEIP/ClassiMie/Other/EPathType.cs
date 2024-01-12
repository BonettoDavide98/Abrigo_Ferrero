using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientEEIP.ClassiMie.Other
{
    public class EPathType
    {
       ushort[] Path;



        public EPathType() { }

        public EPathType(List<ushort> path)
        {
            Path = path.ToArray();
        }

        public EPathType(ushort[] path)
        {
            Path = path;
        }
    }
}
