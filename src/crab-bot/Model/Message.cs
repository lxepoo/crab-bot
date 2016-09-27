using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrabBot.Model
{
    /// <summary>
    /// 消息实体类
    /// </summary>
    public class Message
    {
        /// <summary>
        /// 私有临时变量，存储生成的请求ID
        /// </summary>
        protected string _RequestId="";

        /// <summary>
        /// [只读]请求ID
        /// </summary>
        public string RequestId
        {
            get {
                return this._RequestId == "" ? Common.Tools.GuidTo16String() : this._RequestId;
            }
        }

        /// <summary>
        /// 本次消息的请求目标
        /// 不可为空
        /// 格式类似  bot://botid/command
        /// </summary>
        public string RequestTarget { get; set; }

        /// <summary>
        /// 消息主体
        /// 可为空
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 消息发起人
        /// </summary>
        public User Sponsor { get; set; }


    }
}
