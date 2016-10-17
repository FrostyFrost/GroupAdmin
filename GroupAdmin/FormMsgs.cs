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
using System.Collections ;


namespace GroupAdmin
{
    public partial class FormMsgs : Form
    {
        public FormMsgs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VKAPI vk = new VKAPI(Program.accessToken);
            vk.SetOffline();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.dataGridView1.Rows.Clear();
            VKAPI vk = new VKAPI(Program.accessToken);
            DateTime date = new DateTime(1970, 1,1,3,1,1);

            XmlDocument MessagesOut = vk.GetMessages("0");
            foreach (XmlNode node in MessagesOut.SelectNodes("response/message"))
            {
                XmlDocument UserInfo = vk.GetUserInfo(Convert.ToInt32(node.SelectSingleNode("uid").InnerText), "first_name,last_name");
                System.Threading.Thread.Sleep(400);
                this.dataGridView1.Rows.Add(date.AddSeconds(Convert.ToInt32(node.SelectSingleNode("date").InnerText)), UserInfo.SelectSingleNode("response/user/first_name").InnerText + " " + UserInfo.SelectSingleNode("response/user/last_name").InnerText, node.SelectSingleNode("body").InnerText.ToString(),  node.SelectSingleNode("read_state").InnerText.ToString()== "0" ? "не прочитано":"прочитано");
            }
            XmlDocument MessagesIn = vk.GetMessages("1");
            foreach (XmlNode node in MessagesIn.SelectNodes("response/message"))
            {
                XmlDocument UserInfo = vk.GetUserInfo(Convert.ToInt32(node.SelectSingleNode("uid").InnerText), "first_name,last_name");
                System.Threading.Thread.Sleep(400);
                this.dataGridView1.Rows.Add(date.AddSeconds(Convert.ToInt32(node.SelectSingleNode("date").InnerText)), Program.userFullName + " to " + UserInfo.SelectSingleNode("response/user/first_name").InnerText + " " + UserInfo.SelectSingleNode("response/user/last_name").InnerText, node.SelectSingleNode("body").InnerText.ToString(), node.SelectSingleNode("read_state").InnerText.ToString() == "0" ? "не прочитано" : "прочитано");
            }


            DataGridViewColumn sortColumn = dataGridView1.Columns[0];
            ListSortDirection direction = ListSortDirection.Descending;
            this.dataGridView1.Sort(sortColumn, direction);
            this.dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Default ;

        }

        private void buttonSendMsg_Click(object sender, EventArgs e)
        {
            VKAPI vk = new VKAPI(Program.accessToken);
            vk.SendMessage(this.textBoxSendUserID.Text, this.textBoxSendMsg.Text, this.textBoxSendMsgTitle.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VKAPI vk = new VKAPI(Program.accessToken);
            XmlDocument FriendList = vk.GetAllFriends();
            
            ArrayList  FrLst = new ArrayList() ;
            //list[] Mylist = new list[150];
            //Listic Mylist = new Listic();
            int i = 0;
            foreach (XmlNode node in FriendList.SelectNodes("response/uid"))
            {
                i++;
                XmlDocument UserInfo = vk.GetUserInfo(Convert.ToInt32(node.InnerText), "first_name,last_name");
                FrLst.Add( new Listic(node.InnerText , UserInfo.SelectSingleNode("response/user/first_name").InnerText + " " + UserInfo.SelectSingleNode("response/user/last_name").InnerText));
               // Mylist.fio = UserInfo.SelectSingleNode("response/user/first_name").InnerText + " " + UserInfo.SelectSingleNode("response/user/last_name").InnerText;
                //FrLst.Add(new Person() { Uid = node.InnerText, FIO = UserInfo.SelectSingleNode("response/user/first_name").InnerText + " " + UserInfo.SelectSingleNode("response/user/last_name").InnerText });
                System.Threading.Thread.Sleep(400);
                //FrLst.Add(Mylist);
            }
            this.comboBox1.DataSource = FrLst;
            System.Threading.Thread.Sleep(400);
            //for (i = 0; i < 5; i++ )
            this.comboBox1.DisplayMember = "uid"; 
            this.comboBox1.ValueMember = "fio";
            
        }
        class Listic
        {
            public string Uid;
            public string Fio;

            public Listic(string uid, string fio)
            {
                Uid = uid;
                Fio = fio;
            }
        }
    }
}
