using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 文本处理器
{
    class ConvertText
    {
        #region 公共函数
        /// <summary>
        /// 删除指定列，返回剩余文本
        /// </summary>
        /// <param name="Text">要被删除的文本</param>
        /// <param name="Col">指定列</param>
        /// <param name="Split_Text">用来分割的文本</param>
        /// <returns></returns>
        public static string _Clean_Col(string Text, int Col, string Split_Text)
        {

            int split_len = Split_Text.Length;
            int _addr_s = Text.IndexOf(Split_Text) + split_len;
            if (Col == 0)
            {
                return Text.Substring(_addr_s);
            }
            if (Col == 1)
            {
                return Text.Substring(0, _addr_s) + Text.Substring(Text.IndexOf(Split_Text, _addr_s) + split_len);
            }

            int index = 0;
            
            do
            {
                _addr_s = Text.IndexOf(Split_Text, _addr_s);
                if (_addr_s == -1)
                {
                    return null;
                }
                _addr_s += split_len;
                index++;
            } while (index < Col);

            
            int _addr_e = Text.IndexOf(Split_Text, _addr_s);
            if (_addr_e == -1) return Text.Substring(0, _addr_s);

            return Text.Substring(0, _addr_s) + Text.Substring(_addr_e) + "\r\n";
        }

        /// <summary>
        /// 删除包含指定关键词的列
        /// </summary>
        /// <param name="Text">要被删除的文本</param>
        /// <param name="Col">指定列</param>
        /// <param name="Splite_Text">用来分割的文本</param>
        /// <param name="Find_Text">用来寻找的关键字数组</param>
        /// <returns></returns>
        public static string _Clean_Col_Val(string Text, int Col, string Splite_Text, string[] KeyWord)
        {
            int index = -1;
            int _addr_s = -1;


            string coltext;
            while (index < Col - 1)
            {
                _addr_s = Text.IndexOf(Splite_Text, _addr_s + 1);  //寻找分割文本的位置
                if (_addr_s == -1)  //列数不足的略去
                {
                    return null;
                }
                index++;
            }
            int _addr_e = Text.IndexOf(Splite_Text, _addr_s + 1);  //寻找指定列的结尾位置

            if (_addr_e == -1)
            {
                //_addr_s = Text.LastIndexOf(Splite_Text, _addr_e);
                coltext = Text.Substring(_addr_s + Splite_Text.Length);  //从开始位置取文本到结尾
            }
            else
            {
                coltext = Text.Substring(_addr_s + Splite_Text.Length, _addr_e - _addr_s - Splite_Text.Length);
            }

            if (KeyWord.Length == 1)
            {
                if (coltext.IndexOf(KeyWord[0]) != -1)
                {
                    if (_addr_e == -1)
                    {
                        return Text.Substring(0, _addr_s) + "\r\n";
                    }
                    return Text.Substring(0, _addr_s) + Text.Substring(_addr_e) + "\r\n";
                }
                else
                {
                    return Text + "\r\n";
                }
            }
            else
            {
                foreach (var txt in KeyWord)
                {
                    if (coltext.IndexOf(txt) != -1)
                    {
                        if (_addr_e == -1)
                        {
                            return Text.Substring(0, _addr_s) + "\r\n";
                        }
                        return Text.Substring(0, _addr_s) + Text.Substring(_addr_e) + "\r\n";
                    }
                }
                return Text + "\r\n";
            }




        }

        /// <summary>
        /// 提取指定列的内容，失败返回null
        /// </summary>
        /// <param name="Text">要被提取的内容</param>
        /// <param name="Col">列序号</param>
        /// <param name="Splite_Text">分割文本</param>
        /// <returns></returns>
        public static string _Get_Col_Val(string Text, int Col, string Splite_Text)
        {
            int index = -1;
            int _addr_s = -1;
            string coltext;

            while (index < Col - 1)
            {
                _addr_s = Text.IndexOf(Splite_Text, _addr_s + 1);  //寻找分割文本的位置
                if (_addr_s == -1)  //列数不足的略去
                {
                    return null;
                }
                index++;
            }
            int _addr_e = Text.IndexOf(Splite_Text, _addr_s + 1);  //寻找指定列的结尾位置

            if (_addr_e == -1)
            {
                coltext = Text.Substring(_addr_s + Splite_Text.Length);  //从开始位置取文本到结尾
            }
            else
            {
                coltext = Text.Substring(_addr_s + Splite_Text.Length, _addr_e - _addr_s - Splite_Text.Length);
            }
            return coltext;
        }

        #endregion

        #region 去重复
        /// <summary>
        /// 对文件按行去重复
        /// </summary>
        /// <param name="Input_FileName">要被处理对文件列表</param>
        /// <param name="Save_FilePath">保存文件夹地址</param>
        /// <returns></returns>
        public static bool Repeat_Clean_Rows(string[] Input_FileName, string Save_FilePath)
        {
            
            HashSet<string> data = new HashSet<string>();

            foreach (var filename in Input_FileName)
            {

                StreamReader streamReader = new StreamReader(filename);


                while (streamReader.EndOfStream != true)
                {
                    data.Add(streamReader.ReadLine());
                }
                streamReader.Close();
                streamReader.Dispose();

                FileInfo fileInfo = new FileInfo(filename);
                StreamWriter streamWriter = new StreamWriter(Path.Combine(Save_FilePath, fileInfo.Name), false, Encoding.UTF8, 1024 * 1024);

                foreach (var value in data)
                {
                    streamWriter.WriteLine(value);
                }
                streamWriter.Close();
                streamWriter.Dispose();

                data.Clear();

            }

            return true;
        }

        /// <summary>
        /// 对文件按列去重复
        /// </summary>
        /// <param name="Input_FileName">要被处理对文件列表</param>
        /// <param name="Save_FilePath">保存文件夹地址</param>
        /// <param name="Col_Number">被处理的列索引</param>
        /// <param name="Splite_Text">分割文本</param>
        /// <returns></returns>
        public static bool Repeat_Clean_Col(string[] Input_FileName, string Save_FilePath, int Col_Number,
                                            string Splite_Text)
        {
            HashSet<string> Data = new HashSet<string>();

            foreach (var filename in Input_FileName)
            {
                StreamReader streamReader = new StreamReader(filename);

                FileInfo fileInfo = new FileInfo(filename);
                StreamWriter streamWriter = new StreamWriter(Path.Combine(Save_FilePath, fileInfo.Name), false, Encoding.UTF8, 1024 * 1024);


                while (streamReader.EndOfStream != true)
                {
                    var _text = streamReader.ReadLine();

                    string _col_val = _Get_Col_Val(_text, Col_Number, Splite_Text);
                    if (_col_val != null)
                    {
                        if (Data.Contains(_col_val))
                        {
                            continue;
                        }
                        else
                        {
                            Data.Add(_col_val);
                            streamWriter.WriteLine(_text);
                        }
                        
                    }
                }
                streamReader.Close();
                streamWriter.Close();

                Data.Clear();
            }

            return true;
        }
        #endregion

        #region 删除文本
        
        /// <summary>
        /// 去除文本的指定列
        /// </summary>
        /// <param name="Input_FileName">要被处理对文件列表</param>
        /// <param name="Save_FilePath">保存文件夹地址</param>
        /// <param name="Col_Number">被处理的列索引</param>
        /// <param name="Splite_Text">分割文本</param>
        /// <returns></returns>
        public static bool Screen_Clean_Col(string[] Input_FileName, string Save_FilePath, int Col_Number, string Splite_Text)
        {
            foreach (var filename in Input_FileName)
            {
                StreamReader streamReader = new StreamReader(filename);
                FileInfo fileInfo = new FileInfo(filename);


                StreamWriter streamWriter = new StreamWriter(Path.Combine(Save_FilePath, fileInfo.Name), false, Encoding.UTF8, 1024 * 1024);
                while (!streamReader.EndOfStream)
                {
                    string text = streamReader.ReadLine();
                    streamWriter.Write(_Clean_Col(text, Col_Number, Splite_Text));
                }
                streamWriter.Close();
                streamReader.Close();
                streamReader.Dispose();
                streamWriter.Dispose();
            }
            return true;
        }

        /// <summary>
        /// 根据关键词数组去除文本的指定列
        /// </summary>
        /// <param name="Input_FileName">到进行去除到文件列表</param>
        /// <param name="Save_FilePath">要保存到文件夹地址</param>
        /// <param name="Col_Number">指定列</param>
        /// <param name="Splite_Text">分割文本</param>
        /// <param name="KeyWord">关键词列表</param>
        /// <returns></returns>
        public static bool Screen_Clean_Col(string[] Input_FileName, string Save_FilePath, int Col_Number, string Splite_Text, string[] KeyWord)
        {
            foreach (var filename in Input_FileName)
            {
                StreamReader streamReader = new StreamReader(filename);
                FileInfo fileInfo = new FileInfo(filename);


                StreamWriter streamWriter = new StreamWriter(Path.Combine(Save_FilePath, fileInfo.Name), false, Encoding.UTF8, 1024 * 1024);
                while (!streamReader.EndOfStream)
                {
                    string text = streamReader.ReadLine();
                    streamWriter.Write(_Clean_Col_Val(text, Col_Number, Splite_Text, KeyWord));
                }
                streamWriter.Close();
                streamReader.Close();
                streamReader.Dispose();
                streamWriter.Dispose();
            }
            return true;
        }

        /// <summary>
        /// 根据关键词数组去除文本行
        /// </summary>
        /// <param name="Input_FileName">导入的文件数组</param>
        /// <param name="Save_FilePath">保持文件夹位置</param>
        /// <param name="KeyWord">关键词</param>
        /// <returns></returns>
        public static bool Screen_Clean_Row(string[] Input_FileName,string Save_FilePath,string[] KeyWord)
        {
           
            if (KeyWord.Length == 0) return false;

            foreach (string filename in Input_FileName)
            {
                StreamReader streamReader = new StreamReader(filename);
                string save_path = Path.Combine(Save_FilePath, new FileInfo(filename).Name);
                StreamWriter streamWriter = new StreamWriter(save_path, false, Encoding.UTF8, 1024 * 1024);
                if (KeyWord.Length == 1)
                {
                    string keyword = KeyWord[0];
                    while (!streamReader.EndOfStream)
                    {
                        string text = streamReader.ReadLine();
                        if (text.IndexOf(keyword) == -1)
                        {
                            streamWriter.WriteLine(text);
                        }
                    }
                }
                else
                {
                    while (!streamReader.EndOfStream)
                    {
                        string text = streamReader.ReadLine();
                        bool state = true;
                        foreach (string keyword in KeyWord)
                        {
                            if (text.IndexOf(keyword) != -1)
                            {
                                state = false;
                                break;
                            }
                        }
                        if(state) streamWriter.WriteLine(text);
                    }
                }

                streamReader.Close();
                streamWriter.Close();
            }
            return true;
        }


        public static bool Screen_Clean(Repeat_Col_Form Data)
        {
            foreach (var filename in Data.Input_Files)
            {
                StreamReader streamReader = new StreamReader(filename);
                FileInfo fileInfo = new FileInfo(filename);

                StreamWriter streamWriter = new StreamWriter(Path.Combine(Data.Save_Path, fileInfo.Name), false, Encoding.UTF8, 1024 * 1024);

                while (!streamReader.EndOfStream)
                {
                    string text = streamReader.ReadLine();
                    string wtext = text;

                    
                    if (Data.Col_Num != -1)
                    {
                        // 如果列号不等于-1，如果长度不等于-1并且列值长度小于指定长度并且不包含
                        string col_val = _Get_Col_Val(text, Data.Col_Num, Data.Splite_Txt);
                        if (Data.Text_Len != -1 && col_val.Length < Data.Text_Len) continue;
                        if (Data.Key_Words.Length != 0)
                        {
                            foreach (string key in Data.Key_Words)
                            {
                                if (col_val.IndexOf(key) != -1)
                                {
                                    wtext = null;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            wtext = _Clean_Col(text, Data.Col_Num, Data.Splite_Txt);
                        }
                        
                    }
                    else
                    {
                        if (Data.Text_Len != -1 && wtext.Length < Data.Text_Len) continue;
                        if (Data.Key_Words.Length != 0)
                        {
                            foreach (string key in Data.Key_Words)
                            {
                                if (wtext.IndexOf(key) != -1)
                                {
                                    wtext = null;
                                    break;
                                }
                            }
                        }
                        
                    }
                    streamWriter.Write(wtext);
                }

                   
                
                
                
                
                streamWriter.Close();
                streamReader.Close();
                streamReader.Dispose();
                streamWriter.Dispose();
            }
            return true;
        }
        #endregion

    }
}
