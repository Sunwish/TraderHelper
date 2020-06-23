# TraderHelper

TraderHelper 是一个开源的证券交易助手，在 TraderHelper 中将股票添加为自选股后，为其设置上破/下破预警价格，当达到触发价格时 TraderHelper 将会提醒您。程序中使用到的实时数据均来源于新浪股票。

An open source securities trading assistant that sets price warnings for different stocks. Real-time data comes from Sina.

Github: https://github.com/Sunwish/TraderHelper

![TraderHelper主界面](https://i.loli.net/2020/06/23/mZsnOSDqQ6fdlUw.png)

## 常见问题

Q: 如何获取 TraderHelper？

A: 进入本仓库的 Release 页面下载最新发布版，解压后双击目录中的 TraderHelper.exe 即可启动程序。

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