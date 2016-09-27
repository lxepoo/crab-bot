using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrabBot.Model
{
    /// <summary>
    /// 返回结果实体类
    /// </summary>
    public class Result
    {

        /// <summary>
        /// 请求ID
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// 本次消息的请求目标
        /// </summary>
        public string RequestTarget { get; set; }

        /// <summary>
        /// 请求状态
        /// </summary>
        public bool RequestState { get; set; }

        /// <summary>
        /// 消息主体
        /// 可为空
        /// </summary>
        public object Body { get; set; }

        /// <summary>
        /// 消息发起人
        /// </summary>
        public User Sponsor { get; set; }


    }
}
