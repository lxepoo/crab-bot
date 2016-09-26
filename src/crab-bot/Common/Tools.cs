using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CrabBot.Common
{
    public class Tools
    {
        //判断一个字符串是否为日期格式
        public static bool IsDate(string s)
        {
            DateTime dt;
            return DateTime.TryParseExact(s, "yyyy-M-d", null, DateTimeStyles.None, out dt);
        }


        /// <summary>
        /// 输出文字到控制台
        /// </summary>
        /// <param name="text">需要输出的文字</param>
        public static void PrintLn(string text)
        {
            Console.WriteLine(" " + text + "\n");
            //StreamWriter sw = File.AppendText("./logs.txt");
            //string w = text + "\r\n";
            //sw.Write(w);
            //sw.
        }

        /// <summary>
        /// 输出文字到控制台，并设置颜色
        /// </summary>
        /// <param name="text">需要输出的文字</param>
        /// <param name="color">颜色</param>
        public static void PrintLn(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(" " + text + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            //StreamWriter sw = File.AppendText("./logs.txt");
            //string w = text + "\r\n";
            //sw.Write(w);
            //sw.Close();
        }
    }
}
