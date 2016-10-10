using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrabBot.Errors
{

    public class MethodNotExistError : Error
    {
        /// <summary>
        /// 方法不存在错误
        /// </summary>
        /// <param name="method">方法名</param>
        public MethodNotExistError(string method)
        {
            this.ErrorCode = "0006";

            this.Content = "无法找到指定方法：" + method + "，请重试！";
        }
    }
}
