using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 文本处理器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    Convert.Clean_Repeat_Rows(openFileDialog1.FileNames,folderBrowserDialog1.SelectedPath);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Repeat_Form repeat_Form = new Repeat_Form();
            if (repeat_Form.ShowDialog() == DialogResult.OK)
            {
                Repeat_Col_Form repeat_Col_Form = repeat_Form.Get_Data();
                repeat_Form.Dispose();
                Convert.Clean_Repeat_Col(repeat_Col_Form.Input_Files, repeat_Col_Form.Save_Path,
                    repeat_Col_Form.Col_Num, repeat_Col_Form.Splite_Txt);
            }
            else
            {
                repeat_Form.Dispose();
            }
            
        }
    }


    public struct Repeat_Col_Form
    {
        public string[] Input_Files;
        public string Save_Path;
        public string Splite_Txt;
        public int Col_Num;
    }
}
