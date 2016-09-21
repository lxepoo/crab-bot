<?php

namespace Crabbot\Core;

use \Exception;

class Message extends Object {

    /**
     * 会话ID
     * @var int 
     */
    public $sessionid;

    /**
     * 消息发送者
     * @var hash
     */
    public $sender;

    /**
     * 消息收听者
     * @var hash
     */
    public $lister;

    /**
     * 消息路由
     * @var array
     */
    public $router;

    /**
     * 消息内容体
     * @var mixed
     */
    public $body;

    public function init() {
        //检查一下基本信息是否健全
        if (!$this->checkFormat()) {
            throw new Exception('message format error!');
        }
    }

    /**
     * 检查属性值是否符合要求
     */
    protected function checkFormat() {
        //只检查主要信息，body不检查，因为body可能本身就是空的
        if ($this->sessionid && $this->lister && $this->sender && $this->router) {
            return true;
        }
        return false;
    }

}
