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
        string Hello();
    }
}
