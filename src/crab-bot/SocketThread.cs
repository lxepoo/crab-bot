﻿using System;
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


            //开始处理并返回
            Model.Result result = new Model.Result();
            Model.Message message = new Model.Message();

            try
            {
                //解析本次的消息
                message = Json<Model.Message>.JsonDecode(content);
                result.RequestId = message.RequestId;
                result.RequestTarget = message.RequestTarget;
                result.Sponsor = message.Sponsor;

                //触发路由


            }
            catch
            {
                result.RequestId = message.RequestId;

                //设置返回状态为False
                result.RequestState = false;

                //构建一个错误返回
                result.Body = new Model.Error() { ErrorCode = "0001", Content = "无法完成消息格式化解析，请检查所发送的内容是否符合规范！" };               
            }

            //发送一个返回
            socket.Send(Encoding.UTF8.GetBytes(Json<Model.Result>.JsonEncode(result)));

            //重复执行
            this.Work();
        }
        
        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            //关闭连接
            if (socket != null)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Dispose();
            }

            //置空线程
            if (thread != null)
            {
                thread = null;
            }
        }
    }
}