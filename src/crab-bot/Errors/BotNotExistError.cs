using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrabBot.Errors
{
    public class BotNotExistError : Error
    {
        /// <summary>
        /// 机器人不存在错误
        /// </summary>
        /// <param name="botid">机器人ID</param>
        public BotNotExistError(string botid)
        {
            this.ErrorCode = "0003";

            this.Content = "所请求的机器人不存在：" + botid + "，请重试！";
        }
    }
}
