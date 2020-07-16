using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace 文本处理器
{
    class Convert
    {
        public static bool Clean_Repeat_Rows(string[] Input_FileName,string Save_FilePath)
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

        public static bool Clean_Repeat_Col(string[] Input_FileName, string Save_FilePath,int Col_Number,string Splite_Text)
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
    }
}
