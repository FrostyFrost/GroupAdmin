using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace GroupAdmin
{
    public partial class FormCapcha : Form
    {
        //bool flag = false;
        int cntr = 0;
        public string directory = AppDomain.CurrentDomain.BaseDirectory;
        public FormCapcha()
        {
            //CallBackMy.callbackEventHandler = new CallBackMy.callbackEvent(this.Reload);
            InitializeComponent();
        }
        //void Reload(string param)
        //{

            
        //    do { } while (flag == false);
        //}

        private void button1_Click(object sender, EventArgs e)
        {
           
            this.Tag = (string)(this.textBox1.Text);
            cntr++;
            this.label2.Text = cntr.ToString();

            Bitmap bm = new Bitmap(this.pictureBox1.Image);
            bm.Save(directory + @"\files\capcha\" + this.textBox1.Text + ".jpg");
            // todo сохранение капчи
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
          //  this.webBrowser1.Navigate(this.label1.Text);
            this.pictureBox1.Image = Image.FromStream(WebRequest.Create(this.label1.Text).GetResponse().GetResponseStream());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
           
            this.pictureBox1.Image = Image.FromStream(WebRequest.Create(this.label1.Text).GetResponse().GetResponseStream());
           //this.pictureBox1.ImageLocation = this.label1.Text;
            //this.webBrowser1.Navigate(this.label1.Text);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


    }
}
