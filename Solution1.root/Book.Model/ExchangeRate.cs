//------------------------------------------------------------------------------
//
// file name：ExchangeRate.cs
// author: mayanjun
// create date：2018/11/15 23:30:48
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
    /// <summary>
    /// 汇率
    /// </summary>
    [Serializable]
    public partial class ExchangeRate
    {
        public static string GetCurrencyENName(string currency)
        {
            string enName = "";
            switch (currency)
            {
                case "人民幣":
                    enName = "RMB";
                    break;
                case "新台幣":
                    enName = "NTD";
                    break;
                case "美金":
                    enName = "USD";
                    break;
                case "歐元":
                    enName = "EURO";
                    break;
                case "日圓":
                    enName = "JYP";
                    break;
            }

            return enName;
        }

        public static string GetCurrencyENNameAndSign(string currency)
        {
            string enName = "";
            switch (currency)
            {
                case "人民幣":
                    enName = "CNY¥";
                    break;
                case "新台幣":
                    enName = "NT$";
                    break;
                case "美金":
                    enName = "US$";
                    break;
                case "歐元":
                    enName = "€";
                    break;
                case "日圓":
                    enName = "JPY¥";
                    break;
            }

            return enName;
        }

        public static string GetCurrencySign(string currency)
        {
            string enName = "";
            switch (currency)
            {
                case "人民幣":
                    enName = "¥";
                    break;
                case "新台幣":
                    enName = "$";
                    break;
                case "美金":
                    enName = "$";
                    break;
                case "歐元":
                    enName = "€";
                    break;
                case "日圓":
                    enName = "¥";
                    break;
            }

            return enName;
        }
    }
}