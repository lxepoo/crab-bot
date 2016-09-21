<?php

namespace Crabbot\Core;

use \Exception;

class Result extends Object {

    /**
     * 会话ID
     * @var int 
     */
    public $sessionid;

    /**
     * 错误信息
     * @var string
     */
    public $error = null;

    /**
     * 返回内容体
     * @var mixed
     */
    public $body;

    /**
     * 请求状态
     * @var style
     */
    public $requestStatus;
}
