using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrabBot
{
    public class SocketThread : IDisposable
    {
        private Socket socket;
        private Thread thread;
        private string text;
        private int id;

        public SocketThread(Socket socket)
        {
            this.socket = socket;
            thread = new Thread(new ThreadStart(Work));
            thread.Start();
        }

        public void Work()
        {
            //获取线程ID
            this.id = Thread.CurrentThread.ManagedThreadId;

            //因为是循环使用，所以此处需要判断socket是否关闭
            Common.Tools.PrintLn("Thread" + this.id + "：开始获取数据流...");
            if (socket.Connected != true)
            {
                Common.Tools.PrintLn("Thread" + this.id + "：Socket连接已关闭，本线程结束...", ConsoleColor.Red);
                return;
            }

            //定义一个变量，存储客户端发来的信息
            string content = string.Empty;
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
            }

            Common.Tools.PrintLn("Thread" + this.id + "：包内数据读取完毕!");
            Common.Tools.PrintLn(content, ConsoleColor.Red);
            socket.Send(Encoding.UTF8.GetBytes("hello!你好世界"));

            //重复执行
            this.Work();
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
