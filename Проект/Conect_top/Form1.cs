using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dll;

namespace Conect_top
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            label1.Text = Dll.Conect.top_1.ToString();
            label2.Text = Dll.Conect.top_2.ToString();
        }

        private void Connect_Click(object sender, EventArgs e)
        {          
            if (comboBox1.Text == "↔")
            {
                Dll.Conect.num_1 = int.Parse(textBox1.Text);
                Dll.Conect.num_2 = int.Parse(textBox2.Text);
            }
            else
            Dll.Conect.num_3 = int.Parse(textBox3.Text);
            
            this.Close();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            switch(comboBox1.Text)
            {
                case "→":
                    Visiable(false,false,true);
                    Dll.Conect.direction = 'R';
                    break;
                case "←":
                    Visiable(false, false, true);
                    Dll.Conect.direction = 'L';
                    break;
                case "↔":
                    Visiable(true, true, false);
                    Dll.Conect.direction = 'D';
                    break;
            }
        }
        void Visiable(bool t1,bool t2,bool t3)
        {
            textBox1.Visible = t1;
            textBox2.Visible = t2;
            textBox3.Visible = t3;
        }
    }
}
