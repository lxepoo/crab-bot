﻿using System;
using System.Collections.Generic;
using CrabBot.Model;

namespace CrabBot.Bots
{
    public class CustomBot : BotInterface
    {
        /// <summary>
        /// 自定义机器人
        /// </summary>
        /// <param name="config">机器人配置（JSON字符串）</param>
        public CustomBot(string config = null)
        {

        }


        /// <summary>
        /// 打招呼，自我介绍
        /// </summary>
        /// <returns></returns>
        public CommandResult<string> hello()
        {
            return new CommandResult<string>() { Data = "你好，我是自带的机器人，主要用于系统级维护。" };
        }

        /// <summary>
        /// 获取所有的命令集合
        /// </summary>
        /// <returns></returns>
        public CommandResult<Dictionary<string, string>> commands()
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
            list.Add("Hello", "自我介绍");
            list.Add("CommandList", "获取所有命令");
            list.Add("GetBots", "获取所有机器人");
            return new CommandResult<Dictionary<string, string>> { Data = list };
        }
    }
}
