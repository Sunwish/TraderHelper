# TraderHelper

TraderHelper 是一个开源的证券交易助手，在 TraderHelper 中将股票添加为自选股后，为其设置上破/下破预警价格，当达到触发价格时 TraderHelper 将会提醒您。程序中使用到的实时数据均来源于新浪股票。

An open source securities trading assistant that sets price warnings for different stocks. Real-time data comes from Sina.

Github: https://github.com/Sunwish/TraderHelper

## 常见问题

Q: 如何启动 TraderHelper？

A: 你可以使用 Visual Studio 打开根目录下的解决方案 **TraderHelper.sln**，手动编译一个 TraderHelper 的发布版本运行使用，也可以直接打开根目录下 **Release_TH** 目录中的 **TraderHelper.exe** 来启动已编译好的发行版本。

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