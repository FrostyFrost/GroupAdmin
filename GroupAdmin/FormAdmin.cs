using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;
using System.Xml;
using System.IO;
using System.Net;


namespace GroupAdmin
{
    public partial class FormAdmin : Form
    {

        public int cntr_users = 0;
        public string directory = AppDomain.CurrentDomain.BaseDirectory;
        public FormAdmin()
        {
            InitializeComponent();
            StreamReader strmrdrcounter = new StreamReader(directory + @"\files\usercntr.txt");
            this.textBox_offset.Text = strmrdrcounter.ReadLine();
            strmrdrcounter.Close();

            StreamReader strmrdrgroup = new StreamReader(directory + @"\files\groupnmbr.txt");
            this.textBoxEventID.Text = strmrdrgroup.ReadLine();
            strmrdrgroup.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBoxGroupID.Text = "madsquirrels";
        }




        private void buttonInviteFriends_Click(object sender, EventArgs e)
        {
            //VKAPI vk = new VKAPI(Program.accessToken);
            //vk.InviteUserToGroup(Convert.ToInt32(this.textBoxEventID.Text), 201621284);
            
            //VKAPI vk = new VKAPI(Program.accessToken);
            //vk.start_invite(Convert.ToInt32(this.textBoxEventID.Text));


            cntr_users = Convert.ToInt32 (this.textBox_offset.Text);
            FormCapcha  CP = new FormCapcha();
            CP.Show();
            string who = "gr";


            object[] ParArr = { CP, who };
            Thread t = new Thread(ticks);
            //t.IsBackground = true; C:\Users\А\Desktop\TempApp\GroupAdmin\GroupAdmin\bin\Debug\usercntr.txt
            t.Start(ParArr);
            

            //strmrdr.Dispose();


           
            
        }
        public void ticks(object Params)
        {
            VKAPI vk = new VKAPI(Program.accessToken);
            string w;

            XmlDocument friendList;
            if ((((object[])(Params))[1].ToString() == "gr") | ((object[])(Params))[1].ToString() == "gr_mes")
             {
                 friendList = vk.GetGroupMembers(this.textBoxGroupID.Text, this.textBox_offset.Text);
                  w = "response/users/uid";
             }
            else if (((object[])(Params))[1].ToString() == "ls_mes")
             {
                //TextReader txt = @"D:\Projects\TempApp\GroupAdmin\GroupAdmin\files\friendsAdd.txt";
                 friendList = new XmlDocument() ;
                 friendList.Load(directory + @"\files\friendsAdd.xml");
                w = "response/uid";
             }
            else if (((object[])(Params))[1].ToString() == "add_fr")
            {
                //TextReader txt = @"D:\Projects\TempApp\GroupAdmin\GroupAdmin\files\friendsAdd.txt";
                friendList = new XmlDocument();
                friendList = vk.GetRequests();
                w = "response/uid";
            }
            else    
             {
                // я чет запутался что здесь должно быть, поэтому закоментил
                 friendList = vk.GetAllFriends();
                 w = "response/items/user_id";
             }




            foreach (XmlNode node  in friendList.SelectNodes(w)) // "/users"
            {
                Thread.Sleep(300);

                cntr_users += 1;

                StreamWriter strmwrtr = new StreamWriter(directory + @"\files\usercntr.txt");
                strmwrtr.Write(cntr_users.ToString());
                strmwrtr.Close();
                XmlDocument invite;
                if (((object[])(Params))[1].ToString() == "gr_mes" | ((object[])(Params))[1].ToString() == "ls_mes")
                {
                     invite = vk.SendMessage(node.InnerText, this.textBoxGroupMess.Text, "");
                }
                else if (((object[])(Params))[1].ToString() == "add_fr")
                {
                    invite = vk.AddFriend(node.InnerText);
                    invite = vk.SendMessage(node.InnerText, @"Привет. Ты добавился просто для количества? 
                                                                Могу помочь с накруткой друзей, реальных людей. Дешево и качестванно) 
                                                                Либо могу присылать тебе время от времени людей чтобы ты сам  добавлял их в друзья. Бесплатно)", "");
                    
                }
                else
                {
                     invite = vk.InviteUserToGroup(Convert.ToInt32(this.textBoxEventID.Text), Convert.ToInt32(node.InnerText));
                }
                StreamWriter strmwrtrlog = new StreamWriter(directory + @"\files\log.txt", true);
                if (invite.SelectNodes("/error/error_code").Count != 0)
                     {
                        strmwrtrlog.WriteLine(cntr_users.ToString() + " " + node.InnerText + " "+ invite.SelectSingleNode("/error/error_code").InnerText.ToString()); //+ node1.InnerText
                     }
                else 
                     {
                        strmwrtrlog.WriteLine(cntr_users.ToString() + " " + node.InnerText + " OK"); //+ node1.InnerText
                     }
                strmwrtrlog.Close();
                    
                    foreach (XmlNode node1  in invite.SelectNodes("/error/error_code") ) 
                    {


                        if (node1.InnerText == "14")
                        {

                        object[] Params1 = { Params, invite.SelectSingleNode("/error/captcha_img").InnerText.ToString() };

                        var form = ((FormCapcha)((object[])((Params1)[0]))[0]);
                        form.Tag = "stop";
                        //Если возникает данная ошибка, то в сообщении об ошибке передаются также следующие параметры:
                        //captcha_sid - идентификатор captcha
                        //captcha_img - ссылка на изображение, которое нужно показать пользователю, чтобы он ввел текст с этого изображения.

                        //В этом случае следует запросить пользователя ввести текст с изображения captcha_img и повторить запрос, добавив в него параметры:
                        //captcha_sid - полученный идентификатор
                        //captcha_key - текст, который ввел пользователь

                        while (form.Tag.ToString() == "stop") //ждем пока пользователь не нажмет кнопку
                        {
                            form.Invoke(new Action(() =>
                            {

                                form.Show();
                                form.label1.Text = ((object[])(Params1))[1].ToString(); //передаем в форму переменную
                                
                            }));

                        }
                        //MessageBox.Show(form.Tag.ToString()); // получаем введенное значение
                        //invite.SelectSingleNode("/error/captcha_sid").InnerText.ToString();
                        if (((object[])(Params))[1].ToString() == "gr_mes" | ((object[])(Params))[1].ToString() == "ls_mes")
                        {
                            XmlDocument inviteCapcha = vk.SendMessage(node.InnerText, this.textBoxGroupMess.Text, "", invite.SelectSingleNode("/error/captcha_sid").InnerText.ToString(), form.Tag.ToString());
                        }
                        else
                        {
                            XmlDocument inviteCapcha = vk.InviteUserToGroup(Convert.ToInt32(this.textBoxEventID.Text), Convert.ToInt32(node.InnerText), invite.SelectSingleNode("/error/captcha_sid").InnerText.ToString(), form.Tag.ToString());
                        }
                        }
                  }
                    
               }

