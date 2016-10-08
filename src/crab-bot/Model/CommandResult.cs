using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrabBot.Model
{
    /// <summary>
    /// 命令返回结果实体类
    /// </summary>
    public class CommandResult
    {

        /// <summary>
        /// 消息主体
        /// 可为空
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CreateAt {
            get
            {
                return DateTime.Now.ToString("yyyy-MM-dd HH:mm:s");
            }
        }
    }
}
