using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collei_Launcher
{
    public static class UA_Patch_Mgr
    {
        public static string Patch_Bytes(ref byte[] filebytes, Patch_Config pc, Channel channel)
        {
            int count = 0;
            if (channel == Channel.CN)
            {
                filebytes = Methods.ReplaceBytes(filebytes, Methods.ToUABytes(pc.Nopatch2_cn), Methods.ToUABytes(pc.Patched2_UA), ref count);
            }
            else if(channel == Channel.OS)
            {
                filebytes = Methods.ReplaceBytes(filebytes, Methods.ToUABytes(pc.Nopatch2_os), Methods.ToUABytes(pc.Patched2_UA), ref count);
            }
            return $"替换了{count}次";
        }
        public static string Patch_File(string inpath, string outpath, Patch_Config pc,Channel channel)
        {
            byte[] data = File.ReadAllBytes(inpath);
            string ret = Patch_Bytes(ref data, pc,channel);
            FileStream stream = File.Create(outpath);
            stream.Write(data, 0, data.Length);
            stream.Close();
            return ret;
        }
        public static string UnPatch_Bytes(ref byte[] filebytes, Patch_Config pc, Channel channel)
        {
            int count = 0;
            if (channel == Channel.CN)
            {
                filebytes = Methods.ReplaceBytes(filebytes, Methods.ToUABytes(pc.Patched2_UA), Methods.ToUABytes(pc.Nopatch2_cn), ref count);
            }
            else if (channel == Channel.OS)
            {
                filebytes = Methods.ReplaceBytes(filebytes, Methods.ToUABytes(pc.Patched2_UA), Methods.ToUABytes(pc.Nopatch2_os), ref count);
            }
            return $"替换了{count}次";
        }
        public static string UnPatch_File(string inpath, string outpath, Patch_Config pc, Channel channel)
        {
            byte[] data = File.ReadAllBytes(inpath);
            string ret = UnPatch_Bytes(ref data, pc, channel);
            FileStream stream = File.Create(outpath);
            stream.Write(data, 0, data.Length);
            stream.Close();
            return ret;
        }
    }
}
