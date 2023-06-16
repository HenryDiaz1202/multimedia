using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace Imagenes
{
    class FondoPantallaClase
    {
        private const uint SPI_SETDESKWALLPAPER = 20;
        private const uint SPIF_UPDATEINIFILE = 0x01;
        private const uint SPIF_SENDWINICHANGE = 0x02;
        [System.Runtime.InteropServices.DllImport("User32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SystemParametersInfo(uint uiAction,uint uiParam, string pvParam, uint fwinIni);
        public static void EstablecerFondo(string path)
        {
            if(!SystemParametersInfo(SPI_SETDESKWALLPAPER,0,path,SPIF_UPDATEINIFILE | SPIF_SENDWINICHANGE))
            {
                throw new Win32Exception();
            }
        }
    }
}
