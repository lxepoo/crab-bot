<?php

namespace Crabbot\Center;

use Crabbot\Core\Object;
use Crabbot\Core\Message;
use Crabbot\Core\Result;
use \Exception;

class Application extends Object {

    /**
     * IP地址
     * @var string
     */
    public $ip = '127.0.0.1';

    /**
     * 通信（监听）端口
     * @var int
     */
    public $port = 12130;

    /**
     * TCP堆积量（并发等待量）
     * @var int
     */
    public $scale = 50;

    /**
     * 消息协调中心启动方法
     * @return null
     */
    public function run() {

        $this->hint('[bot server info]');
        $this->hint("address : {$this->ip}");
        $this->hint("listen port : {$this->port}");
        $this->hint("scale size : {$this->scale}");

        $this->hint('[bot server working]');

        //创建端口
        if (($sock = socket_create(AF_INET, SOCK_STREAM, SOL_TCP)) === false) {
            return false;
        }

        $this->hint('[hint] socket create success.');

        //绑定
        if (socket_bind($sock, $this->ip, $this->port) === false) {
            return false;
        }

        $this->hint('[hint] socket bind success.');

        //侦听端口
        if (socket_listen($sock, 50) === false) {
            return false;
        }

        $this->hint('[hint] server in listening...');

        $i = 0;
        while (true) {
            //实例化一个返回对象
            $result = new Result();

            //得到一个单次请求
            if (($msgsock = socket_accept($sock)) === false) {
                $this->hint("socket_accepty() failed :reason:" . socket_strerror(socket_last_error($sock)));
                break;
            }

            //读取发送过来的数据
            $this->hint('[' . date('Y-m-d H:i:s') . '] reading message...');
            $msg_buf = socket_read($msgsock, 8192);

            if (empty(trim($msg_buf))) {
                $this->hint('[error] message data is null...');
                continue;
            }

            try {
                $message = new Message(json_decode($msg_buf, true));
            } catch (Exception $exc) {
                //格式化出现异常时
                $this->hint('[error] ' . $exc->getMessage());
                $result->sessionid = null;
                $result->requestStatus = 'Error';
                $result->error = $exc->getMessage();
                $restr = json_encode($result->toArray());
                $this->hint("[result]\n" . $restr);

                if (false === socket_write($msgsock, $restr, strlen($restr))) {
                    $this->hint('[error] socket_write() failed reason:' . socket_strerror(socket_last_error($sock)));
                }

                $this->hint('[hint] result success!');
                socket_close($msgsock);
                continue;
            }

            //设置sessionid
            $result->sessionid = $message->sessionid;

            socket_close($msgsock);
        }

        //关闭socket
        socket_close($sock);
        $this->hint('[bot server end of work]');
    }

    /**
     * 打印字符串
     * @param type $str 需要输出的字符串
     */
    protected function hint($str) {
        echo "$str\n";
    }

}
