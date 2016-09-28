using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrabBot.Errors
{

    public class CommandNotExistError : Error
    {
        /// <summary>
        /// 命令不存在错误
        /// </summary>
        /// <param name="command">命令</param>
        public CommandNotExistError(string command)
        {
            this.ErrorCode = "0004";

            this.Content = "所请求的机器人不包含此命令：" + command + "，请重试！"; ;
        }
    }
}
