using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrabBot.Errors
{
    public class Error : System.Exception
    {
        /// <summary>
        /// 错误代码
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// 错误内容
        /// </summary>
        protected string Content { get; set; }

        /// <summary>
        /// 重写message方法,以让它显示相应异常提示信息
        /// </summary>
        public override string Message
        {
            get
            {
                //根据异常类型从message.xml中读取相应异常提示信息
                return this.Content;
            }
        }
    }
}
