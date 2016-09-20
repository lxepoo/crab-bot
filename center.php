<?php

error_reporting(E_ALL | E_STRICT);

defined('CBOT_DEBUG') or define('CBOT_DEBUG', true);
defined('CBOT_IP') or define('CBOT_IP', '127.0.0.1');
defined('CBOT_PORT') or define('CBOT_PORT', 12130);

require(__DIR__ . '/vendor/autoload.php');

\Crabbot\Center\Application::run();