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
    public partial class Option_Form : Form
    {
        Repeat_Col_Form Rdata = new Repeat_Col_Form();
        public enum Window_Type
        {
            去重复,删除内容
        }
        public Option_Form()
        {
            InitializeComponent();
            
        }

        public bool init(Window_Type window_Type)
        {
            split_Text_Lab.Visible = false;
            col_Num_Lab.Visible = false;
            len_Num_Lab.Visible = false;

            split_Text_TB.Visible = false;
            keyWords_TB.Visible = false;

            keyWord_Chebox.Visible = false;


            col_Num_Numer.Visible = false;
            len_Num_Numer.Visible = false;


            switch (window_Type)
            {
                case Window_Type.去重复:
                    split_Text_Lab.Visible = true;
                    col_Num_Lab.Visible = true;
                    split_Text_TB.Visible = true;
                    
                    col_Num_Numer.Visible = true;
                    this.Height = 188;
                    return true;
                    
                case Window_Type.删除内容:
                    split_Text_Lab.Visible = true;
                    col_Num_Lab.Visible = true;
                    split_Text_TB.Visible = true;
                    keyWord_Chebox.Visible = true;
                    col_Num_Numer.Visible = true;
                    keyWord_Chebox.Visible = true;
                    keyWords_TB.Visible = true;
                    
                    len_Num_Lab.Visible = true;
                    len_Num_Numer.Visible = true;

                    if (col_Num_Numer.Value == -1)
                    {
                        len_Num_Numer.Enabled = false;
                    }
                    this.Height = 241;
                    return true;
                //case Window_Type.删除行:
                //    textBox4.Visible = true;
                //    checkBox1.Visible = true;
                //    textBox4.Location = new Point(71, 87);
                //    checkBox1.Location = new Point(11, 105);
                //    checkBox1.Checked = true;
                //    this.Height = 184;

                //    break;
                default:
                    return false;
            }
        }

        /// <summary>
        /// 获取界面设置的内容
        /// </summary>
        /// <returns></returns>
        public Repeat_Col_Form Get_Data()
        {
            return Rdata;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var _text = "";
                foreach (var filename in openFileDialog1.SafeFileNames)
                {
                    _text += filename + ",";
                }
                input_Files_TB.Text = _text;
                Rdata.Input_Files = openFileDialog1.FileNames;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                save_File_TB.Text = folderBrowserDialog1.SelectedPath;
                Rdata.Save_Path = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (input_Files_TB.Text == "")
            {
                MessageBox.Show("读取文件地址未填写!");
                return;
            }
            if (save_File_TB.Text == "")
            {
                MessageBox.Show("保存文件地址未填写!");
                return;
            }
            if (split_Text_TB.Text == "")
            {
                MessageBox.Show("分隔符未填写!");
                return;
            }

            if (keyWord_Chebox.Checked && keyWords_TB.Lines.Length == 0)
            {
                MessageBox.Show("关键词未填写!");
                return;
            }
            Rdata.Col_Num = (int)col_Num_Numer.Value;
            Rdata.Splite_Txt = split_Text_TB.Text;
            Rdata._Need_Key_Words = keyWord_Chebox.Checked;
            Rdata.Key_Words = keyWords_TB.Lines;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Rdata.Splite_Txt = split_Text_TB.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (keyWord_Chebox.Checked)
            {
                keyWords_TB.ReadOnly = false;
            }
            else
            {
                keyWords_TB.ReadOnly = true;
            }
        }

        private void col_Num_Numer_ValueChanged(object sender, EventArgs e)
        {
            if (col_Num_Numer.Value == -1)
            {
                len_Num_Numer.Enabled = false;
            }
            else
            {
                len_Num_Numer.Enabled = true;
            }
        }
    }
}
