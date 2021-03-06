﻿using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Reflection;

namespace CrabBot
{
    public class Router
    {
        /// <summary>
        /// 请求消息
        /// </summary>
        private Model.Message message;

        /// <summary>
        /// 请求的机器人ID
        /// </summary>
        private string BotId;

        /// <summary>
        /// 请求的命令
        /// </summary>
        private string Command;

        /// <summary>
        /// 机器人实例
        /// </summary>
        private object BotInstance;

        /// <summary>
        /// 构造函数
        /// </summary>
        public Router(Model.Message _message)
        {
            this.message = _message;
        }
        

        /// <summary>
        /// 解析请求
        /// </summary>
        private bool TargetAnalytic()
        {
            //先判断格式是否正确
            if(!Regex.IsMatch(this.message.RequestTarget, "bot://(.*)"))
            {
                return false;
            }

            //开始拆解，先去掉协议前缀
            string target = this.message.RequestTarget.Substring(6);

            //拆分为数组，下标：0 botid，1 cmd
            string[] path = target.Split('/');

            if (path.Length != 2)
            {
                return false;
            }

            //将解析好的路由赋值
            this.BotId = path[0];
            this.Command = path[1];

            return true;
        }

        /// <summary>
        /// 执行请求（触发路由）
        /// </summary>
        /// <returns></returns>
        public object Execute()
        {
            //先解析一下请求
            if (!this.TargetAnalytic())
            {
                return new Errors.CommandFormatError();
            }

            //检查所请求的机器人是否存在
            if (!ServerGlobal.bots.Keys.Contains(this.BotId))
            {
                return new Errors.BotNotExistError(this.BotId);
            }

            //获取机器人功能对象
            this.BotInstance = ServerGlobal.bots[this.BotId].Instance();

            switch (ServerGlobal.bots[this.BotId].Class)
            {
                case Model.BotClass.System:
                    return RunSystemBot();
                case Model.BotClass.Chat:
                    return RunSystemBot();
                case Model.BotClass.Custom:
                    return RunSystemBot();
                default:
                    return new Errors.BotClassError(this.BotId);
            }
        }

        /// <summary>
        /// 系统机器人处理流程
        /// </summary>
        /// <returns></returns>
        public object RunSystemBot()
        {

            var bot = this.BotInstance as Bots.SystemBot;

            //检查命令是否存在于命令列表中
            if (!bot.commands().Data.Keys.Contains(this.Command))
            {
                return new Errors.CommandNotExistError(this.Command);
            }

            Type t = bot.GetType();
            MethodInfo method = t.GetMethod(this.Command);

            //检查代码中是否包含此方法
            if (method == null)
            {
                return new Errors.MethodNotExistError(this.Command);
            }

            //通过反射的方式执行命令（方法），分为有参和无参，所有机器人命令方法可以没有参数，如果有，只能为Model.Message类
            if(method.GetParameters().Length >0)
            {
                object[] parameters = new object[1];
                parameters[0] = (object)this.message;
                return method.Invoke(bot, parameters);
            }
            else
            {
                return method.Invoke(bot, null);
            }
        }
    }
}