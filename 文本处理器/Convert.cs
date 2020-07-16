using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 文本处理器
{
    class Convert
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
                while (! streamReader.EndOfStream)
                {
                    string text = streamReader.ReadLine();
                    text.IndexOf()
                }
            }

        }
    }
}
