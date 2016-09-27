using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrabBot.Model
{
    public class User
    {
        /// <summary>
        /// 用户编号（唯一）
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public enum Status
        {
            /// <summary>
            /// 禁用
            /// </summary>
            Disable = -1,

            /// <summary>
            /// 离线
            /// </summary>
            Offline = 0,

            /// <summary>
            /// 在线
            /// </summary>
            Online = 1
        };
    }
}
