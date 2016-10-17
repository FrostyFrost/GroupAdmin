using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml;

namespace GroupAdmin
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            // webBrowser1.Navigate(String.Format("http://api.vkontakte.ru/oauth/authorize?client_id={0}&scope={1}&display=popup&response_type=token", Program.appId, Program.scope));
            //https://oauth.vk.com/authorize?client_id=5086200&redirect_uri=https://oauth.vk.com/blank.html&scope=407915&display=popup&response_type=token
            webBrowser1.Navigate(String.Format("https://oauth.vk.com/authorize?client_id={0}&redirect_uri=https://oauth.vk.com/blank.html&scope={1}&display=popup&response_type=token", Program.appId, Program.scope));
            //webBrowser1.Navigate(String.Format("https://oauth.vk.com/access_token?client_id={0}&redirect_uri=https://oauth.vk.com/blank.html&scope={1}&display=popup&response_type=token", Program.appId, Program.scope));
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.ToString().IndexOf("access_token") != -1)
            {
                
                Regex myReg = new Regex(@"(?<name>[\w\d\x5f]+)=(?<value>[^\x26\s]+)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                foreach (Match m in myReg.Matches(e.Url.ToString()))
                {
                    if (m.Groups["name"].Value == "access_token")
                    { Program.accessToken = m.Groups["value"].Value; }
                    else if (m.Groups["name"].Value == "user_id")
                    { Program.userID= Convert.ToInt32(m.Groups["value"].Value); }
                }

                VKAPI vk = new VKAPI(Program.accessToken);
                XmlDocument UserInfo = vk.GetUserInfo(Program.userID, "first_name,last_name");
                Program.userFullName = UserInfo.SelectSingleNode("response/user/first_name").InnerText + " " + UserInfo.SelectSingleNode("response/user/last_name").InnerText;

                //MessageBox.Show(String.Format("Ключ доступа: {0}\nUserID: {1}", Program.accessToken, Program.userID));


                Program.applicationContext.MainForm = new FormAdmin();
                Program.applicationContext.MainForm.Show();


            }

        }

        //private System.Windows.Forms.WebBrowser webBrowser1;

    }   
}
