using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Data.Sqlite;

namespace CrabBot
{
    public class ServerGlobal
    {
        /// <summary>
        /// 是否调试模式
        /// </summary>
        public static bool debug = false;

        /// <summary>
        /// 持久化时间间隔（秒）
        /// 默认是300秒持久化一次
        /// </summary>
        public static int persistenceTime = 50000;

        /// <summary>
        /// 数据库类型
        /// 有需要可以扩展出其他数据库类型，只需要实现DbInterface接口即可
        /// </summary>
        public static string dbType = "SQLite";

        /// <summary>
        /// 数据库操作对象
        /// </summary>
        //public static DbInterface db = null;

        private static DbInterface _db = null;

        public static DbInterface db
        {
            get
            {
                if (_db == null)
                {
                    switch (dbType)
                    {
                        case "SQLite":
                            _db = new DbHelper.SQLite();
                            break;
                    }
                }

                return _db;
            }
            set { _db = value; }
        }


        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static string connStr = null;

        /// <summary>
        /// IP地址
        /// 例如：127.0.0.1，默认0.0.0.0
        /// </summary>
        public static IPAddress ip = IPAddress.Parse("0.0.0.0");

        /// <summary>
        /// 监听端口
        /// 强制规定，端口必须大于3000，小于65530，默认8989
        /// </summary>
        public static int port = 8989;

        /// <summary>
        /// 所有机器人的集合
        /// </summary>
        public static Dictionary<string, Model.Bot> bots = new Dictionary<string, Model.Bot>();

        /// <summary>
        /// 所有用户的集合
        /// </summary>
        public static Dictionary<string, Model.User> users = new Dictionary<string, Model.User>();

        /// <summary>
        /// 注册机器人到集合中
        /// </summary>
        /// <param name="bot"></param>
        public static bool RegisterBot(Model.Bot bot)
        {
            //判断是否存在同名的机器人，有则覆盖
            if (ServerGlobal.bots.Keys.Contains(bot.BotId))
            {
                ServerGlobal.bots[bot.BotId] = bot;
            }
            else
            {
                //如果没有，就添加到集合
                ServerGlobal.bots.Add(bot.BotId, bot);
            }

            //覆写数据库记录
            using (var conn = new SqliteConnection(ServerGlobal.connStr))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    //无法连接到数据库，则报错并停止程序
                    throw new Errors.DbError(ex.Message);
                }
            }

            return true;

        }

        public static void RegisterUser(Model.User user)
        {
            //判断是否存在同名的用户，有则覆盖
            if (ServerGlobal.users.Keys.Contains(user.Uid))
            {
                ServerGlobal.users[user.Uid] = user;
            }
            else
            {
                //如果没有，就添加到集合
                ServerGlobal.users.Add(user.Uid, user);
            }
        }

        /// <summary>
        /// 解析命令行启动参数
        /// </summary>
        /// <param name="args"></param>
        public static void ArgsFormat(string[] args)
        {
            if(args.Length ==0)
            {
                return;
            }

            foreach(string arg in args)
            {
                string[] temp = arg.Split('=');
                if (temp.Length != 2)
                {
                    //如果不是K=V成对出现，则跳过此次判断
                    continue;
                }

                //判断是否开启DEBUG模式
                if(temp[0].ToLower()=="debug" && temp[1] == "1")
                {
                    ServerGlobal.debug = true;
                }

                //判断是否使用自定义IP
                if (temp[0].ToLower() == "ip" && Common.Tools.IsValidIP(temp[1]))
                {
                    ServerGlobal.ip = IPAddress.Parse(temp[1]);
                }

                //判断是否使用自定义端口号
                if (temp[0].ToLower() == "port" && Common.Tools.IsPort(temp[1]))
                {
                    ServerGlobal.port = int.Parse(temp[1]);
                }

                //自定义持久化时间
                if (temp[0].ToLower() == "persistencetime" && Common.Tools.IsNumber(temp[1]))
                {
                    int time = int.Parse(temp[1]);

                    //间隔时间小于1分钟，或大于60分钟，视为无效
                    if (time >= 60 && time <= 3600)
                    {
                        ServerGlobal.persistenceTime = time;
                    }
                }
            }
        }
    }
}
