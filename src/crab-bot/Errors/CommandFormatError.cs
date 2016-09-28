using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrabBot.Errors
{

    public class CommandFormatError : Error
    {
        /// <summary>
        /// 解析命令错误
        /// </summary>
        public CommandFormatError()
        {
            this.ErrorCode = "0002";

            this.Content = "无法解析所请求的命令，请检查所发送的请求是否符合规范！";
        }
    }
}