               MessageBox.Show("Ready"); // это то, что выполняется в цикле 

                
            }
  

        private void textBoxEventID_TextChanged(object sender, EventArgs e)
        {

            /// Оставляем только номер встречи  https://vk.com/club80840586
            if (this.textBoxEventID.Text.Contains("club"))
            {
                int index = this.textBoxEventID.Text.IndexOf("club");
                this.textBoxEventID.Text = this.textBoxEventID.Text.Substring(index + 4);
            }
            if (this.textBoxEventID.Text.Contains("event"))
            {
                int index = this.textBoxEventID.Text.IndexOf("event");
                this.textBoxEventID.Text = this.textBoxEventID.Text.Substring(index + 5);
            }

            try
            {
                StreamWriter streamwrtrgroup = new StreamWriter(directory + @"\files\groupnmbr.txt");
                streamwrtrgroup.Write(this.textBoxEventID.Text);
                streamwrtrgroup.Close();
            }
            catch { }

        }

        private void ButtonInviteFormGroup_Click(object sender, EventArgs e)
        {

        }

        private void textBoxEventID_DoubleClick(object sender, EventArgs e)
        {
            StreamWriter streamwrtrgroup = new StreamWriter(directory + @"\files\groupnmbr.txt");
            streamwrtrgroup.Write(this.textBoxEventID.Text);
            streamwrtrgroup.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMsgs  MSGS = new FormMsgs ();
            MSGS.Show();
        }

        private void textBox_offset_Enter(object sender, EventArgs e)
        {
            StreamReader strmrdrcounter = new StreamReader(directory + @"\files\usercntr.txt");
            this.textBox_offset.Text = strmrdrcounter.ReadLine();
            strmrdrcounter.Close();
        }

        private void textBox_offset_Click(object sender, EventArgs e)
        {
            StreamReader strmrdrcounter = new StreamReader(directory + @"\files\usercntr.txt");
            this.textBox_offset.Text = strmrdrcounter.ReadLine();
            strmrdrcounter.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FormWallPost WLLPST = new FormWallPost();
            WLLPST.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cntr_users = Convert.ToInt32(this.textBox_offset.Text);
            FormCapcha CP = new FormCapcha();
            CP.Show();
            string who = "usr";


            object[] ParArr = { CP, who };
            Thread t = new Thread(ticks);

            t.Start(ParArr);
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            cntr_users = Convert.ToInt32(this.textBox_offset.Text);
            FormCapcha CP = new FormCapcha();
            CP.Show();
            string who = "gr_mes";


            object[] ParArr = { CP, who };
            Thread t = new Thread(ticks);
            //t.IsBackground = true; C:\Users\А\Desktop\TempApp\GroupAdmin\GroupAdmin\bin\Debug\usercntr.txt
            t.Start(ParArr);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cntr_users = Convert.ToInt32(this.textBox_offset.Text);
            FormCapcha CP = new FormCapcha();
            CP.Show();
            string who = "ls_mes";


            object[] ParArr = { CP, who };
            Thread t = new Thread(ticks);
            t.Start(ParArr);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormCapcha CP = new FormCapcha();
            CP.Show();
            string who = "add_fr";


            object[] ParArr = { CP, who };
            Thread t = new Thread(ticks);
            t.Start(ParArr);
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            VKAPI vk = new VKAPI(Program.accessToken);
            XmlDocument xmldoc = vk.GetUserInfo (Program.userID , "photo_50");
            this.pictureBoxAvatar.Image = Image.FromStream(WebRequest.Create(xmldoc.SelectSingleNode("response/user/photo_50").InnerText.ToString()).GetResponse().GetResponseStream());

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        }
       
    }

