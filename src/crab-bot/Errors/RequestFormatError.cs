using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrabBot.Errors
{
    public class RequestFormatError : Error
    {
        /// <summary>
        /// 格式化请求错误
        /// </summary>
        public RequestFormatError()
        {
            this.ErrorCode = "0001";

            this.Content = "无法完成消息格式化解析，请检查所发送的内容是否符合规范！"; 
        }
    }
}
