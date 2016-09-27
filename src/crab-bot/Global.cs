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
        public static Dictionary<string, Model.Bot> bots = new Dictionary<string, Model.Bot>();

        /// <summary>
        /// 所有用户的集合
        /// </summary>
        public static Dictionary<string, Model.User> users = new Dictionary<string, Model.User>();


        /// <summary>
        /// 注册机器人到集合中
        /// </summary>
        /// <param name="bot"></param>
        public static void RegisterBot(Model.Bot bot)
        {
            //判断是否存在同名的机器人，有则覆盖
            if (Global.bots.Keys.Contains(bot.BotId))
            {
                Global.bots[bot.BotId] = bot;
            }
            else
            {
                //如果没有，就添加到集合
                Global.bots.Add(bot.BotId, bot);
            }
        }

        public static void RegisterUser(Model.User user)
        {
            //判断是否存在同名的用户，有则覆盖
            if (Global.users.Keys.Contains(user.Uid))
            {
                Global.users[user.Uid] = user;
            }
            else
            {
                //如果没有，就添加到集合
                Global.users.Add(user.Uid, user);
            }
        }
    }
}
