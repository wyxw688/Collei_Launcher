using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Collei_Launcher
{
    internal static class ThirdPartyMgr
    {
        public static BinaryFormatter Formatter = new BinaryFormatter();
        public static string SettingPath = Application.StartupPath + "/TPSet";
        public static void LoadSettings()
        {
            if (File.Exists(SettingPath))
            {
                var fs = File.OpenRead(SettingPath);
                Main_Form.tps = (TPSet)Formatter.Deserialize(fs);
                fs.Close();
            }
            else
            {
                Debug.Print("Tps Not Found:" + SettingPath);
            }
            Main_Form.form.TpsApply();
        }
        public static void SaveSettings(TPSet tps)
        {
            Main_Form.tps = tps;
            var setfile = File.OpenWrite(SettingPath);
            Formatter.Serialize(setfile, tps);
            setfile.Close();
        }
    }
}
