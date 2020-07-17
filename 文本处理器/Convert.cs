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
        /// <summary>
        /// 对文件按行去重复
        /// </summary>
        /// <param name="Input_FileName">要被处理对文件列表</param>
        /// <param name="Save_FilePath">保存文件夹地址</param>
        /// <returns></returns>
        public static bool Repeat_Clean_Rows(string[] Input_FileName,string Save_FilePath)
        {
            if (Input_FileName.Length == 0) return false;
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
                StreamWriter streamWriter = new StreamWriter(Path.Combine(Save_FilePath, fileInfo.Name),false,Encoding.UTF8, 1024 * 1024);

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
            if (Input_FileName.Length == 0) return false;

            int _col_num = Col_Number + 1;
            char[] _splite_txt = Splite_Text.ToCharArray();

            Dictionary<string, string> data = new Dictionary<string, string>();
            

            foreach (var filename in Input_FileName)
            {
                StreamReader streamReader = new StreamReader(filename);

                while (streamReader.EndOfStream != true)
                {
                    var _text = streamReader.ReadLine();
                    try
                    {
                        data.Add(_text.Split(_splite_txt, _col_num)[Col_Number], _text);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    
                }
                streamReader.Close();
                streamReader.Dispose();

                FileInfo fileInfo = new FileInfo(filename);
                StreamWriter streamWriter = new StreamWriter(Path.Combine(Save_FilePath, fileInfo.Name), false, Encoding.UTF8, 1024 * 1024);

                foreach (var value in data)
                {
                    streamWriter.WriteLine(value.Value);
                }
                streamWriter.Close();
                streamWriter.Dispose();

                data.Clear();

            }

            return true;
        }

        /// <summary>
        /// 删除指定列，返回剩余文本
        /// </summary>
        /// <param name="Text">要被删除的文本</param>
        /// <param name="Col">指定列</param>
        /// <param name="Splite_Text">用来分割的文本</param>
        /// <returns></returns>
        private static string _Clean_Col(string Text,int Col,string Splite_Text)
        {
            int index = -1;
            int _addr_s = -1;
            while (index < Col-1)
            {
                _addr_s = Text.IndexOf(Splite_Text, _addr_s + 1);
                if (_addr_s == -1)
                {
                    return null;
                }
                index++;
            }
            int _addr_e = Text.IndexOf(Splite_Text, _addr_s + 1);
            if (_addr_e == -1) return Text.Substring(0, _addr_s);
            
            return Text.Substring(0, _addr_s) + Text.Substring(_addr_e) + "\r\n";
        }

        public static string _Clean_Col_Val(string Text, int Col, string Splite_Text,string Find_Text)
        {
            int index = -1;
            int _addr_s = -1;
            string subtext = "";
            while (index < Col - 1)
            {
                _addr_s = Text.IndexOf(Splite_Text, _addr_s + 1);
                if (_addr_s == -1)
                {
                    return null;
                }
                index++;
            }
            int _addr_e = Text.IndexOf(Splite_Text, _addr_s + 1);
            if (_addr_e == -1)
            {
                _addr_s = Text.LastIndexOf(Splite_Text, _addr_e);
                subtext = Text.Substring(_addr_s, _addr_e - _addr_s);
            }
            else
            {
                _addr_s += Splite_Text.Length;
                subtext = Text.Substring(_addr_s, _addr_e - _addr_s);
            }

            if (subtext.IndexOf(Find_Text) != -1)
            {

            }

            return Text.Substring(0, _addr_s) + Text.Substring(_addr_e) + "\r\n";
        }


        /// <summary>
        /// 去除文本的指定列
        /// </summary>
        /// <param name="Input_FileName">要被处理对文件列表</param>
        /// <param name="Save_FilePath">保存文件夹地址</param>
        /// <param name="Col_Number">被处理的列索引</param>
        /// <param name="Splite_Text">分割文本</param>
        /// <returns></returns>
        public static bool Screen_Clean_Col(string[] Input_FileName, string Save_FilePath,int Col_Number,string Splite_Text)
        {
            if (Input_FileName.Length == 0) return false;
            foreach (var filename in Input_FileName)
            {
                StreamReader streamReader = new StreamReader(filename);
                FileInfo fileInfo = new FileInfo(filename);
                
                
                StreamWriter streamWriter = new StreamWriter(Path.Combine(Save_FilePath, fileInfo.Name),false, Encoding.UTF8, 1024 * 1024);
                while (! streamReader.EndOfStream)
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
    
        public static bool Screen_Clean_Col(string[] Input_FileName,string Save_FilePath,int Col_Number,string Splite_Text,string Replace_Text)
        {
            if (Input_FileName.Length == 0) return false;
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
    }
}
