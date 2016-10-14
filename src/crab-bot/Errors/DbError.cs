using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrabBot.Errors
{
    public class DbError : Error
    {
        /// <summary>
        /// 数据库错误
        /// </summary>
        /// <param name="msg">数据库错误提示</param>
        public DbError(string msg)
        {
            this.ErrorCode = "0007";

            this.Content = "进行数据库操作时遇到错误：" + msg + "！";
        }
    }
}
