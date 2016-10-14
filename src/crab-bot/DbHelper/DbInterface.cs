using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace CrabBot
{
    interface DbInterface
    {

        /// <summary>
        /// 检查数据库相关配置及测试
        /// </summary>
        /// <returns></returns>
        bool Check();

        /// <summary>
        /// 持久化所有机器人信息至数据库
        /// </summary>
        /// <returns></returns>
        bool BotsPersistence();

        /// <summary>
        /// 持久化所有用户信息至数据库
        /// </summary>
        /// <returns></returns>
        bool UserPersistence();

        /// <summary>
        /// 记录控制台输出
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        bool CreateConsoleLog(string content);

        /// <summary>
        /// 记录消息到数据库
        /// </summary>
        /// <param name="message">消息对象</param>
        /// <param name="socket">socket连接</param>
        /// <returns></returns>
        bool CreateMessageLog(Model.Message message,Socket socket);

    }
}
