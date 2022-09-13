using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collei_Launcher
{
    public static class Meta_Patch_Mgr
    {
        public static string Patch_Bytes(ref byte[] filebytes,Patch_Config pc)
        {
            StringBuilder rets = new StringBuilder();
            int count = 0;
            string channel = "未知";
            byte[] data = decrypt(filebytes);
            Array.Resize<byte>(ref data, data.Length - 16384);
            if (pc.PatchP1)
            {
                data = Methods.ReplaceBytes(data, Methods.ToFixBytesP1(pc.Nopatch1), Methods.ToFixBytesP1(pc.Patched1), ref count);
                if (count == 0)
                {
                    rets.AppendLine("出现错误:未找到目标(1)");
                }
            }
            int n = count;
            if (pc.CheckChannel)
            {
                if (Methods.FindBytes(data, Encoding.UTF8.GetBytes(pc.Features_cn)) >= 0)
                {
                    channel = "国服";
                    data = Methods.ReplaceBytes(data, Encoding.UTF8.GetBytes(pc.Nopatch2_cn), Encoding.UTF8.GetBytes(pc.Patched2_Meta), ref count);

                    if (count == n)
                    {
                        rets.AppendLine("出现错误:未找到目标(2) - CN");
                    }
                }
                else if (Methods.FindBytes(data, Encoding.UTF8.GetBytes(pc.Features_os)) >= 0)
                {
                    channel = "国际服";
                    data = Methods.ReplaceBytes(data, Encoding.UTF8.GetBytes(pc.Nopatch2_os), Encoding.UTF8.GetBytes(pc.Patched2_Meta), ref count);
                    if (count == n)
                    {
                        rets.AppendLine("出现错误:未找到目标(2) - OS");
                    }
                }
                else
                {
                    rets.AppendLine("出现错误:判断渠道失败(未找到特征)");
                }
            }
            else
            {
                if (pc.SetChannel == Channel.CN)
                {
                    channel = "国服";
                    data = Methods.ReplaceBytes(data, Encoding.UTF8.GetBytes(pc.Nopatch2_cn), Encoding.UTF8.GetBytes(pc.Patched2_Meta), ref count);

                    if (count == n)
                    {
                        rets.AppendLine("出现错误:未找到目标(2) - CN");
                    }
                }
                else if (pc.SetChannel == Channel.OS)
                {
                    channel = "国际服";
                    data = Methods.ReplaceBytes(data, Encoding.UTF8.GetBytes(pc.Nopatch2_os), Encoding.UTF8.GetBytes(pc.Patched2_Meta), ref count);
                    if (count == n)
                    {
                        rets.AppendLine("出现错误:未找到目标(2) - OS");
                    }
                }
            }
            Array.Resize<byte>(ref data, data.Length + 16384);
            filebytes = encrypt(data);

            rets.AppendLine("***************************************************************");
            if (pc.CheckChannel)
            {
                rets.AppendLine($"替换了{count}次,当前渠道:{channel}");
            }
            else
            {
                rets.AppendLine($"替换了{count}次,您选择的渠道:{channel}");
            }
            return rets.ToString();
        }
        public static string UnPatch_Bytes(ref byte[] filebytes,Patch_Config pc)
        {
            StringBuilder rets = new StringBuilder();
            int count = 0;
            string channel = "未知";
            byte[] data = decrypt(filebytes);
            Array.Resize<byte>(ref data, data.Length - 16384);

            if (pc.PatchP1)
            {
                data = Methods.ReplaceBytes(data, Methods.ToFixBytesP1(pc.Patched1), Methods.ToFixBytesP1(pc.Nopatch1), ref count);
                if (count == 0)
                {
                    rets.AppendLine("出现错误:未找到目标(1)");
                }
            }
            int n = count;
            if (pc.CheckChannel)
            {
                if (Methods.FindBytes(data, Encoding.UTF8.GetBytes(pc.Features_cn)) >= 0)
                {
                    channel = "国服";
                    data = Methods.ReplaceBytes(data, Encoding.UTF8.GetBytes(pc.Patched2_Meta), Encoding.UTF8.GetBytes(pc.Nopatch2_cn), ref count);
                    if (count == n)
                    {
                        rets.AppendLine("出现错误:未找到目标(2) - CN");
                    }
                }
                else if (Methods.FindBytes(data, Encoding.UTF8.GetBytes(pc.Features_os)) >= 0)
                {
                    channel = "国际服";
                    data = Methods.ReplaceBytes(data, Encoding.UTF8.GetBytes(pc.Patched2_Meta), Encoding.UTF8.GetBytes(pc.Nopatch2_os), ref count);
                    if (count == n)
                    {
                        rets.AppendLine("出现错误:未找到目标(2) - OS");
                    }
                }
                else
                {
                    rets.AppendLine("出现错误:判断渠道失败(未找到特征)");
                }
            }
            else
            {
                if (pc.SetChannel == Channel.CN)
                {
                    channel = "国服";
                    data = Methods.ReplaceBytes(data, Encoding.UTF8.GetBytes(pc.Patched2_Meta), Encoding.UTF8.GetBytes(pc.Nopatch2_cn), ref count);

                    if (count == n)
                    {
                        rets.AppendLine("出现错误:未找到特征(2) - CN");
                    }
                }
                else if (pc.SetChannel == Channel.OS)
                {
                    channel = "国际服";
                    data = Methods.ReplaceBytes(data, Encoding.UTF8.GetBytes(pc.Patched2_Meta), Encoding.UTF8.GetBytes(pc.Nopatch2_os), ref count);
                    if (count == n)
                    {
                        rets.AppendLine("出现错误:未找到特征(2) - OS");
                    }
                }
            }
            Array.Resize<byte>(ref data, data.Length + 16384);
            filebytes = encrypt(data);

            rets.AppendLine("***************************************************************"); 
            if (pc.CheckChannel)
            {
                rets.AppendLine($"替换了{count}次,当前渠道:{channel}");
            }
            else
            {
                rets.AppendLine($"替换了{count}次,您选择的渠道:{channel}");
            }
            return rets.ToString();
        }
        public static string Patch_File(string inpath, string outpath,Patch_Config pc)
        {
            byte[] data = File.ReadAllBytes(inpath);
            string ret = Patch_Bytes(ref data,pc);
            FileStream stream = File.Create(outpath);
            stream.Write(data, 0, data.Length);
            stream.Close();
            return ret;
        }
        public static string UnPatch_File(string inpath, string outpath,Patch_Config pc)
        {

            byte[] data = File.ReadAllBytes(inpath);
            string ret = UnPatch_Bytes(ref data,pc);
            FileStream stream = File.Create(outpath);
            stream.Write(data, 0, data.Length);
            stream.Close();
            return ret;
        }
        public static void Decrypt_File(string inpath, string outpath)
        {
            byte[] filebytes = File.ReadAllBytes(inpath);
            byte[] data = decrypt(filebytes);
            Array.Resize<byte>(ref data, data.Length - 16384);
            FileStream stream = File.Create(outpath);
            stream.Write(data, 0, data.Length);
            stream.Close();
        }
        public static void Encrypt_File(string inpath, string outpath)
        {
            byte[] filebytes = File.ReadAllBytes(inpath);
            Array.Resize<byte>(ref filebytes, filebytes.Length + 16384);
            byte[] data = encrypt(filebytes);
            FileStream stream = File.Create(outpath);
            stream.Write(data, 0, data.Length);
            stream.Close();
        }
        unsafe static public byte[] decrypt(byte[] bytes)
        {
            fixed (byte* d1 = bytes)
            {
                Patch_Meta patch_Meta = new Patch_Meta();
                patch_Meta.decrypt_global_metadata(d1, Convert.ToUInt64(bytes.Length));
                return bytes;
            }
        }
        unsafe static public byte[] encrypt(byte[] bytes)
        {
            fixed (byte* d1 = bytes)
            {
                Patch_Meta patch_Meta = new Patch_Meta();
                patch_Meta.encrypt_global_metadata(d1, Convert.ToUInt64(bytes.Length));
                return bytes;
            }
        }

    }

}
