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
        /// 机器人类型
        /// </summary>
        public BotClass Class { get; set; }

        /// <summary>
        /// 机器人类型
        /// </summary>
        public BotStatus Status { get; set; }

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
        /// 配置
        /// </summary>
        public string Config { get; set; }

        /// <summary>
        /// 私有化存储机器人功能实例
        /// </summary>
        private object _Instance { get; set; }

        /// <summary>
        /// 获取具体的机器人功能实例
        /// </summary>
        /// <returns></returns>
        public object Instance()
        {
            //如果已经实例化过，就返回旧对象
            if(this._Instance != null)
            {
                return this._Instance;
            }

            switch (this.Class)
            {
                case BotClass.System:
                    this._Instance = new Bots.SystemBot();
                    break;
                case BotClass.Chat:
                    this._Instance = new Bots.ChatBot(this.Config);
                    break;
                case BotClass.Custom:
                    this._Instance = new Bots.CustomBot(this.Config);
                    break;
            }

            //返回对象
            return this._Instance;
        }
    }

    /// <summary>
    /// 分类枚举值
    /// </summary>
    public enum BotClass
    {
        /// <summary>
        /// 系统自带机器人
        /// </summary>
        System = 0,

        /// <summary>
        /// 聊天机器人
        /// </summary>
        Chat = 1,

        /// <summary>
        /// 自定义机器人
        /// </summary>
        Custom = 2
    };

    /// <summary>
    /// 状态枚举值
    /// </summary>
    public enum BotStatus
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
