using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using Microsoft.Data.Sqlite;
using System.Threading;

namespace CrabBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //强制指定输出编码为Unicode，否则中文会乱码
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            //解析命令行参数
            ServerGlobal.ArgsFormat(args);

            //welcome
            Common.Tools.PrintLn("程序启动中...");

            //输出相关信息
            Common.Tools.PrintLn("调试模式：" + ServerGlobal.debug.ToString(), ConsoleColor.Blue);
            Common.Tools.PrintLn("监听地址：" + ServerGlobal.ip.ToString(), ConsoleColor.Blue);
            Common.Tools.PrintLn("监听端口：" + ServerGlobal.port.ToString(), ConsoleColor.Blue);
            Common.Tools.PrintLn("持久化间隔（秒）：" + ServerGlobal.persistenceTime.ToString(), ConsoleColor.Blue);

            //执行所有前置操作
            ServerInit();

            //开启持久化工作
            Persistence();

            //定义监听信息
            IPEndPoint iep = new IPEndPoint(ServerGlobal.ip, ServerGlobal.port);

            //创建服务器的socket对象
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //绑定
            server.Bind(iep);

            //监听
            server.Listen(20);

            //开始监听连接
            while (true)
            {
                Common.Tools.PrintLn("Socket服务器已创建，等待客户端连接...", ConsoleColor.Green);

                //线程将一直阻塞直到有新的客户端连接
                Socket handler = server.Accept();

                //启用一个新的线程用于处理客户端连接  ，这样主线程还可以继续接受客户端连接  
                SocketThread socketThread = new SocketThread(handler);
            }
        }

        /// <summary>
        /// 初始化相关的操作
        /// </summary>
        public static void ServerInit()
        {

            #region 检查Data文件夹等相关逻辑
            string data_path = Directory.GetCurrentDirectory() + "/Data";
            string ori_path = Directory.GetCurrentDirectory() + "/Original";
            if (!Directory.Exists(data_path))
            {
                //创建目录
                if (Directory.CreateDirectory(data_path) != null)
                {
                    Common.Tools.PrintLn("Data目录创建成功！", ConsoleColor.Blue);
                }
                else
                {
                    Common.Tools.PrintLn("Data目录创建失败，请检查服务环境、配置！", ConsoleColor.Red);
                    Console.ReadLine();
                }
            }
            #endregion

            #region 初始化数据库连接等

            if (ServerGlobal.dbType == "SQLite")
            {
                var oridbPath = ori_path + "/OriginalDatabase.db";
                var dbPath = data_path + "/CrabBot.db";

                //如果库不存在，就copy一份到Data下
                if (!File.Exists(dbPath))
                {
                    Common.Tools.PrintLn("数据库文件不存在，即将创建...", ConsoleColor.Blue);
                    File.Copy(oridbPath, dbPath);
                }

                //数据库路径
                ServerGlobal.connStr = (new SqliteConnectionStringBuilder() { DataSource = data_path + "/CrabBot.db" }).ToString();
            }


            //测试连通性
            if (ServerGlobal.db.Check())
            {
                Common.Tools.PrintLn("数据源连接检查成功，当前数据源类型：" + ServerGlobal.dbType, ConsoleColor.Green);
            }
            else
            {
                Common.Tools.PrintLn("无法连接到数据源或数据库操作出现异常，请检查服务器配置或目录权限！", ConsoleColor.Red);
                Console.ReadLine();
            }

            #endregion

            #region 注册系统机器人

            //注册一个系统机器人
            Model.Bot SysBot = new Model.Bot();
            SysBot.Class = Model.BotClass.System;
            SysBot.Status = Model.BotStatus.Online;
            SysBot.BotId = "system";
            SysBot.Name = "系统机器人";
            SysBot.Description = "系统机器人主要用于维护整个机器人系统，比如：注册用户、注册机器人、配置相关等。";
            ServerGlobal.RegisterBot(SysBot);

            #endregion
        }

        /// <summary>
        /// 持久化初始化方法
        /// </summary>
        public static void Persistence()
        {
            //启动计时器，延迟15秒启动，间隔为默认或自定义配置
            Timer timerClose = new Timer(PersistenceAction, null, 15 * 1000, ServerGlobal.persistenceTime * 1000);
            Common.Tools.PrintLn("持久化计时器已启动！", ConsoleColor.Green);
        }

        /// <summary>
        /// 持久化处理逻辑
        /// </summary>
        /// <param name="obj"></param>
        static void PersistenceAction(object obj)
        {
            Common.Tools.PrintLn(DateTime.Now.ToString() + "：【持久化】正在执行...");

            //持久化机器人信息


        }
    }
}
