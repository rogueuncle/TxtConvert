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
    public partial class Repeat_Form : Form
    {
        Repeat_Col_Form Rdata = new Repeat_Col_Form();
        public enum Window_Type
        {
            按列去重复,删除列,删除行
        }
        public Repeat_Form(Window_Type window_Type)
        {
            InitializeComponent();
            switch (window_Type)
            {
                case Window_Type.按列去重复:
                    checkBox1.Visible = false;
                    textBox4.Visible = false;
                    this.Height = 185;
                    break;
                case Window_Type.删除列:
                    this.Height = 241;
                    break;
                case Window_Type.删除行:
                    this.Height = 241;
                    textBox3.Enabled = false;
                    numericUpDown1.Enabled = false;
                    break;
                default:
                    break;
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
            OpenFileDialog openFileDialog = new OpenFileDialog{Multiselect = true};

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var _text = "";
                foreach (var filename in openFileDialog.SafeFileNames)
                {
                    _text += filename + ",";
                }
                textBox1.Text = _text;
                Rdata.Input_Files = openFileDialog.FileNames;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                ShowNewFolderButton = true
            };
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = folderBrowserDialog.SelectedPath;
                Rdata.Save_Path = folderBrowserDialog.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("读取文件地址未填写!");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("保存文件地址未填写!");
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("分隔符未填写!");
                return;
            }

            if (checkBox1.Checked && textBox4.Lines.Length == 0)
            {
                MessageBox.Show("关键词未填写!");
                return;
            }
            Rdata.Col_Num = (int)numericUpDown1.Value;
            Rdata.Splite_Txt = textBox3.Text;
            Rdata._Need_Key_Words = checkBox1.Checked;
            Rdata.Key_Words = textBox4.Lines;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Rdata.Splite_Txt = textBox3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox4.ReadOnly = false;
            }
            else
            {
                textBox4.ReadOnly = true;
            }
        }
    }
}
