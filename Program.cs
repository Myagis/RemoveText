using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2savarankiškas
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd = "..\\..\\Duomenys.txt";
            const string CFr = "..\\..\\Rezultatai.txt";
            const string CFa = "..\\..\\Analize.txt";
            InOut.Process(CFd, CFr, CFa);
        }
    }
    static class InOut
    {
        public static void Process(string fin, string fout, string finfo)
        {
            string[] lines = File.ReadAllLines(fin, Encoding.UTF8);
            bool flag = true;
            string newLine= "";

            using (var writerF = File.CreateText(fout))
            {
                using (var writerI = File.CreateText(finfo))
                {

                    foreach (string line in lines)
                    {
                        if (line.Length > 0)
                        {
                            if (line.Contains("/*"))
                            {
                                flag = false;
                            }
                            if (line.Contains("*/"))
                            {
                                flag = true;
                            }

                            if (TaskUtils.CreateString(line, newLine, flag) != "")
                            {
                                writerF.WriteLine(TaskUtils.CreateString(line, newLine, flag));
                            }
                        }
                    }
                }
            }
        }

      

    class TaskUtils
    {
            public static string CreateString(string line, string newLine, bool flag)
            {
                if (flag && !line.Contains("*/"))
                {
                    newLine = line;
                }

                for (int i = 0; i < line.Length - 1; i++)
                {
                    if (line[i] == '/' && line[i + 1] == '/')
                    {
                        newLine = line.Remove(i);
                    }
                }
                return newLine;
            }
        }
    }
}
