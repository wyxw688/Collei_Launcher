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
        public static string Patch_Bytes(ref byte[] filebytes, Patch_Config pc)
        {
            int count = 0;
            Channel? channel = null;
            if (!pc.CheckChannel)
            {
                channel = pc.SetChannel;
            }
            else
            {
                if(Methods.FindBytes(filebytes, Methods.ToUABytes(pc.Features_cn)) >= 0)
                {
                    channel = Channel.CN;
                }
                else if(Methods.FindBytes(filebytes, Methods.ToUABytes(pc.Features_os)) >= 0)
                {
                    channel = Channel.OS;
                }
            }
            if (channel == Channel.CN)
            {
                filebytes = Methods.ReplaceBytes(filebytes, Methods.ToUABytes(pc.Nopatch2_cn), Methods.ToUABytes(pc.Patched2_UA), ref count);
            }
            else if(channel == Channel.OS)
            {
                filebytes = Methods.ReplaceBytes(filebytes, Methods.ToUABytes(pc.Nopatch2_os), Methods.ToUABytes(pc.Patched2_UA), ref count);
            }
            string str = count != 0 ? "修补成功," : "修补失败,";
            str += pc.CheckChannel ? "当前渠道:" : "您选择的渠道:";
            str += channel != null ? channel.ToString() : "未知";
            return str;
        }
        public static string Patch_File(string inpath, string outpath, Patch_Config pc)
        {
            byte[] data = File.ReadAllBytes(inpath);
            string ret = Patch_Bytes(ref data, pc);
            FileStream stream = File.Create(outpath);
            stream.Write(data, 0, data.Length);
            stream.Close();
            return ret;
        }
        public static string UnPatch_Bytes(ref byte[] filebytes, Patch_Config pc)
        {
            int count = 0;
            Channel? channel = null;
            if (!pc.CheckChannel)
            {
                channel = pc.SetChannel;
            }
            else
            {
                if (Methods.FindBytes(filebytes, Methods.ToUABytes(pc.Features_cn)) >= 0)
                {
                    channel = Channel.CN;
                }
                else if (Methods.FindBytes(filebytes, Methods.ToUABytes(pc.Features_os)) >= 0)
                {
                    channel = Channel.OS;
                }
            }
            if (channel == Channel.CN)
            {
                filebytes = Methods.ReplaceBytes(filebytes, Methods.ToUABytes(pc.Patched2_UA), Methods.ToUABytes(pc.Nopatch2_cn), ref count);
            }
            else if (channel == Channel.OS)
            {
                filebytes = Methods.ReplaceBytes(filebytes, Methods.ToUABytes(pc.Patched2_UA), Methods.ToUABytes(pc.Nopatch2_os), ref count);
            }
            string str = count != 0 ? "反修补成功," : "反修补失败,";
            str += pc.CheckChannel ? "当前渠道:" : "您选择的渠道:";
            str += channel != null ? channel.ToString() : "未知";
            return str;
        }
        public static string UnPatch_File(string inpath, string outpath, Patch_Config pc)
        {
            byte[] data = File.ReadAllBytes(inpath);
            string ret = UnPatch_Bytes(ref data, pc);
            FileStream stream = File.Create(outpath);
            stream.Write(data, 0, data.Length);
            stream.Close();
            return ret;
        }
    }
}
