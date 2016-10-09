﻿using System;
using System.Collections.Generic;
using CrabBot.Model;

namespace CrabBot.Bots
{
    public class SystemBot : BotInterface
    {

        /// <summary>
        /// 系统自带机器人
        /// </summary>
        public SystemBot(){}

        /// <summary>
        /// 打招呼，自我介绍
        /// </summary>
        /// <returns></returns>
        public CommandResult<string> Hello()
        {
            return new CommandResult<string>() { Data = "你好，我是自带的机器人，主要用于系统级维护。" };
        }

        /// <summary>
        /// 获取所有的命令集合
        /// </summary>
        /// <returns></returns>
        public CommandResult<Dictionary<string, string>> CommandList()
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
            list.Add("Hello", "自我介绍");
            list.Add("CommandList", "获取所有命令");
            list.Add("GetBots", "获取所有机器人");
            return new CommandResult<Dictionary<string, string>> { Data = list };
        }

        /// <summary>
        /// 获取所有的机器人列表
        /// </summary>
        /// <returns></returns>
        public object GetBots()
        {
            return ServerGlobal.bots;
        }
    }
}
