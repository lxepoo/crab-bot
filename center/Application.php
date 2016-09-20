<?php

namespace Crabbot\Center;

use Crabbot\Core\Object;

class Application extends Object {

    public static function run() {

        //创建端口
        if (($sock = socket_create(AF_INET, SOCK_STREAM, SOL_TCP)) === false) {
            return false;
        }

        //绑定
        if (socket_bind($sock, CBOT_IP, CBOT_PORT) === false) {
            return false;
        }

        //侦听端口
        if (socket_listen($sock, 50) === false) {
            return false;
        }

        while (true) {
            
            //得到一个请求
            if (($msgsock = socket_accept($sock)) === false) {
                echo "socket_accepty() failed :reason:" . socket_strerror(socket_last_error($sock)) . "\n";
                break;
            }
            
            //向客户端发送消息
            $msg = "<font color='red'>server send:欢饮欢迎</font><br/>";
            socket_write($msgsock, $msg, strlen($msg));
            echo "read client message\n";
            
            //读取发送过来的数据
            $buf = socket_read($msgsock, 8192);
            $talkback = "received message:$buf\n";
            echo $talkback;
            if (false === socket_write($msgsock, $talkback, strlen($talkback))) {
                echo "socket_write() failed reason:" . socket_strerror(socket_last_error($sock)) . "\n";
            } else {
                echo 'send success';
            }
            socket_close($msgsock);
        }

        //关闭socket
        socket_close($sock);
    }

}
