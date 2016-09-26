using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrabBot.Common
{
    public class SocketThread : IDisposable
    {
        private Socket socket;
        private Thread thread;
        private string text;

        public SocketThread(Socket socket)
        {
            this.socket = socket;
            thread = new Thread(new ThreadStart(Work));
            thread.Start();
        }

        public void Work()
        {
            //定义一个变量，存储客户端发来的信息
            string content = string.Empty;

            Common.Tools.PrintLn("开始读取包内数据...");
            socket.ReceiveBufferSize = 4096;
            byte[] buffer = new byte[4096];
            while (true)
            {
                int receivedLength = socket.Receive(buffer);
                text = System.Text.Encoding.UTF8.GetString(buffer, 0, receivedLength);
                content = content + text;

                //如果此次包内无数据或长度小于一个包的长度则结束循环
                if (text == "" || receivedLength < socket.ReceiveBufferSize)
                {
                    break;
                }

                

                //<EOF>是自定义的协议，表示中止消息交流，适用于取消发送消息之类的 
                //if (text.IndexOf("<EOF>") > -1)
                ////if (receivedLength == 0)
                //{
                //    isListening = false;
                //    socket.Send(new byte[] { 0 });
                //}
                //else
                //{
                //    //Console.WriteLine("接收到的数据：" + text);  
                //    //根据客户端的请求获取相应的响应信息  
                //    string message = GetMessage(text);
                //    //将响应信息以字节的方式发送到客户端  
                //    //socket.Send(Encoding.UTF8.GetBytes(message));
                //}
            }

            Common.Tools.PrintLn("包内数据读取完毕!");
            Common.Tools.PrintLn(content, ConsoleColor.Red);
            socket.Send(new byte[] { 0 });
        }
        
        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            if (thread != null)
            {
                thread = null;
            }
            if (socket != null)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Dispose();
            }
        }
    }
}
