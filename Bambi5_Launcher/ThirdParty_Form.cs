using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Collei_Launcher
{
    public partial class ThirdParty_Form : Form
    {
        public ThirdParty_Form()
        {
            InitializeComponent();
        }
        public static void Open(TPSet tps)
        {
            if(!tps.AllowModify){ return;}
            var tpsf = new ThirdParty_Form();
            tpsf.CCV2Url_textBox.Text = tps.CCV2Url;
            if(!String.IsNullOrEmpty(tps.CPCUrl))
            {
                tpsf.CloudPatchConfig_checkBox.Checked = true;
                tpsf.CPCUrl_textBox.Text = tps.CPCUrl;
            }
            else
            {
                tpsf.CloudPatchConfig_checkBox.Checked = false;
            }
            tpsf.AllowAddServer_checkBox.Checked = tps.AllowAddServer;
            tpsf.MustShownCloudServers_checkBox.Checked = tps.MustShownCloudServers;
            tpsf.AllowPatchMeta_checkBox.Checked = tps.AllowPatchMeta;
            tpsf.AllowPatchUA_checkBox.Checked = tps.AllowPatchUA;
            tpsf.AllowModify_checkBox.Checked = tps.AllowModify;
            tpsf.ShowDialog();
        }

        private void CloudPatchConfig_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            CPCUrl_textBox.Enabled = CloudPatchConfig_checkBox.Checked;
        }

        private void HelpLink_button_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://collei.top/?p=59");
        }

        private void Save_button_Click(object sender, EventArgs e)
        {
            if(CCV2Url_textBox.Text=="")
            {
                MessageBox.Show("云端配置链接未填写","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if(CloudPatchConfig_checkBox.Checked&&CPCUrl_textBox.Text=="")
            {
                MessageBox.Show("修补设置链接未填写", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!AllowModify_checkBox.Checked&& MessageBox.Show("您当前没有勾选允许再次修改，保存后将无法再次编辑！", "确定不允许再次修改?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)==DialogResult.Cancel)
            {
                return;
            }

            TPSet tps = new TPSet();
            tps.CCV2Url = CCV2Url_textBox.Text;
            tps.CPCUrl = CloudPatchConfig_checkBox.Checked ? CPCUrl_textBox.Text : null;
            tps.AllowAddServer = AllowAddServer_checkBox.Checked;
            tps.MustShownCloudServers = MustShownCloudServers_checkBox.Checked;
            tps.AllowPatchMeta = AllowPatchMeta_checkBox.Checked;
            tps.AllowPatchUA = AllowPatchUA_checkBox.Checked;
            tps.AllowModify = AllowModify_checkBox.Checked;

            ThirdPartyMgr.SaveSettings(tps);

            this.Close();
        }
    }
}
