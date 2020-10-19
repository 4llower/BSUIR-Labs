using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace subtask_1
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            int deskWidth = SystemInformation.VirtualScreen.Width;
            int deskHeight = SystemInformation.VirtualScreen.Height;
            Tetris App = new Tetris(deskWidth / 2, deskHeight / 2);
            
            while (true)
            {
                //Wait while app execute
            }
        }
    }
}
