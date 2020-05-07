using System;
using System.IO;
using System.Text;

namespace TextDLL
{
    interface TextTemplate
    {
        string Write(string path, string text);

        string Read(string path);
    }

    public class Text : TextTemplate
    {
        public string Read(string path)
        {
            StreamReader reader = new StreamReader(path);
            string text;
            text = reader.ReadToEnd();
            reader.Close();
            reader.Dispose();
            return text;
        }

        public string Write(string path, string text)
        {
            try
            {
                StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8);
                writer.WriteLine(text);
                writer.Flush();
                writer.Close();
                return "Ok";
            }
            catch (Exception e)
            {
                return "Не удалось записать в файл, ошибка - " + e.Message;
            }
        }
    }
}
