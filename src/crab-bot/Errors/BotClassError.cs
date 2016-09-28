using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrabBot.Errors
{
    public class BotClassError : Error
    {
        /// <summary>
        /// 机器人类型不正确
        /// </summary>
        /// <param name="botid">机器人ID</param>
        public BotClassError(string botid)
        {
            this.ErrorCode = "0005";

            this.Content = "所请求的机器人类型不正确！机器人ID：" + botid + "，请重试！";
        }
    }
}
