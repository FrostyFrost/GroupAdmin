using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace GroupAdmin
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            
            //FormLogin frmLogin1 = new FormLogin();
            
            ////FormMain.ActiveForm.Close();
            //frmLogin1.Show();

            //
            Program.applicationContext.MainForm = new FormLogin();
            Program.applicationContext.MainForm.Show();
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.applicationContext.MainForm = new Form_Parse ();
            Program.applicationContext.MainForm.Show();
 
        }
        
 
    }
}
