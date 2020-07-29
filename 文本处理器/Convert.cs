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
            int _addr_s = Text.IndexOf(Split_Text);   //获取第一个分隔符的位置

            if (_addr_s == -1)
            {
                return null;  //如果不存在分隔符，则退出
            }
            else
            {
                _addr_s += split_len;   //如果存在分隔符，则加上分隔符的长度，现在的游标位于分隔符的右侧边缘
            }
            
            if (Col == 0)
            {
                return Text.Substring(_addr_s) + "\r\n";
            }
            if (Col == 1)  //如果是第一列，则读取分隔符前的子字符串 加上 下一个分隔符右边的字符串
            {
                int _ = Text.IndexOf(Split_Text, _addr_s);
                if (_ == -1)
                {
                    return Text.Substring(0, _addr_s - split_len) + "\r\n";
                }
                else
                {
                    return Text.Substring(0, _addr_s) + Text.Substring(_+split_len) + "\r\n";
                }
                
            }

            int index = 1;
            
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
            if (_addr_e == -1) return Text.Substring(0, _addr_s - split_len) + "\r\n";

            return Text.Substring(0, _addr_s) + Text.Substring(_addr_e + split_len) + "\r\n";
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

            do
            {
                _addr_s = Text.IndexOf(Splite_Text, _addr_s + 1);  //寻找分割文本的位置
                if (_addr_s == -1)  //列数不足的略去
                {
                    if (Col == 0)
                    {
                        return Text;
                    }
                    return null;
                }
                index++;
            } while (index < Col - 1);

            //while (index < Col - 1)
            //{
            //    _addr_s = Text.IndexOf(Splite_Text, _addr_s + 1);  //寻找分割文本的位置
            //    if (_addr_s == -1)  //列数不足的略去
            //    {
            //        return null;
            //    }
            //    index++;
            //}
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

        #region 筛选文本
        
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

        /// <summary>
        /// 根据关键词数组保存文本行
        /// </summary>
        /// <param name="Input_FileName">导入的文件数组</param>
        /// <param name="Save_FilePath">保持文件夹位置</param>
        /// <param name="KeyWord">关键词</param>
        /// <returns></returns>
        public static bool Screen_Save_Row(string[] Input_FileName, string Save_FilePath, string[] KeyWord)
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
                        if (text.IndexOf(keyword) != -1)
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
                        if (state) streamWriter.WriteLine(text);
                    }
                }

                streamReader.Close();
                streamWriter.Close();
            }
            return true;
        }

        /// <summary>
        /// 根据关键词数组保存文本的指定列
        /// </summary>
        /// <param name="Input_FileName">到进行去除到文件列表</param>
        /// <param name="Save_FilePath">要保存到文件夹地址</param>
        /// <param name="Col_Number">指定列</param>
        /// <param name="Splite_Text">分割文本</param>
        /// <param name="KeyWord">关键词列表</param>
        /// <returns></returns>
        public static bool Screen_Save_Col(string[] Input_FileName, string Save_FilePath, int Col_Number, string Splite_Text, string[] KeyWord)
        {
            foreach (var filename in Input_FileName)
            {
                StreamReader streamReader = new StreamReader(filename);
                FileInfo fileInfo = new FileInfo(filename);


                StreamWriter streamWriter = new StreamWriter(Path.Combine(Save_FilePath, fileInfo.Name), false, Encoding.UTF8, 1024 * 1024);
                while (!streamReader.EndOfStream)
                {
                    string text = streamReader.ReadLine();
                    string _col_val = _Get_Col_Val(text, Col_Number, Splite_Text);
                    if (_col_val == null)
                    {
                        continue;
                    }
                    else
                    {
                        foreach (string key in KeyWord)
                        {
                            if(_col_val.IndexOf(key) != -1)
                            {
                                streamWriter.Write(text + "\r\n");
                                break;
                            }
                        }
                    }
                    
                }
                streamWriter.Close();
                streamReader.Close();
                streamReader.Dispose();
                streamWriter.Dispose();
            }
            return true;
        }

        /// <summary>
        /// 保留指定长度的行
        /// </summary>
        /// <param name="Input_FileName">读取文件数组</param>
        /// <param name="Save_FilePath">保存文件夹位置</param>
        /// <param name="Len_Num">行长度,等于Len_Num</param>
        /// <returns></returns>
        public static bool Screen_Save_Row_Len(string [] Input_FileName,string Save_FilePath,int Len_Num)
        {
            foreach (var filepath in Input_FileName)
            {
                StreamReader file_read = new StreamReader(filepath);
                StreamWriter file_write = new StreamWriter(Path.Combine(Save_FilePath, Path.GetFileName(filepath)), false, Encoding.UTF8, 1024 * 1024);

                while (!file_read.EndOfStream)
                {
                    string text = file_read.ReadLine();
                    if (text.Length == Len_Num)
                    {
                        file_write.WriteLine(text);
                    }
                }
                file_read.Close();
                file_write.Close();
            }
            return true;
        }

        /// <summary>
        /// 保留指定列长度等于指定长度的行
        /// </summary>
        /// <param name="Input_FileName"></param>
        /// <param name="Save_FilePath"></param>
        /// <param name="Split_Text"></param>
        /// <param name="Col_Num">指定列</param>
        /// <param name="Len_Num">指定长度</param>
        /// <returns></returns>
        public static bool Screen_Save_Col_Len(string[] Input_FileName,string Save_FilePath,string Split_Text,int Col_Num,int Len_Num)
        {
            foreach (var filepath in Input_FileName)
            {
                StreamReader file_read = new StreamReader(filepath);
                StreamWriter file_write = new StreamWriter(Path.Combine(Save_FilePath, Path.GetFileName(filepath)), false, Encoding.UTF8, 1024 * 1024);

                while (!file_read.EndOfStream)
                {
                    string text = file_read.ReadLine();
                    string col_val = _Get_Col_Val(text, Col_Num, Split_Text);

                    if (col_val != null && col_val.Length == Len_Num)
                    {
                        file_write.WriteLine(text);
                    }
                }
                file_read.Close();
                file_write.Close();
            }
            return true;
        }
        
        /// <summary>
        /// 提取指定范围的行
        /// </summary>
        /// <param name="Input_FileName"></param>
        /// <param name="Save_FilePath"></param>
        /// <param name="Start">开始行数(包含)</param>
        /// <param name="End">结束行数(包含)</param>
        /// <returns></returns>
        public static bool Screen_Save_Range_Row(string[] Input_FileName,string Save_FilePath,int Start,int End)
        {
            foreach (var filepath in Input_FileName)
            {
                StreamReader file_read = new StreamReader(filepath);
                StreamWriter file_write = new StreamWriter(Path.Combine(Save_FilePath, Path.GetFileName(filepath)), false, Encoding.UTF8, 1024 * 1024);

                for (int i = 0; i < Start; i++)
                {
                    if (!file_read.EndOfStream)
                    {
                        file_read.ReadLine();
                    }
                    else
                    {
                        break;
                    }
                }

                if (file_read.EndOfStream)
                {
                    file_read.Close();
                    file_write.Close();
                    continue;
                }

                for (int i = Start; i < End + 1; i++)
                {
                    if (!file_read.EndOfStream)
                    {
                        file_write.WriteLine(file_read.ReadLine());
                    }
                    else
                    {
                        break;
                    }
                }
                file_read.Close();
                file_write.Close();
            }
            return true;
        }
        
        /// <summary>
        /// 提取行内含有指定数量的列的行
        /// </summary>
        /// <param name="Input_FileName"></param>
        /// <param name="Save_FilePath"></param>
        /// <param name="Split_Text"></param>
        /// <param name="Col_Num">指定数量列</param>
        /// <returns></returns>
        public static bool Screen_Save_Col_Split_Len(string[] Input_FileName,string Save_FilePath,string Split_Text,int Col_Num)
        {
            foreach (var filepath in Input_FileName)
            {
                StreamReader file_read = new StreamReader(filepath);
                StreamWriter file_write = new StreamWriter(Path.Combine(Save_FilePath, Path.GetFileName(filepath)), false, Encoding.UTF8, 1024 * 1024);

                while (!file_read.EndOfStream)
                {
                    string text = file_read.ReadLine();

                    if (Col_Num == 1)
                    {
                        file_write.WriteLine(text);
                    }
                    else if (Col_Num == 2)
                    {
                        if (text.Contains(Split_Text))
                        {
                            file_write.WriteLine(text);
                        }
                    }
                    else
                    {
                        int addr = 0 - Split_Text.Length;
                        for (int i = 0; i < Col_Num; i++)
                        {
                            addr = text.IndexOf(Split_Text, addr + Split_Text.Length);
                            if (addr == -1) break;
                        }
                        if (addr != -1) file_write.WriteLine(text);
                    }

                    
                }
                file_read.Close();
                file_write.Close();
            }
            return true;
        }

        #endregion

        #region 集合操作
        /// <summary>
        /// 交集
        /// </summary>
        /// <param name="File_A">文件A</param>
        /// <param name="File_B">文件B</param>
        /// <param name="Save_File">保存地址</param>
        /// <returns></returns>
        public static bool Intersection(string File_A,string File_B,string Save_File)
        {
            StreamReader file_A = new StreamReader(File_A);
            StreamReader file_B = new StreamReader(File_B);
            StreamWriter save_file = new StreamWriter(Save_File, false, Encoding.UTF8, 1024 * 1024 * 10);
            HashSet<string> hashdata = new HashSet<string>();

            while (! file_A.EndOfStream)
            {
                hashdata.Add(file_A.ReadLine());
            }
            file_A.Close();

            while (!file_B.EndOfStream)
            {
                string txt = file_B.ReadLine();
                if (hashdata.Contains(txt)) save_file.WriteLine(txt);
            }
            hashdata.Clear();
            file_B.Close();
            save_file.Close();
            return true;
        }
        /// <summary>
        /// 交集
        /// </summary>
        /// <param name="File_A">文件A</param>
        /// <param name="File_B">文件B</param>
        /// <param name="Save_File">保存地址</param>
        /// <returns></returns>
        public static bool Intersection(string File_A, string File_B, string Save_File,string Split,int Col_Num)
        {
            StreamReader file_A = new StreamReader(File_A);
            StreamReader file_B = new StreamReader(File_B);
            StreamWriter save_file = new StreamWriter(Save_File, false, Encoding.UTF8, 1024 * 1024 * 10);
            HashSet<string> hashdata = new HashSet<string>();

            while (!file_A.EndOfStream)
            {
                string txt = file_A.ReadLine();
                string col_val = _Get_Col_Val(txt, Col_Num, Split);
                if (col_val != null) hashdata.Add(col_val);
            }
            file_A.Close();

            while (!file_B.EndOfStream)
            {
                string txt = file_B.ReadLine();
                string col_val = _Get_Col_Val(txt, Col_Num, Split);
                if (col_val != null && hashdata.Contains(col_val)) save_file.WriteLine(txt);
                
            }
            hashdata.Clear();
            file_B.Close();
            save_file.Close();
            return true;
        }

        /// <summary>
        /// 并集
        /// </summary>
        /// <param name="File_A"></param>
        /// <param name="File_B"></param>
        /// <param name="Save_File"></param>
        /// <returns></returns>
        public static bool Union(string File_A,string File_B,string Save_File)
        {
            //File.Copy(File_A, Save_File, true);

            //byte[] arr = {0,0};
            //FileStream fileStream = new FileStream(Save_File, FileMode.Open);
            //fileStream.Seek(-2,SeekOrigin.End);
            //fileStream.Read(arr, 0, 2);
            //if (arr[0] != 13 || arr[1] != 10)
            //{
            //    arr[0] = 13;
            //    arr[1] = 10;
            //    fileStream.Write(arr, 0, 2);
            //}
            //fileStream.Close();

            

            StreamReader file_A = new StreamReader(File_A);
            StreamReader file_B = new StreamReader(File_B);
            StreamWriter save_file = new StreamWriter(Save_File, false, Encoding.UTF8, 1024 * 1024 * 10);

            HashSet<string> hashdata = new HashSet<string>();
            

            while (!file_A.EndOfStream)
            {
                hashdata.Add(file_A.ReadLine());
            }

            file_A.Close();

            foreach (string val in hashdata)
            {
                save_file.WriteLine(val);
            }

            while (!file_B.EndOfStream)
            {
                string txt = file_B.ReadLine();
                if (!hashdata.Contains(txt))
                {
                    hashdata.Add(txt);
                    save_file.WriteLine(txt);
                }
            }
            hashdata.Clear();
            file_B.Close();
            save_file.Close();
            return true;
        }

        /// <summary>
        /// 并集
        /// </summary>
        /// <param name="File_A"></param>
        /// <param name="File_B"></param>
        /// <param name="Save_File"></param>
        /// <returns></returns>
        public static bool Union(string File_A, string File_B, string Save_File, string Split, int Col_Num)
        {
            StreamReader file_A = new StreamReader(File_A);
            StreamReader file_B = new StreamReader(File_B);
            StreamWriter save_file = new StreamWriter(Save_File, false, Encoding.UTF8, 1024 * 1024 * 10);

            HashSet<string> hashdata = new HashSet<string>();


            while (!file_A.EndOfStream)
            {
                string txt = file_A.ReadLine();
                string col_val = _Get_Col_Val(txt, Col_Num, Split);
                if (col_val != null && hashdata.Contains(col_val) == false)
                {
                    hashdata.Add(col_val);
                    save_file.WriteLine(txt);
                }
            }
            file_A.Close();


            while (!file_B.EndOfStream)
            {
                string txt = file_B.ReadLine();
                string col_val = _Get_Col_Val(txt, Col_Num, Split);
                if (col_val != null && hashdata.Contains(col_val) == false)
                {
                    hashdata.Add(col_val);
                    save_file.WriteLine(txt);
                }
            }
            hashdata.Clear();
            file_B.Close();
            save_file.Close();
            return true;
        }

        /// <summary>
        /// 差集
        /// </summary>
        /// <param name="File_A"></param>
        /// <param name="File_B"></param>
        /// <param name="Save_File"></param>
        /// <returns></returns>
        public static bool Except(string File_A,string File_B,string Save_File)
        {
            StreamReader file_A = new StreamReader(File_A);
            StreamReader file_B = new StreamReader(File_B);
            StreamWriter save_file = new StreamWriter(Save_File, false, Encoding.UTF8, 1024 * 1024 * 10);

            HashSet<string> hash_A = new HashSet<string>();
            HashSet<string> hash_B = new HashSet<string>();


            while (!file_A.EndOfStream)
            {
                hash_A.Add(file_A.ReadLine());
            }
            file_A.Close();

            while (!file_B.EndOfStream)
            {
                hash_B.Add(file_B.ReadLine());
            }
            file_B.Close();

            hash_A.ExceptWith(hash_B.AsEnumerable());

            foreach (string val in hash_A)
            {
                save_file.WriteLine(val);
            }
            save_file.Close();
            return true;
        }

        /// <summary>
        /// 差集
        /// </summary>
        /// <param name="File_A"></param>
        /// <param name="File_B"></param>
        /// <param name="Save_File"></param>
        /// <returns></returns>
        public static bool Except(string File_A, string File_B, string Save_File, string Split, int Col_Num)
        {
            StreamReader file_A = new StreamReader(File_A);
            StreamReader file_B = new StreamReader(File_B);
            StreamWriter save_file = new StreamWriter(Save_File, false, Encoding.UTF8, 1024 * 1024 * 10);

            HashSet<string> hash_B = new HashSet<string>();


            while (!file_B.EndOfStream)
            {
                string text = file_B.ReadLine();
                string col_val = _Get_Col_Val(text, Col_Num, Split);
                if (col_val != null)
                {
                    hash_B.Add(col_val);
                }
                
            }
            file_B.Close();

            while (!file_A.EndOfStream)
            {
                string text = file_A.ReadLine();
                string col_val = _Get_Col_Val(text, Col_Num, Split);
                if (col_val != null && hash_B.Contains(col_val) == false)
                {
                    hash_B.Add(col_val);
                    save_file.WriteLine(text);
                }
            }
            hash_B.Clear();
            file_A.Close();
            save_file.Close();
            return true;
        }
        /// <summary>
        /// 补集
        /// </summary>
        /// <param name="File_A"></param>
        /// <param name="File_B"></param>
        /// <param name="Save_File"></param>
        /// <returns>返回存在于a但不存在于b的数据</returns>
        public static bool Complementary(string File_A, string File_B, string Save_File)
        {
            StreamReader file_A = new StreamReader(File_A);
            StreamReader file_B = new StreamReader(File_B);
            StreamWriter save_file = new StreamWriter(Save_File, false, Encoding.UTF8, 1024 * 1024 * 10);

            HashSet<string> hashdata = new HashSet<string>();

            while (!file_B.EndOfStream)
            {
                hashdata.Add(file_B.ReadLine());
            }
            while (!file_A.EndOfStream)
            {
                string text = file_A.ReadLine();
                if (!hashdata.Contains(text))
                {
                    save_file.WriteLine(text);
                }
            }
            hashdata.Clear();
            file_A.Close();
            file_B.Close();
            save_file.Close();
            
            return true;
        }
        /// <summary>
        /// 补集
        /// </summary>
        /// <param name="File_A"></param>
        /// <param name="File_B"></param>
        /// <param name="Save_File"></param>
        /// <returns>返回存在于a但不存在于b的数据</returns>
        public static bool Complementary(string File_A, string File_B, string Save_File, string Split, int Col_Num)
        {
            StreamReader file_A = new StreamReader(File_A);
            StreamReader file_B = new StreamReader(File_B);
            StreamWriter save_file = new StreamWriter(Save_File, false, Encoding.UTF8, 1024 * 1024 * 10);

            HashSet<string> hashdata = new HashSet<string>();

            while (!file_B.EndOfStream)
            {
                string txt = file_B.ReadLine();
                string col_val = _Get_Col_Val(txt, Col_Num, Split);
                hashdata.Add(col_val);
            }
            while (!file_A.EndOfStream)
            {
                string txt = file_A.ReadLine();
                string col_val = _Get_Col_Val(txt, Col_Num, Split);
                if (!hashdata.Contains(col_val))
                {
                    hashdata.Add(col_val);
                    save_file.WriteLine(txt);
                }
            }
            hashdata.Clear();
            file_A.Close();
            file_B.Close();
            save_file.Close();

            return true;
        }

        /// <summary>
        /// 对称差集
        /// </summary>
        /// <param name="File_A"></param>
        /// <param name="File_B"></param>
        /// <param name="Save_File"></param>
        /// <returns></returns>
        public static bool Sym_Except(string File_A, string File_B, string Save_File)
        {
            StreamReader file_A = new StreamReader(File_A);
            StreamReader file_B = new StreamReader(File_B);
            StreamWriter save_file = new StreamWriter(Save_File, false, Encoding.UTF8, 1024 * 1024 * 10);

            HashSet<string> hash_A = new HashSet<string>();
            HashSet<string> hash_B = new HashSet<string>();


            while (!file_A.EndOfStream)
            {
                hash_A.Add(file_A.ReadLine());
            }
            file_A.Close();

            while (!file_B.EndOfStream)
            {
                hash_B.Add(file_B.ReadLine());
            }
            file_B.Close();

            
            foreach(string val in hash_A.Except(hash_B.AsEnumerable()))
            {
                save_file.WriteLine(val);
            }
            foreach (string val in hash_B.Except(hash_A.AsEnumerable()))
            {
                save_file.WriteLine(val);
            }

            hash_A.Clear();
            hash_B.Clear();
            
            save_file.Close();
            return true;
        }

        /// <summary>
        /// 对称差集
        /// </summary>
        /// <param name="File_A"></param>
        /// <param name="File_B"></param>
        /// <param name="Save_File"></param>
        /// <returns></returns>
        public static bool Sym_Except(string File_A, string File_B, string Save_File, string Split, int Col_Num)
        {
            StreamReader file_A = new StreamReader(File_A);
            StreamReader file_B = new StreamReader(File_B);
            StreamWriter save_file = new StreamWriter(Save_File, false, Encoding.UTF8, 1024 * 1024 * 10);

            Dictionary<string, string> hash_a = new Dictionary<string, string>();
            Dictionary<string, string> hash_b = new Dictionary<string, string>();


            while (!file_A.EndOfStream)
            {
                string txt = file_A.ReadLine();
                string col_val = _Get_Col_Val(txt, Col_Num, Split);
                if (col_val != null && hash_a.ContainsKey(col_val)==false)
                {
                    hash_a.Add(col_val, txt);
                }
            }
            file_A.Close();

            while (!file_B.EndOfStream)
            {
                string txt = file_B.ReadLine();
                string col_val = _Get_Col_Val(txt, Col_Num, Split);
                if (col_val != null && hash_b.ContainsKey(col_val) == false)
                {
                    hash_b.Add(col_val, txt);
                }
            }
            file_B.Close();

            #region 计算对称差集
            string[] keys = hash_a.Keys.ToArray();
            foreach (string key in keys)
            {
                if (hash_b.ContainsKey(key))
                {
                    hash_a.Remove(key);
                    hash_b.Remove(key);
                }
            }

            keys = hash_b.Keys.ToArray();
            foreach (string key in keys)
            {
                if (hash_a.ContainsKey(key))
                {
                    hash_a.Remove(key);
                    hash_b.Remove(key);
                }
            }

            #endregion

            #region 写出文件
            foreach (KeyValuePair<string, string> item in hash_a)
            {
                save_file.WriteLine(item.Value);
            }

            foreach (KeyValuePair<string, string> item in hash_b)
            {
                save_file.WriteLine(item.Value);
            }
            #endregion






            //foreach (var val in hash_a.Except(hash_b.AsEnumerable()))
            //{
            //    save_file.WriteLine(val.Value);
            //    Console.WriteLine(val.Value);
            //}
            //foreach (var val in hash_b.Except(hash_a.AsEnumerable()))
            //{
            //    save_file.WriteLine(val.Value);
            //    Console.WriteLine(val.Value);
            //}
            hash_a.Clear();
            hash_b.Clear();

            save_file.Close();
            return true;
        }

        #endregion
    }
}
