using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CRTE
{
    class readWrite
    {
        public static void writePass(string newPass)
        {
            File.WriteAllText("breakPoint.rtv",newPass);
        }

        public static string readPass()
        {
            return File.ReadAllText("breakPoint.rtv");
        }
    }
}
