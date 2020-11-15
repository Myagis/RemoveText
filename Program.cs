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
            using (var writerF = File.CreateText(fout))
            {
                using (var writerI = File.CreateText(finfo))
                {
                    foreach (string line in lines)
                    {
                        if (line.Length > 0)
                        {
                            string newLine = line;
                            if (TaskUtils.RemoveComments(line, out newLine))
                            {
                                writerI.WriteLine(line);
                            }
                            if (newLine.Length > 0)
                            {
                                writerF.WriteLine(newLine);
                            }
                        }
                        else
                        {
                            writerF.WriteLine(line);
                        }
                    }
                }
            }
        }

    }

    class TaskUtils
    {
        public static bool RemoveComments(string line, out string newLine)
        {
            newLine = line;
            for (int i = 0; i < line.Length - 1; i++)
            {
                if (line[i] == '/' && line[i + 1] == '/') 
                {
                    newLine = line.Remove(i);
                    return true;
                }
                else if(line[i] == '*' && line[i + 1] == '/')
                {
                    newLine = line.Substring(i+ 2);
                    return true;
                }

            }
            return false;
        }
    }
}
