using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CrabBot.Common
{
    public class Tools
    {
        /// <summary>
        /// 判断一个字符串是否为日期格式
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsDate(string s)
        {
            DateTime dt;
            return DateTime.TryParseExact(s, "yyyy-M-d", null, DateTimeStyles.None, out dt);
        }

        /// <summary>
        /// 是否合法IP地址
        /// </summary>
        /// <param name="ip">IP字符串</param>
        /// <returns>返回bool</returns>
        public static bool IsValidIP(string ip)
        {
            Regex reg = new Regex(@"^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])$");
            Match ma = reg.Match(ip);
            if (ma.Success)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 是否合法端口
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static bool IsPort(string num)
        {
            //是数字
            if (IsNumber(num))
            {
                try
                {
                    int port = int.Parse(num);
                    if (port < 3000 || port > 65530)
                    {
                        return false;
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// 是否数字
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static bool IsNumber(string num)
        {
            Regex reg = new Regex("^[0-9]+$");
            Match ma = reg.Match(num);
            if (ma.Success)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 输出文字到控制台
        /// </summary>
        /// <param name="text">需要输出的文字</param>
        public static void PrintLn(string text)
        {
            Console.WriteLine(text + Environment.NewLine);
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
            Console.WriteLine(text + Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// 打印Debug信息
        /// </summary>
        /// <param name="text">需要输出的文字</param>
        /// <param name="color">颜色，默认黄色</param>
        public static void PrintDebug(string text, ConsoleColor color = ConsoleColor.DarkYellow)
        {
            //仅在debug模式下才输出相关信息
            if (!ServerGlobal.debug)
            {
                return;
            }

            //线程ID
            int tid = Thread.CurrentThread.ManagedThreadId;
            Console.ForegroundColor = color;

            //Environment.NewLine决定换行符，win和linux不同
            Console.WriteLine("[Debug] Thread" + tid + "：" + Environment.NewLine + text + Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>  
        /// 根据GUID获取16位的唯一字符串  
        /// </summary>  
        public static string GuidTo16String()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
                i *= ((int)b + 1);
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }
    }
}
