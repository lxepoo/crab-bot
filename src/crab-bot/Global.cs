using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrabBot
{
    public class Global
    {
        /// <summary>
        /// 所有机器人的集合
        /// </summary>
        public static List<Model.Bot> bots = new List<Model.Bot>();

        /// <summary>
        /// 所有用户的集合
        /// </summary>
        public static List<Model.User> users = new List<Model.User>();


        /// <summary>
        /// 注册机器人到集合中
        /// </summary>
        /// <param name="bot"></param>
        public static void RegisterBot(Model.Bot bot)
        {
            //判断集合里是否有同名机器人，如果有先删掉
            if (Global.bots.Exists(delegate (Model.Bot t) { return t.BotId == bot.BotId; }))
            {
                var temp = Global.bots.Find(delegate (Model.Bot t) { return t.BotId == bot.BotId; });
                Global.bots.Remove(temp);
            }

            //添加机器人实例到集合
            Global.bots.Add(bot);
        }

        public static void RegisterUser(Model.User user)
        {
            //判断集合里是否有同UID用户，如果有先删掉
            if (Global.users.Exists(delegate (Model.User t) { return t.Uid == user.Uid; }))
            {
                var temp = Global.users.Find(delegate (Model.User t) { return t.Uid == user.Uid; });
                Global.users.Remove(temp);
            }

            //添加用户实例到集合
            Global.users.Add(user);
        }
    }
}
