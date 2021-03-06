﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraderHelper
{
    class Share
    {
        public ShareData shareData;
        public ShareInfo shareInfo;

        // 私有构造
        private Share() { }

        // 构造函数
        public Share(ShareInfo shareInfo, ShareData shareData)
        {
            this.shareInfo = shareInfo;
            this.shareData = shareData;
        }

        // 从shareInfo静态创建一个Share实例
        public static Share CreateFromShareInfo(ShareInfo shareInfo)
        {
            Share share = new Share();
            share.shareInfo = ShareInfo.Build(shareInfo);
            share.shareData = GetShareDataFromShareInfo(shareInfo);

            return share;
        }

        // 从shareInfo静态创建一个Share实例
        public static Share CreateFromShareInfo(string shareUrlHeader, string shareUrlType, string shareUrlCode)
        {
            Share share = new Share();
            share.shareInfo = ShareInfo.Build(shareUrlHeader, shareUrlType, shareUrlCode);
            share.shareData = GetShareDataFromShareInfo(share.shareInfo);

            return share;
        }

        // 从指定shareInfo获取最新shareData
        private static ShareData GetShareDataFromShareInfo(ShareInfo shareInfo)
        {
            // 获取http响应
            string requestURL = MakeShareResponseURL(shareInfo.shareUrlHeader, shareInfo.shareUrlType, shareInfo.shareUrlCode);
            string httpResponse = Helper.HttpResponse(requestURL, "GB2312");

            // 取响应流有效信息
            string reg1 = Helper.Regexer(@"(?<=.+=.).+(?=,)", httpResponse);
            string[] shareParams = reg1.Split(',');
            ShareData shareData = new TraderHelper.ShareData(shareParams);

            if (shareParams.Length == 1) // 获取信息为空
                throw new SystemException("[Exception] UpdateShareDataFromShareInfo: 信息获取错误;");

            return shareData;
        }

        // 从自身shareInfo获取最新ShareData
        private ShareData GetShareDataFromShareInfo()
        {
            return GetShareDataFromShareInfo(this.shareInfo);
        }

        // 组合请求URL
        private static string MakeShareResponseURL(string urlHeader, string shareType, string shareCode)
        {
            return urlHeader + shareType + shareCode;
        }
    }

    class ShareInfo
    {
        public string shareUrlHeader;
        public string shareUrlType;
        public string shareUrlCode;

        // 构造函数
        public ShareInfo(string shareUrlHeader, string shareUrlType, string shareUrlCode)
        {
            this.shareUrlHeader = shareUrlHeader;
            this.shareUrlType = shareUrlType;
            this.shareUrlCode = shareUrlCode;
        }

        // 构造函数
        public ShareInfo(ShareInfo shareInfo)
        {
            this.shareUrlHeader = shareInfo.shareUrlHeader;
            this.shareUrlType = shareInfo.shareUrlType;
            this.shareUrlCode = shareInfo.shareUrlCode;
        }

        // 静态构建 ShareInfo
        public static ShareInfo Build(string shareUrlHeader, string shareUrlType, string shareUrlCode)
        {
            return new ShareInfo(shareUrlHeader, shareUrlType, shareUrlCode);
        }

        // 静态构建 ShareInfo
        public static ShareInfo Build(ShareInfo shareInfo)
        {
            return new ShareInfo(shareInfo);
        }

    }

    class ShareData
    {
        public string shareName; // 股票名称
        public string openingPriceToday; // 今日开盘价
        public string closingPriceYestday; // 昨日收盘价
        public string currentPrice; // 现价
        public string highestPriceToday; // 今日最高价
        public string lowestPriceToday; // 今日最低价
        public string[] buyPrice; // 买价(买一~买五)
        public string[] sellPrice; // 卖价(卖一~卖五)
        public string[] buyAmount; // 买数量(买一~买五)
        public string[] sellAmount; // 买数量(买一~买五)
        public string dataTime; // 数据来源时间

        // 构造函数
        public ShareData (string[] shareParams)
        {
            if (shareParams.Length < 32)
                return;
            this.shareName = shareParams[0];
            this.openingPriceToday = shareParams[1];
            this.closingPriceYestday = shareParams[2];
            this.currentPrice = shareParams[3];
            this.highestPriceToday = shareParams[4];
            this.lowestPriceToday = shareParams[5];
            this.buyPrice = new string[5] { shareParams[6], shareParams[13], shareParams[15], shareParams[17], shareParams[19] };
            this.sellPrice = new string[5] { shareParams[7], shareParams[23], shareParams[25], shareParams[27], shareParams[29] };
            this.buyAmount = new string[5] { shareParams[10], shareParams[12], shareParams[14], shareParams[16], shareParams[18] };
            this.sellAmount = new string[5] { shareParams[20], shareParams[22], shareParams[24], shareParams[26], shareParams[28] };
            this.dataTime = shareParams[31];
        }

        // 构造函数
        public ShareData(ShareData shareData)
        {
            this.shareName = shareData.shareName;
            this.openingPriceToday = shareData.openingPriceToday;
            this.closingPriceYestday = shareData.closingPriceYestday;
            this.currentPrice = shareData.currentPrice;
            this.highestPriceToday = shareData.highestPriceToday;
            this.lowestPriceToday = shareData.lowestPriceToday;
            this.buyPrice = shareData.buyPrice;
            this.sellPrice = shareData.sellPrice;
            this.buyAmount = shareData.buyAmount;
            this.sellPrice = shareData.sellPrice;
            this.dataTime = shareData.dataTime;
        }

        // 静态构建 ShareData
        public static ShareData Build(string[] shareParams)
        {
            return new ShareData(shareParams);
        }

        // 静态构建 ShareData
        public static ShareData Build(ShareData shareData)
        {
            return new ShareData(shareData);
        }
    }
}
