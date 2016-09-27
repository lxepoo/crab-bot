using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrabBot
{
    public class Router
    {

        //protected object 


        private Model.Message message;

        /// <summary>
        /// 构造函数
        /// </summary>
        public Router(Model.Message _message)
        {
            this.message = _message;
        }

        /// <summary>
        /// 解析请求
        /// </summary>
        private bool TargetAnalytic()
        {
            //先判断格式是否正确
            if(!Regex.IsMatch(this.message.RequestTarget, "bot://(.*)"))
            {
                return false;
            }

            //开始拆解，先去掉协议前缀
            string target = this.message.RequestTarget.Substring(6);

            //拆分为数组，下标：0 botid，1 cmd
            string[] path = target.Split('/');

            if (path.Length != 2)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 执行请求（触发路由）
        /// </summary>
        /// <returns></returns>
        public object Execute()
        {
            return null;
        }
    }
}