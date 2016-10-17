using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Threading;
using System.Net;

namespace GroupAdmin
{
    public partial class FormWallPost : Form
    {
        public string directory = AppDomain.CurrentDomain.BaseDirectory;
        public FormWallPost()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            FormCapcha CP = new FormCapcha();
            CP.Show();


            object[] ParArr = { CP };
            Thread t = new Thread(ticks);
            t.Start(ParArr);

        }

        private void listBoxGroups_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormWallPost_Load(object sender, EventArgs e)
        {
            //D:\Projects\TempApp\GroupAdmin\GroupAdmin\files
            loadList("Grouplist.txt");

            VKAPI vk = new VKAPI(Program.accessToken);
            XmlDocument xmldoc = vk.GetUserInfo(Program.userID, "photo_50");
            this.pictureBoxAvatar.Image = Image.FromStream(WebRequest.Create(xmldoc.SelectSingleNode("response/user/photo_50").InnerText.ToString()).GetResponse().GetResponseStream());

        }
        static bool IsLetterContains(string input)
        {
            foreach (char c in input)
                if (Char.IsLetter(c))
                    return true;
            return false;
        }

        private void textBoxAttach_TextChanged(object sender, EventArgs e)
        {

        }
        public void ticks(object Params)
        {
            VKAPI vk = new VKAPI(Program.accessToken);
            for (int i = 0 + Convert.ToInt16(this.textBoxOffset.Text); i < this.listBoxGroups.Items.Count; i++)
            {
                Thread.Sleep(700);
                XmlDocument posting = vk.WallPost(this.listBoxGroups.Items[i].ToString(), this.textBoxText.Text, this.textBoxAttach.Text);
                
                //var mform = ((FormWallPost)((object[])((Params1)[0]))[0]);
                //this.listBoxGroups.SetSelected(i,true);
                
                
                foreach (XmlNode node1 in posting.SelectNodes("/error/error_code"))
                {


                    if (node1.InnerText == "14")
                    {
                        //помечаем группы которые требуют капчу
                        object[] grnum = { i, this};
                        var formwp = ((FormWallPost)((object[])(grnum))[1]);
                        formwp.Invoke(new Action(() =>
                        {
                            formwp.listBoxGroups.SetSelected(i, true);
                        }));


                        object[] Params1 = { Params, posting.SelectSingleNode("/error/captcha_img").InnerText.ToString() };

                        var form = ((FormCapcha)((object[])((Params1)[0]))[0]);
                        form.Tag = "stop";

                        while (form.Tag.ToString() == "stop") //ждем пока пользователь не нажмет кнопку
                        {
                            form.Invoke(new Action(() =>
                            {

                                form.Show();
                                form.label1.Text = ((object[])(Params1))[1].ToString(); //передаем в форму переменную

                            }));

                        }
                        XmlDocument postingCapcha = vk.WallPost(this.listBoxGroups.Items[i].ToString(), this.textBoxText.Text, this.textBoxAttach.Text, posting.SelectSingleNode("/error/captcha_sid").InnerText.ToString(), form.Tag.ToString());
                        //XmlDocument inviteCapcha = vk.InviteUserToGroup(Convert.ToInt32(this.textBoxEventID.Text), Convert.ToInt32(node.InnerText), invite.SelectSingleNode("/error/captcha_sid").InnerText.ToString(), form.Tag.ToString());
                        
                    }
                }
            }

            MessageBox.Show("Ready");


        }
        public void tick(object Params)
        {
            VKAPI vk = new VKAPI(Program.accessToken);
                XmlDocument posting = vk.WallPost(this.textBox1.Text, this.textBoxText.Text, this.textBoxAttach.Text);
                foreach (XmlNode node1 in posting.SelectNodes("/error/error_code"))
                {


                    if (node1.InnerText == "14")
                    {

                        object[] Params1 = { Params, posting.SelectSingleNode("/error/captcha_img").InnerText.ToString() };

                        var form = ((FormCapcha)((object[])((Params1)[0]))[0]);
                        form.Tag = "stop";

                        while (form.Tag.ToString() == "stop") //ждем пока пользователь не нажмет кнопку
                        {
                            form.Invoke(new Action(() =>
                            {

                                form.Show();
                                form.label1.Text = ((object[])(Params1))[1].ToString(); //передаем в форму переменную

                            }));

                        }
                        
                        XmlDocument postingCapcha = vk.WallPost(this.textBox1.Text, this.textBoxText.Text, this.textBoxAttach.Text, posting.SelectSingleNode("/error/captcha_sid").InnerText.ToString(), form.Tag.ToString());
                        //XmlDocument inviteCapcha = vk.InviteUserToGroup(Convert.ToInt32(this.textBoxEventID.Text), Convert.ToInt32(node.InnerText), invite.SelectSingleNode("/error/captcha_sid").InnerText.ToString(), form.Tag.ToString());
                        
                    }
                }
           }
        public void ticks_repost(object Params)
        {
            VKAPI vk = new VKAPI(Program.accessToken);
            for (int i = 0; i < this.listBoxGroups.Items.Count; i++)
            {
                Thread.Sleep(800);

                XmlDocument posting = vk.WallRepost(this.textBoxRepost.Text, this.textBoxText.Text, this.listBoxGroups.Items[i].ToString().Replace('-',' '), "", "", "");
                foreach (XmlNode node1 in posting.SelectNodes("/error/error_code"))
                {


                    if (node1.InnerText == "14")
                    {
                        

                        object[] Params1 = { Params, posting.SelectSingleNode("/error/captcha_img").InnerText.ToString() };

                        var form = ((FormCapcha)((object[])((Params1)[0]))[0]);
                        form.Tag = "stop";

                        while (form.Tag.ToString() == "stop") //ждем пока пользователь не нажмет кнопку
                        {
                            form.Invoke(new Action(() =>
                            {

                                form.Show();
                                form.label1.Text = ((object[])(Params1))[1].ToString(); //передаем в форму переменную

                            }));

                        }
                        //XmlDocument posting = vk.WallRepost(this.textBox2.Text, this.textBoxText.Text, this.listBoxGroups.Items[i].ToString(), "", "", "");

                        XmlDocument postingCapcha = vk.WallRepost(this.textBoxRepost.Text, this.textBoxText.Text, this.listBoxGroups.Items[i].ToString(), "", posting.SelectSingleNode("/error/captcha_sid").InnerText.ToString(), form.Tag.ToString());
                        //XmlDocument inviteCapcha = vk.InviteUserToGroup(Convert.ToInt32(this.textBoxEventID.Text), Convert.ToInt32(node.InnerText), invite.SelectSingleNode("/error/captcha_sid").InnerText.ToString(), form.Tag.ToString());

                    }
                }
            }
        }
        private void FormWallPost_FormClosed(object sender, FormClosedEventArgs e)
        {
          

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IsLetterContains(this.textBox1.Text))
            {
                 VKAPI vk = new VKAPI(Program.accessToken);
                 this.textBox1.Text = '-' + vk.GetGroupID(this.textBox1.Text);
            }
            else if (!(this.textBox1.Text.Contains('-')))
            {
                this.textBox1.Text = '-' + this.textBox1.Text;
            }

