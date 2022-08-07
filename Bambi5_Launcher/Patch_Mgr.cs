using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collei_Launcher
{
    public static class Patch_Mgr
    {
        public static int Patch_Bytes(ref byte[] filebytes)
        {
            int count = 0;
            byte[] data = decrypt(filebytes);
            Array.Resize<byte>(ref data, data.Length - 16384);
            data = ReplaceBytes(data, Encoding.UTF8.GetBytes(strings.Nopatch1), Encoding.UTF8.GetBytes(strings.Patched1), ref count);
            if (FindBytes(data, Encoding.UTF8.GetBytes(strings.Features_cn)) >= 0)
            {
                data = ReplaceBytes(data, Encoding.UTF8.GetBytes(strings.Nopatch2_cn), Encoding.UTF8.GetBytes(strings.Patched2), ref count);
            }
            else if (FindBytes(data, Encoding.UTF8.GetBytes(strings.Features_os)) >= 0)
            {
                data = ReplaceBytes(data, Encoding.UTF8.GetBytes(strings.Nopatch2_os), Encoding.UTF8.GetBytes(strings.Patched2), ref count);
            }
            Array.Resize<byte>(ref data, data.Length + 16384);
            filebytes = encrypt(data);
            return count;
        }
        public static int UnPatch_Bytes(ref byte[] filebytes)
        {
            int count = 0;
            byte[] data = decrypt(filebytes);
            Array.Resize<byte>(ref data, data.Length - 16384);
            data = ReplaceBytes(data, Encoding.UTF8.GetBytes(strings.Patched1), Encoding.UTF8.GetBytes(strings.Nopatch1), ref count);
            if (FindBytes(data, Encoding.UTF8.GetBytes(strings.Features_cn)) >= 0)
            {
                data = ReplaceBytes(data, Encoding.UTF8.GetBytes(strings.Patched2), Encoding.UTF8.GetBytes(strings.Nopatch2_cn), ref count);
            }
            else if (FindBytes(data, Encoding.UTF8.GetBytes(strings.Features_os)) >= 0)
            {
                data = ReplaceBytes(data, Encoding.UTF8.GetBytes(strings.Patched2), Encoding.UTF8.GetBytes(strings.Nopatch2_os), ref count);
            }
            Array.Resize<byte>(ref data, data.Length + 16384);
            filebytes = encrypt(data);
            return count;
        }
        public static int Patch_File(string inpath, string outpath)
        {
            byte[] data = File.ReadAllBytes(inpath);
            int count = Patch_Bytes(ref data);
            FileStream stream = File.Create(outpath);
            stream.Write(data, 0, data.Length);
            stream.Close();
            return count;
        }
        public static int UnPatch_File(string inpath, string outpath)
        {

            byte[] data = File.ReadAllBytes(inpath);
            int count = UnPatch_Bytes(ref data);
            FileStream stream = File.Create(outpath);
            stream.Write(data, 0, data.Length);
            stream.Close();
            return count;
        }
        public static int FindBytes(byte[] src, byte[] find)
        {
            int index = -1;
            int matchIndex = 0;

            for (int i = 0; i < src.Length; i++)
            {
                if (src[i] == find[matchIndex])
                {
                    if (matchIndex == (find.Length - 1))
                    {
                        index = i - matchIndex;
                        break;
                    }
                    matchIndex++;
                }
                else
                {
                    matchIndex = 0;
                }

            }
            return index;
        }

        public static byte[] ReplaceBytes(byte[] src, byte[] search, byte[] repl, ref int i)
        {
            byte[] dst = src;
            int index = FindBytes(src, search);
            if (index == -1)
            {
                return src;
            }
            if (index >= 0)
            {
                dst = new byte[src.Length - search.Length + repl.Length];

                Buffer.BlockCopy(src, 0, dst, 0, index);

                Buffer.BlockCopy(repl, 0, dst, index, repl.Length);

                Buffer.BlockCopy(
                    src,
                    index + search.Length,
                    dst,
                    index + repl.Length,
                    src.Length - (index + search.Length));
            }
            i++;
            return dst;
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
