using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrabBot.Model
{
    public class Bot
    {
        /// <summary>
        /// 机器人ID
        /// </summary>
        public string BotId { get; set; }

        /// <summary>
        /// 机器人名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 通信秘钥
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public enum Status
        {
            /// <summary>
            /// 故障
            /// </summary>
            Error = -1,

            /// <summary>
            /// 离线
            /// </summary>
            Offline = 0,

            /// <summary>
            /// 在线
            /// </summary>
            Online = 1,

            /// <summary>
            /// 繁忙
            /// </summary>
            Busy = 2
        };
    }
}
