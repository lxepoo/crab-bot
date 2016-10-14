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
        /// 构造函数
        /// </summary>
        public Result()
        {
            //处理默认值
            this.Body = new Dictionary<string, object>();
            this.RequestState = false;
        }

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
        /// 字典类型
        /// </summary>
        public Dictionary<string, object> Body { get; set; }

        /// <summary>
        /// 消息发起人
        /// </summary>
        public User Sponsor { get; set; }


    }
}
