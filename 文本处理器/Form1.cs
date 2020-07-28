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
            sss(1, "0-1-", "-");
            sss(2, "0-1", "-");
            sss(3, "0-1-", "-");
            sss(4, "0-1", "-");
        }

        public void sss(int Col_Num,string text,string Split_Text)
        {
            int addr = 0 - Split_Text.Length;
            for (int i = 0; i < Col_Num; i++)
            {
                addr = text.IndexOf(Split_Text, addr+Split_Text.Length);
                if (addr == -1) break;
            }
            Console.WriteLine(addr);
        }

        #region 去重复
        private void Repeat_Btn_Click(object sender, EventArgs e)  //按行去重复
        {
            repeat_Form.init(Option_Form.Window_Type.按行去重复);

            if (repeat_Form.ShowDialog() == DialogResult.OK)
            {
                Repeat_Col_Form repeat_Col_Form = repeat_Form.Get_Data();
                ConvertText.Repeat_Clean_Rows(repeat_Col_Form.Input_Files, repeat_Col_Form.Save_Path);
            }
        }

        private void button3_Click(object sender, EventArgs e)  //按列去重复
        {
            repeat_Form.init(Option_Form.Window_Type.按列去重复);

            if (repeat_Form.ShowDialog() == DialogResult.OK)
            {
                Repeat_Col_Form repeat_Col_Form = repeat_Form.Get_Data();
                ConvertText.Repeat_Clean_Col(repeat_Col_Form.Input_Files, repeat_Col_Form.Save_Path,
                repeat_Col_Form.Col_Num, repeat_Col_Form.Splite_Txt);
            }
        }
        #endregion


        private void button8_Click(object sender, EventArgs e)
        {
            repeat_Form.init(Option_Form.Window_Type.删除行);
            if (repeat_Form.ShowDialog() == DialogResult.OK)
            {
                Repeat_Col_Form repeat_Col_Form_Data = repeat_Form.Get_Data();
                ConvertText.Screen_Clean_Row(repeat_Col_Form_Data.Input_Files, repeat_Col_Form_Data.Save_Path, repeat_Col_Form_Data.Key_Words);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            repeat_Form.init(Option_Form.Window_Type.删除列);
            if (repeat_Form.ShowDialog() == DialogResult.OK)
            {
                Repeat_Col_Form repeat_Col_Form_Data = repeat_Form.Get_Data();
                ConvertText.Screen_Clean_Col(repeat_Col_Form_Data.Input_Files, repeat_Col_Form_Data.Save_Path,
                repeat_Col_Form_Data.Col_Num, repeat_Col_Form_Data.Splite_Txt);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            repeat_Form.init(Option_Form.Window_Type.删除包含关键词的列);
            if (repeat_Form.ShowDialog() == DialogResult.OK)
            {
                Repeat_Col_Form repeat_Col_Form_Data = repeat_Form.Get_Data();
                ConvertText.Screen_Clean_Col(repeat_Col_Form_Data.Input_Files, repeat_Col_Form_Data.Save_Path,
                repeat_Col_Form_Data.Col_Num, repeat_Col_Form_Data.Splite_Txt, repeat_Col_Form_Data.Key_Words);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            repeat_Form.init(Option_Form.Window_Type.删除包含关键词的列);
            if (repeat_Form.ShowDialog() == DialogResult.OK)
            {
                Repeat_Col_Form repeat_Col_Form_Data = repeat_Form.Get_Data();
                ConvertText.Screen_Save_Col(repeat_Col_Form_Data.Input_Files, repeat_Col_Form_Data.Save_Path,
                repeat_Col_Form_Data.Col_Num, repeat_Col_Form_Data.Splite_Txt, repeat_Col_Form_Data.Key_Words);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            repeat_Form.init(Option_Form.Window_Type.删除行);
            if (repeat_Form.ShowDialog() == DialogResult.OK)
            {
                Repeat_Col_Form repeat_Col_Form_Data = repeat_Form.Get_Data();
                ConvertText.Screen_Save_Row(repeat_Col_Form_Data.Input_Files, repeat_Col_Form_Data.Save_Path, repeat_Col_Form_Data.Key_Words);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            repeat_Form.init(Option_Form.Window_Type.指定长度行);
            if (repeat_Form.ShowDialog() == DialogResult.OK)
            {
                Repeat_Col_Form repeat_Col_Form_Data = repeat_Form.Get_Data();
                ConvertText.Screen_Save_Row_Len(repeat_Col_Form_Data.Input_Files, repeat_Col_Form_Data.Save_Path, repeat_Col_Form_Data.Text_Len);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            repeat_Form.init(Option_Form.Window_Type.指定列长度);
            if (repeat_Form.ShowDialog() == DialogResult.OK)
            {
                Repeat_Col_Form repeat_Col_Form_Data = repeat_Form.Get_Data();
                ConvertText.Screen_Save_Col_Len(repeat_Col_Form_Data.Input_Files, 
                    repeat_Col_Form_Data.Save_Path, repeat_Col_Form_Data.Splite_Txt,repeat_Col_Form_Data.Col_Num,
                    repeat_Col_Form_Data.Text_Len);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            repeat_Form.init(Option_Form.Window_Type.提取行);
            if (repeat_Form.ShowDialog() == DialogResult.OK)
            {
                Repeat_Col_Form repeat_Col_Form_Data = repeat_Form.Get_Data();
                ConvertText.Screen_Save_Range_Row(repeat_Col_Form_Data.Input_Files,
                    repeat_Col_Form_Data.Save_Path, repeat_Col_Form_Data.Col_Num,
                    repeat_Col_Form_Data.Text_Len);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            repeat_Form.init(Option_Form.Window_Type.按列去重复);
            if (repeat_Form.ShowDialog() == DialogResult.OK)
            {
                Repeat_Col_Form repeat_Col_Form_Data = repeat_Form.Get_Data();
                ConvertText.Screen_Save_Col_Split_Len(repeat_Col_Form_Data.Input_Files,
                    repeat_Col_Form_Data.Save_Path, repeat_Col_Form_Data.Splite_Txt, repeat_Col_Form_Data.Col_Num);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Set_Form set_form = new Set_Form();
            set_form.init(Set_Form.Window_Type.集合_行);
            if (set_form.ShowDialog() == DialogResult.OK)
            {

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
        /// <summary>
        /// 过滤长度
        /// </summary>
        public int Text_Len;
    }
}
