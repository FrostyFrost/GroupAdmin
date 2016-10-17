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


namespace GroupAdmin
{
    public partial class Form_Parse : Form
    {
        public Form_Parse()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string  xmlText  ;

            xmlText = this.textBox1.Text;
           
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(xmlText);
            xmldoc.SelectSingleNode("table/tbody");

        }
    }
}
