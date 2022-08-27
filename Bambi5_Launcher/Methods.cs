using Collei_Launcher;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public static class Methods
{
    /// <summary>
    /// 16进制原码字符串转字节数组
    /// </summary>
    /// <param name="hexString">"AABBCC"或"AA BB CC"格式的字符串</param>
    /// <returns></returns>
    public static byte[] ConvertHexStringToBytes(string hexString)
    {
        try
        {
            hexString = hexString.Replace(" ", "");
            if (hexString.Length % 2 != 0)
            {
                MessageBox.Show("参数长度不正确", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
            {
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }
            return returnBytes;
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "在转换byte[]时出现错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
    }
    public static byte[] ToFixBytesP1(string key)
    {
        byte[] bp1 = Encoding.UTF8.GetBytes(key.Substring(0, 48));
        byte[] bp2 = Encoding.UTF8.GetBytes(key.Substring(48, 57));
        byte[] bp3 = Encoding.UTF8.GetBytes(key.Substring(105, 57));
        byte[] bp4 = Encoding.UTF8.GetBytes(key.Substring(162));
        byte[] ret = bp1.Concat(bytes).Concat(bp2).Concat(bytes).Concat(bp3).Concat(bytes).Concat(bp4).ToArray();
        return ret;

    }
    public static readonly long Pas = 0x4889501048BA;
    public static readonly long Pbs = 0x908000000048BA;
    public static readonly byte[] Pbb = { 0x48, 0x89 };

    public static byte[] GetBytesPa(int count)//0-13
    {
        byte[] pa = BitConverter.GetBytes(Pas + (0x80000 * count));
        Array.Resize(ref pa, 6);
        pa = pa.Reverse().ToArray();
        return pa;
    }
    public static byte[] GetBytesPb(int count)//0-28
    {
        byte[] pb = BitConverter.GetBytes(Pbs + (0x80000000000 * count));
        Array.Resize(ref pb, 7);
        byte[] pb2 = Pbb.Concat(pb.Reverse()).ToArray();
        if(count >=16)
        {
            pb2[2] = 0x90;
            pb2[4] = 0x01;
        }
        return pb2;
    }
    public static byte[] ToUABytes(string key)
    {
        int count = key.Length + 2;
        List<byte> uabytes = Encoding.UTF8.GetBytes(key).ToList();
        for (int i = 1; i < 44; i++)
        {
            if (i <= 29)
            {
                byte[] k = GetBytesPb(29 - i);
                for (int j = 0; j < k.Length; j++)
                {
                    uabytes.Insert(count - 8 * i, k[k.Length - 1 - j]);
                }
            }
            else
            {
                byte[] k = GetBytesPa(14 - (i - 29));
                for (int j = 0; j < k.Length; j++)
                {
                    uabytes.Insert(count - 8 * i, k[k.Length - 1 - j]);
                }
            }
        }
        return uabytes.ToArray();
    }
    /// <summary>
    /// 字节数组转16进制字符串：空格分隔
    /// </summary>
    /// <param name="byteDatas"></param>
    /// <returns></returns>
    public static string ToHexStrFromByte(this byte[] byteDatas)
    {
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < byteDatas.Length; i++)
        {
            builder.Append(string.Format("{0:X2} ", byteDatas[i]));
        }
        return builder.ToString().Trim();
    }
    public static byte[] bytes = { 0x0D, 0x0A, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
    public static bool DebugBuild(Assembly assembly)
    {
        foreach (object attribute in assembly.GetCustomAttributes(false))
        {
            if (attribute is DebuggableAttribute)
            {
                DebuggableAttribute _attribute = attribute as DebuggableAttribute;

                return _attribute.IsJITTrackingEnabled;
            }
        }
        return false;
    }
    public static string ConvertJsonString(string str)
    {
        //格式化json字符串
        JsonSerializer serializer = new JsonSerializer();
        TextReader tr = new StringReader(str);
        JsonTextReader jtr = new JsonTextReader(tr);
        object obj = serializer.Deserialize(jtr);
        if (obj != null)
        {
            StringWriter textWriter = new StringWriter();
            JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
            {
                Formatting = Formatting.Indented,
                Indentation = 4,
                IndentChar = ' '
            };
            serializer.Serialize(jsonWriter, obj);
            return textWriter.ToString();
        }
        else
        {
            return str;
        }
    }
    /// <summary>
    /// 将文件大小(字节)转换为最适合的显示方式
    /// </summary>
    /// <param name="size"></param>
    /// <returns></returns>
    public static string ConvertFileSize(long size)
    {
        string result = "0KB";
        int filelength = size.ToString().Length;
        if (filelength < 4)
            result = size + "byte";
        else if (filelength < 7)
            result = Math.Round(Convert.ToDouble(size / 1024d), 2) + "KB";
        else if (filelength < 10)
            result = Math.Round(Convert.ToDouble(size / 1024d / 1024), 2) + "MB";
        else if (filelength < 13)
            result = Math.Round(Convert.ToDouble(size / 1024d / 1024 / 1024), 2) + "GB";
        else
            result = Math.Round(Convert.ToDouble(size / 1024d / 1024 / 1024 / 1024), 2) + "TB";
        return result;
    }

    /// <summary>
    /// 指定Post地址使用Get 方式获取全部字符串
    /// </summary>
    /// <param name="url">请求后台地址</param>
    /// <param name="content">Post提交数据内容(utf-8编码的)</param>
    /// <returns></returns>
    public static string Post(string url, string content)
    {
        try
        {
            //ServicePointManager.Expect100Continue = true;
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            //ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, errors) => true;
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.Timeout = 2000;
            req.ContentType = "application/json";
            #region 添加Post 参数
            byte[] data = Encoding.UTF8.GetBytes(content);
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            #endregion

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }
        catch (Exception e)
        {
            Debug.Print(e.Message);
            return null;
        }
    }
    /// <summary>
    /// 获取当前的时间戳
    /// </summary>
    /// <returns></returns>
    public static string Timestamp()
    {
        long ts = ConvertDateTimeToInt(DateTime.Now);
        return ts.ToString();
    }

    /// <summary>  
    /// 将c# DateTime时间格式转换为Unix时间戳格式  
    /// </summary>  
    /// <param name="time">时间</param>  
    /// <returns>long</returns>  
    public static long ConvertDateTimeToInt(System.DateTime time)
    {
        //System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
        //long t = (time.Ticks - startTime.Ticks) / 10000;   //除10000调整为13位      
        long t = (time.Ticks - 621356256000000000) / 10000;
        return t;
    }
    public static DateTime getdate(long jsTimeStamp)
    {
        System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
        DateTime dt = startTime.AddMilliseconds(jsTimeStamp);
        return dt;
        //System.Console.WriteLine(dt.ToString("yyyy/MM/dd HH:mm:ss:ffff"));
    }
    /// <summary>
    /// 设置证书安全性
    /// </summary>
    public static void SetCertificatePolicy()
    {
        ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
    }
    ///  <summary>
    ///  远程证书验证
    ///  </summary>
    public static bool RemoteCertificateValidate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
    {
        return true;
    }
    public static bool isValidFileContent(string filePath1, string filePath2)
    {
        //创建一个哈希算法对象
        using (HashAlgorithm hash = HashAlgorithm.Create())
        {
            using (FileStream file1 = new FileStream(filePath1, FileMode.Open), file2 = new FileStream(filePath2, FileMode.Open))
            {
                byte[] hashByte1 = hash.ComputeHash(file1);//哈希算法根据文本得到哈希码的字节数组
                byte[] hashByte2 = hash.ComputeHash(file2);
                string str1 = BitConverter.ToString(hashByte1);//将字节数组装换为字符串
                string str2 = BitConverter.ToString(hashByte2);
                return (str1 == str2);//比较哈希码
            }
        }
    }

    public static string Get(string url)
    {
        try
        {
            //ServicePointManager.Expect100Continue = true;
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            //ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, errors) => true;
            DateTime st = DateTime.Now;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 3000;
            request.ContentType = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            var text = new StreamReader(response.GetResponseStream()).ReadToEnd();
            Debug.WriteLine(Methods.ConvertDateTimeToInt(response.LastModified) - Methods.ConvertDateTimeToInt(st) + "ms");
            response.Close();
            return text;
        }
        catch (Exception e)
        {
            Debug.Print(e.Message);
            return null;
        }
    }
    public static Index_Get Get_for_Index(string url)
    {
        var tk = Task.Run(() =>
        {
            //ServicePointManager.Expect100Continue = true;
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            //ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, errors) => true;
            DateTime st = DateTime.Now;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 3000;
            request.ContentType = "application/json";
            Index_Get res = new Index_Get();
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var text = new StreamReader(response.GetResponseStream()).ReadToEnd();
                res.Result = text;
                res.Use_time = Methods.ConvertDateTimeToInt(response.LastModified) - Methods.ConvertDateTimeToInt(st);
                res.StatusCode = response.StatusCode;
                response.Close();
                return res;
            }
            catch (WebException ex)
            {

                if (ex.Response == null)
                {
                    res.Result = ex.Message;
                    res.Use_time = -1;
                    //Console.WriteLine("ex.Response == null");
                    return res;
                }
                HttpWebResponse response = (HttpWebResponse)ex.Response;
                res.Use_time = Methods.ConvertDateTimeToInt(response.LastModified) - Methods.ConvertDateTimeToInt(st);
                res.StatusCode = response.StatusCode;
                res.Result = response.StatusDescription;
                Console.WriteLine("错误码:" + (int)response.StatusCode);
                Console.WriteLine("错误码描述:" + response.StatusDescription);
                return res;
            }
            catch (Exception e)
            {
                res.Use_time = -2;
                res.Result = e.Message; ;
                Debug.Print(e.Message);
                return null;
            }
        });
        tk.Wait(3000);
        return tk.Result;

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
#if DEBUG
        Debug.Print("FindCount:" + index);
#endif
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
    public static class GameRegReader
    {
        /// <summary>
        /// 获取游戏目录，是静态方法
        /// </summary>
        /// <returns></returns>
        public static string GetGamePath()
        {
            try
            {
                string startpath = "";
                string launcherpath = GetLauncherPath();
                #region 获取游戏启动路径，和官方配置一致
                string cfgPath = Path.Combine(launcherpath, "config.ini");
                if (File.Exists(launcherpath) || File.Exists(cfgPath))
                {
                    //获取游戏本体路径
                    using (StreamReader reader = new StreamReader(cfgPath))
                    {
                        string[] abc = reader.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.None);
                        foreach (var item in abc)
                        {
                            //从官方获取更多配置
                            if (item.IndexOf("game_install_path") != -1)
                            {
                                startpath += item.Substring(item.IndexOf("=") + 1);
                            }
                        }
                    }
                }
                byte[] bytearr = Encoding.UTF8.GetBytes(startpath);
                string path = Encoding.UTF8.GetString(bytearr);
                return path;
            }
            catch
            {
                return null;
            }
            #endregion
        }


        /// <summary>
        /// 启动器地址
        /// </summary>
        /// <returns></returns>
        public static string GetLauncherPath()
        {
            try
            {
                RegistryKey key = Registry.LocalMachine;            //打开指定注册表根
                                                                    //获取官方启动器路径
                string launcherpath = "";
                try
                {
                    launcherpath = key.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\原神").GetValue("InstallPath").ToString();


                }
                catch (Exception)
                {
                    launcherpath = key.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Genshin Impact").GetValue("InstallPath").ToString();

                }

                byte[] bytepath = Encoding.UTF8.GetBytes(launcherpath);     //编码转换
                string path = Encoding.UTF8.GetString(bytepath);
                return path;

            }
            catch
            {
                return null;
            }
        }

        public static string GetGameExePath()
        {

            var gamepath = GameRegReader.GetGamePath();
            if (gamepath == null)
            {
                return null;
            }
            var cnpath = gamepath + @"/YuanShen.exe";
            var ospath = gamepath + @"/GenshinImpact.exe";

            if (File.Exists(cnpath))
            {
                return cnpath;
            }
            else if (File.Exists(ospath))
            {
                return ospath;
            }
            else
            {
                return null;
            }
        }
    }
}

