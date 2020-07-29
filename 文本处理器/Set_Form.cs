using System;
using System.CodeDom;
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
    
    public partial class Set_Form : Form
    {
        public enum Window_Type
        {
            集合_行, 集合_列
        }
        Window_Type window_Type;
        public Set_Form()
        {
            InitializeComponent();
        }

        public bool init(Window_Type typ)
        {
            window_Type = typ;
            switch (typ)
            {
                case Window_Type.集合_行:
                    Height = 150;
                    break;
                case Window_Type.集合_列:
                    Height = 182;
                    break;
                default:
                    break;
            }
            return true;
        }

        public HashSet_Form Get_Data()
        {
            HashSet_Form Data = new HashSet_Form()
            {
                file_A = input_File_TB_A.Text,
                file_B = input_File_TB_B.Text,
                save_File = save_File_TB.Text,
                split = split_Text_TB.Text,
                col_num = (int)col_Num_Numer.Value,
            };
            return Data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                input_File_TB_A.Text = openFileDialog1.FileName;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                input_File_TB_B.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                save_File_TB.Text = saveFileDialog1.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (input_File_TB_A.Text == "")
            {
                MessageBox.Show("文件A地址必须填写!");
                return;
            }
            if (input_File_TB_B.Text == "")
            {
                MessageBox.Show("文件B地址必须填写!");
                return;
            }

            if (save_File_TB.Text == "")
            {
                MessageBox.Show("保存文件地址必须填写!");
                return;
            }

            if (window_Type == Window_Type.集合_列)
            {
                if(split_Text_TB.Text == "")
                {
                    MessageBox.Show("分隔符必须填写!");
                    return;
                }
                if (col_Num_Numer.Value < 0)
                {
                    MessageBox.Show("列数不能小于0!");
                    return;
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
