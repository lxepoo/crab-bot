using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrabBot
{
    interface BotInterface
    {
        /// <summary>
        /// 打招呼，用于输出一些简介之类的东西，通常客户端会自动请求这个命令
        /// </summary>
        Model.CommandResult<string> Hello();

        /// <summary>
        /// 返回此机器人所有的命令集合
        /// </summary>
        /// <returns>返回一个字典</returns>
        Model.CommandResult<Dictionary<string, string>> CommandList();
    }
}
