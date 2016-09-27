using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Sockets;

namespace CrabBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //强制指定输出编码为Unicode，否则中文会乱码
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Common.Tools.PrintLn("程序启动中...");

            //注册一个系统机器人
            Model.Bot SysBot = new Model.Bot();
            SysBot.BotId = "system";
            SysBot.Name = "系统机器人";
            SysBot.Description = "系统机器人主要用于维护整个机器人系统，比如：注册用户、注册机器人、配置相关等。";
            Global.RegisterBot(SysBot);

            //定义监听信息
            Common.Tools.PrintLn("开始创建Socket服务器...");
            IPAddress local = IPAddress.Parse("0.0.0.0");
            IPEndPoint iep = new IPEndPoint(local, 8989);

            Common.Tools.PrintLn("监听："+iep.ToString());

            //创建服务器的socket对象
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //绑定
            server.Bind(iep);

            //监听
            server.Listen(20);

            //开始监听连接  
            while (true)
            {
                Console.WriteLine("等待客户端连接...");

                //线程将一直阻塞直到有新的客户端连接
                Socket handler = server.Accept();

                //启用一个新的线程用于处理客户端连接  ，这样主线程还可以继续接受客户端连接  
                SocketThread socketThread = new SocketThread(handler);
            }

            //Common.Tools.PrintLn("程序结束...");
            //server.BeginAccecpt(new AsyncCallback(Accept), server);
        }
    }
}
