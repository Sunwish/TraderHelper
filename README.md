# TraderHelper

TraderHelper 是一个开源的证券交易助手，在 TraderHelper 中将股票添加为自选股后，为其设置上破/下破预警价格，当达到触发价格时 TraderHelper 将会提醒您。程序中使用到的实时数据均来源于新浪股票。

An open source securities trading assistant that sets price warnings for different stocks. Real-time data comes from Sina.

Github: https://github.com/Sunwish/TraderHelper

![TraderHelper主界面](https://s2.loli.net/2022/07/20/YC8esvZNgpIV4nR.png)

## 常见问题

Q: 如何获取 TraderHelper？

A: 进入本仓库的 [Release](https://github.com/Sunwish/TraderHelper/releases) 页面下载最新发布版，解压后双击目录中的 TraderHelper.exe 即可启动程序。

----

Q: 如何添加自选股？

A: 在 **股票代码** 输入框中键入股票代码，然后点击 **添加到自选股** 即可。

----

Q: 如何删除自选股？

A: 在自选股列表中选中要删除的股票，然后点击 **从自选股移除**，在弹出的询问框中选择 **是 (Y)** 即可。

----

Q: 如何为股票设置/修改预警价格？

A: 首先将目标股票添加到自选股，在自选股列表中选中目标股票，然后在自选股列表右侧对其预警价格进行配置，最后点击 **确认设置** 即可。

----

Q: 如何停止已触发的预警？

A: 已触发的预警在主界面的自选股列表中将会标红/标绿显示，将对应的触发价格清空或设置一个新的合法预警价即可停止预警。

----

Q: 如何更换预警提示音？

A: TraderHelper 支持自定义.wav格式的波形文件作为预警提示音，只需把要使用的标准.wav波形文件更名为 **warning.wav**，然后将其拷贝到 TraderHelper 的根目录下，替换掉原有的 warning.wav 即可。

------------------

Q: 微信提醒有什么用？

A: 微信提醒可于出门在外等不方便呆在 TraderHelper 旁时开启，完成简单配置并开启后只需保持程序联网运行，即可在电脑上触发价格提醒的同时向所绑定的微信发送提醒推送。

----------------

Q: 如何开启微信提醒？

A: 首先前往 Server酱（[http://sc.ftqq.com/](http://sc.ftqq.com/)）并用您的 Github 帐号登录 Server酱，然后点进 Server酱 顶部的 **微信推送** 页面，用微信扫码关注用于消息推送的公众号，并在页面中确认绑定，接下来进入 Server酱 的 **发送消息** 页面，将 SCKEY 码拷贝至 TraderHelper 目录下的 **serverChan.ini** 配置文件中，最后在 TraderHelper 主界面中勾选 **微信提醒** 即可。

（首次配置时只需在程序中直接勾选 [微信提醒]，即可自动弹出配置文件）

-----------------

Q: 什么是 PushDeer 提醒？以及如何开启 PushDeer 提醒？

A: [PushDeer](https://github.com/easychen/pushdeer) 是一个开源的无 APP 推送解决方案。由于 TraderHelper 自身没有手机端 APP，因此借助 PushDeer 实现在无 APP 条件下向你推送股票价格预警信息。

要开启 PushDeer 提醒，请前往 App Store 下载 [PushDeer·自架版]，或扫描下面的 App Clip，然后在 `API 服务的 endpoint url` 输入框中输入 `http://notify.houkaifa.com ` 并点击保存按钮。绑定设备之后，在 KEY 页面将你的 KEY 值复制到 TraderHelper 目录下的 **pushdeer.ini** 配置文件中，最后在 TraderHelper 主界面勾选 **pushdeer** 即可。

（首次配置时只需在程序中直接勾选 [pushdeer]，即可自动弹出配置文件及轻应用码）

> :warning:**注意，扫码使用轻应用只是方便临时试用，若连续 30 天内未再次使用将被 iOS 自动清理，届时将需要重新扫码绑定设备，因此强烈建议前往 App Store 下载 [PushDeer·自架版]，然后在完整应用内绑定设备与获取 KEY！**
>
> :question:正在寻找 PushDeer 安卓版？请[前往此处](https://github.com/easychen/pushdeer/releases)下载。

![pushdeer 自架版 轻应用版](https://github.com/easychen/pushdeer/raw/main/doc/image/2022-02-02-21-45-29.png)

--------------

Q: PushDeer 提醒与微信提醒有什么区别？

A: 微信提醒是借助微信公众号推送提醒，无法与其他日常微信消息区分开来，辨识度较低，同时，微信提醒无法直接看到预警信息，必须在收到提醒后打开微信，进入公众号聊天界面，才能查看到具体的预警信息。而 PushDeer 作为移动端的独立 APP，其通知辨识度更高，并且预警信息可以做到直接显示，不需要进入任何软件，预警信息即通知即看到，方便快捷。

