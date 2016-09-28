﻿using System;
using System.Collections.Generic;
using System.Linq;

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
        public string Hello()
        {
            return "你好，我是自带的机器人，主要用于系统级维护。";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> CommandList()
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
            list.Add("Hello", "自我介绍");
            list.Add("CommandList", "获取所有命令");
            list.Add("GetBots", "获取所有机器人");
            return list;
        }

        /// <summary>
        /// 获取所有的机器人列表
        /// </summary>
        /// <returns></returns>
        public object GetBots()
        {
            return Global.bots;
        }
    }
}
