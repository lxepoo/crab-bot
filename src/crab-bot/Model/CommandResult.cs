using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrabBot.Model
{
    /// <summary>
    /// 命令返回结果实体类
    /// </summary>
    /// <typeparam name="T">返回数据的真实类型</typeparam>
    public class CommandResult<T>
    {

        /// <summary>
        /// 返回数据
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 返回时间
        /// </summary>
        public string CreateAt {
            get
            {
                return DateTime.Now.ToString("yyyy-MM-dd HH:mm:s");
            }
        }
    }
}