            FormCapcha CP = new FormCapcha();
            CP.Show();


            object[] ParArr = { CP };
            Thread t = new Thread(tick);
            t.Start(ParArr);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormCapcha CP = new FormCapcha();
            CP.Show();


            object[] ParArr = { CP };
            Thread t = new Thread(ticks_repost );
            t.Start(ParArr);
        }

        private async void loadList(string name)  //Подгрузка списка групп
        {
            this.listBoxGroups.Items.Clear();
            StreamReader grouplistreader = new StreamReader(directory + @"\files\\" + name ); //grouplist.txt
            string line;
            while ((line = grouplistreader.ReadLine()) != null)
            {
                if (IsLetterContains(line))
                {
                    VKAPI vk = new VKAPI(Program.accessToken);
                    line = vk.GetGroupID(line);
                    await Task.Delay(300);
                }
                if (!(line.Contains('-')))
                {
                    this.listBoxGroups.Items.Add("-" + line);
                }
                else
                {
                    this.listBoxGroups.Items.Add(line);
                }

            }
            grouplistreader.Close();
            this.label1.Text=this.listBoxGroups.Items.Count.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            loadList(this.comboBoxList.Text);
        }

        private void comboBoxList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void savelist(string name)  // листбокс сохраняется в файл
        {
            
            StreamWriter grouplistwriter = new StreamWriter(directory + @"\files\" + name);

            for (int i = 0; i < this.listBoxGroups.Items.Count; i++)
            {
                grouplistwriter.WriteLine(this.listBoxGroups.Items[i].ToString());
            }

            grouplistwriter.Close();
        }

  

        private void buttonSaveList_Click(object sender, EventArgs e)
        {
            savelist(this.comboBoxList.Text);
        }

        private void textBoxText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
