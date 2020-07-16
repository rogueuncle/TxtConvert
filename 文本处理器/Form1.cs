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
                    Convert.Repeat_Clean_Rows(openFileDialog1.FileNames,folderBrowserDialog1.SelectedPath);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Repeat_Form repeat_Form = new Repeat_Form(Repeat_Form.Window_Type.按列去重复);
            if (repeat_Form.ShowDialog() == DialogResult.OK)
            {
                Repeat_Col_Form repeat_Col_Form = repeat_Form.Get_Data();
                repeat_Form.Dispose();
                Convert.Repeat_Clean_Col(repeat_Col_Form.Input_Files, repeat_Col_Form.Save_Path,
                    repeat_Col_Form.Col_Num, repeat_Col_Form.Splite_Txt);
            }
            else
            {
                repeat_Form.Dispose();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Repeat_Form repeat_Form = new Repeat_Form(Repeat_Form.Window_Type.删除列);
            if (repeat_Form.ShowDialog() == DialogResult.OK)
            {
                Repeat_Col_Form repeat_Col_Form = repeat_Form.Get_Data();
                repeat_Form.Dispose();
                Convert.Repeat_Clean_Col(repeat_Col_Form.Input_Files, repeat_Col_Form.Save_Path,
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
        /// <summary>
        /// 导入的文件列表
        /// </summary>
        public string[] Input_Files;
        /// <summary>
        /// 保持的文件夹地址
        /// </summary>
        public string Save_Path;
        /// <summary>
        /// 文本分隔符
        /// </summary>
        public string Splite_Txt;
        /// <summary>
        /// 被选择的列数
        /// </summary>
        public int Col_Num;
        /// <summary>
        /// 是否过滤关键词
        /// </summary>
        public bool _Need_Key_Words;
        /// <summary>
        /// 关键词列表
        /// </summary>
        public string[] Key_Words;
    }
}
