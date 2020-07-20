using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 文本处理器
{
    public partial class Form1 : Form
    {
        readonly Option_Form repeat_Form = new Option_Form();
        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            ConvertText._Clean_Col_Val("1-2-132",2,"-",new string[1]{ "1"});
        }

        private void Repeat_Btn_Click(object sender, EventArgs e)  //去重复
        {
            repeat_Form.init(Option_Form.Window_Type.去重复);
            
            if (repeat_Form.ShowDialog() == DialogResult.OK)
            {
                Repeat_Col_Form repeat_Col_Form = repeat_Form.Get_Data();

                if (repeat_Col_Form.Col_Num == -1)  //如果列数是-1，按行去重复
                {
                    ConvertText.Repeat_Clean_Rows(repeat_Col_Form.Input_Files, repeat_Col_Form.Save_Path);
                }
                else
                {
                    ConvertText.Repeat_Clean_Col(repeat_Col_Form.Input_Files, repeat_Col_Form.Save_Path,
                    repeat_Col_Form.Col_Num, repeat_Col_Form.Splite_Txt);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            repeat_Form.init(Option_Form.Window_Type.删除内容);
            if (repeat_Form.ShowDialog() == DialogResult.OK)
            {
                Repeat_Col_Form repeat_Col_Form_Data = repeat_Form.Get_Data();
                if (repeat_Col_Form_Data._Need_Key_Words)
                {
                    ConvertText.Screen_Clean_Col(repeat_Col_Form_Data.Input_Files, repeat_Col_Form_Data.Save_Path,
                    repeat_Col_Form_Data.Col_Num, repeat_Col_Form_Data.Splite_Txt, repeat_Col_Form_Data.Key_Words);
                }
                else
                {
                    ConvertText.Screen_Clean_Col(repeat_Col_Form_Data.Input_Files, repeat_Col_Form_Data.Save_Path,
                    repeat_Col_Form_Data.Col_Num, repeat_Col_Form_Data.Splite_Txt);
                }

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
