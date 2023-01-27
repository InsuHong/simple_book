using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace book_admin
{
    public partial class Form_config : Form
    {

        string start_db;
        public Form_config()
        {
            InitializeComponent();
        }

        private void Form_config_Load(object sender, EventArgs e)
        {
            IniFile ini = new IniFile();
            ini.Load(Application.StartupPath + "\\setup.ini");
            text_sever.Text = ini["Simple Book Config"]["ftp_server"].ToString();
            text_Path.Text = ini["Simple Book Config"]["ftp_path"].ToString();
            text_Id.Text = ini["Simple Book Config"]["ftp_user"].ToString();
            text_Pass.Text = ini["Simple Book Config"]["ftp_pwd"].ToString();
            start_db = ini["Simple Book Config"]["start_db"].ToString();
            if (start_db == "원격파일") radio1.Checked = true;
            if (start_db == "로컬파일") radio2.Checked = true;
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            String start_db = "";
            IniFile ini = new IniFile();
            ini.Load(Application.StartupPath + "\\setup.ini");
            ini["Simple Book Config"]["ftp_server"] = text_sever.Text;
            ini["Simple Book Config"]["ftp_path"] = text_Path.Text;
            ini["Simple Book Config"]["ftp_user"] = text_Id.Text;
            ini["Simple Book Config"]["ftp_pwd"] = text_Pass.Text;

            if (radio1.Checked == true) start_db = "원격파일";
            if (radio2.Checked == true) start_db = "로컬파일";
            ini["Simple Book Config"]["start_db"] = start_db;
            ini.Save(Application.StartupPath + "\\setup.ini");
            this.Close();
        }
    }
}
