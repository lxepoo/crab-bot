<?php

error_reporting(E_ALL | E_STRICT);

defined('CBOT_DEBUG') or define('CBOT_DEBUG', true);

require(__DIR__ . '/vendor/autoload.php');

$server = new \Crabbot\Center\Application([
    'ip' => '127.0.0.1',
    'port' => 8989
        ]);

$server->run();
