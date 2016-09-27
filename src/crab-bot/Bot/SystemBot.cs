using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrabBot.Bot
{
    public class SystemBot : BotInterface
    {
        public string Hello()
        {
            return "你好，我是自带的机器人，主要用于系统级维护。";
        }
    }
}
