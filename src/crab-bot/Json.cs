using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrabBot
{
    /// <summary>
    /// 解析JSON相关操作类
    /// </summary>
    /// <typeparam name="T">实体类</typeparam>
    public static class Json<T>
    {
        /// <summary>
        /// 将json字符串转换为对象
        /// </summary>
        /// <param name="json">json字符串</param>
        /// <returns></returns>
        public static T JsonDecode(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// 将对象转换为json字符串
        /// </summary>
        /// <param name="data">对象数据</param>
        /// <returns></returns>
        public static string JsonEncode(T data)
        {
            var json = JObject.FromObject(data);
            return json.ToString();

        }
    }
}
