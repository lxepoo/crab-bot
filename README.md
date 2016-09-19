#螃蟹机器人

主体使用PHP开发，至少需要PHP 5.5及以上版本。


工作分为3个部分：

[crab-bot-sender]：消息发送者，一个前端应用，用户通过此应用发起会话、消息、获取反馈等。

[crab-bot-center]：消息协调中心，主要用于对消息进行存储、调用路由、反馈消息。

[crab-bot-router]：消息路由器，用于对消息进行多元化处理，转发到指定的收听者进行处理。

[crab-bot-listener]：消息收听者，用于处理各种消息，可以自定义。

#Crab Droid

Subject to the use of PHP development, at least the need for PHP 5.5 and above versions.

Work is divided into 3 parts:

[crab-bot-sender]: a message sender, a front-end application, the user through this application to initiate conversations, messages, get feedback, etc..

[crab-bot-center]: Message coordination center, which is mainly used to store information, call routing, feedback message.

[crab-bot-router]: message router, used to carry out the diversification of the message processing, forward to the designated listener for processing.

[crab-bot-listener]: a message listener for handling all kinds of messages.
