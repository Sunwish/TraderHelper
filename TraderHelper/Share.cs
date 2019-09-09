using System;
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

        private Share() { }

        public Share(ShareInfo shareInfo, ShareData shareData)
        {
            this.shareInfo = shareInfo;
            this.shareData = shareData;
        }

        public static Share CreateFromShareInfo(ShareInfo shareInfo)
        {
            Share share = new Share();
            share.shareInfo = ShareInfo.Build(shareInfo);
            share.shareData = GetShareDataFromShareInfo(shareInfo);

            return share;
        }

        public static Share CreateFromShareInfo(string shareUrlHeader, string shareUrlType, string shareUrlCode)
        {
            Share share = new Share();
            share.shareInfo = ShareInfo.Build(shareUrlHeader, shareUrlType, shareUrlCode);
            share.shareData = GetShareDataFromShareInfo(share.shareInfo);

            return share;
        }

        private static ShareData GetShareDataFromShareInfo(ShareInfo shareInfo)
        {
            // Get http response
            string requestURL = MakeShareResponseURL(shareInfo.shareUrlHeader, shareInfo.shareUrlType, shareInfo.shareUrlCode);
            string httpResponse;
            httpResponse = Helper.HttpResponse(requestURL, "GB2312");

            // Gain infomation
            string reg1 = Helper.Regexer(@"(?<=.+=.).+(?=,)", httpResponse);
            string[] shareParams = reg1.Split(',');
            ShareData shareData = new TraderHelper.ShareData(shareParams);

            if (shareParams.Length == 1)
                throw new SystemException("[Exception] UpdateShareDataFromShareInfo: 信息获取错误;");

            return shareData;
        }

        private ShareData GetShareDataFromShareInfo()
        {
            return GetShareDataFromShareInfo(this.shareInfo);
        }

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

        public ShareInfo(string shareUrlHeader, string shareUrlType, string shareUrlCode)
        {
            this.shareUrlHeader = shareUrlHeader;
            this.shareUrlType = shareUrlType;
            this.shareUrlCode = shareUrlCode;
        }

        public ShareInfo(ShareInfo shareInfo)
        {
            this.shareUrlHeader = shareInfo.shareUrlHeader;
            this.shareUrlType = shareInfo.shareUrlType;
            this.shareUrlCode = shareInfo.shareUrlCode;
        }

        public static ShareInfo Build(string shareUrlHeader, string shareUrlType, string shareUrlCode)
        {
            return new ShareInfo(shareUrlHeader, shareUrlType, shareUrlCode);
        }

        public static ShareInfo Build(ShareInfo shareInfo)
        {
            return new ShareInfo(shareInfo);
        }

    }

    class ShareData
    {
        public string shareName;
        public string openingPriceToday;
        public string closingPriceYestday;
        public string currentPrice;
        public string highestPriceToday;
        public string lowestPriceToday;
        public string[] buyPrice;
        public string[] sellPrice;
        public string[] buyAmount;
        public string[] sellAmount;
        public string dataTime;

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

        public static ShareData Build(string[] shareParams)
        {
            return new ShareData(shareParams);
        }

        public static ShareData Build(ShareData shareData)
        {
            return new ShareData(shareData);
        }
    }
}
