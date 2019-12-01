//------------------------------------------------------------------------------
//
// file name：ExchangeRateAccessor.cs
// author: mayanjun
// create date：2018/11/15 23:30:48
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Book.DA.SQLServer
{
    /// <summary>
    /// Data accessor of ExchangeRate
    /// </summary>
    public partial class ExchangeRateAccessor : EntityAccessor, IExchangeRateAccessor
    {
        public bool IsExistsSame(Model.ExchangeRate model)
        {
            Hashtable ht = new Hashtable();
            ht.Add("YearValue", model.YearValue);
            ht.Add("MonthValue", model.MonthValue);
            ht.Add("Currency", model.Currency);
            ht.Add("Id", model.Id);

            return sqlmapper.QueryForObject<bool>("ExchangeRate.IsExistsSame", ht);
        }

        public decimal GetRateByDateAndCurrency(DateTime date, string currency)
        {
            Hashtable ht = new Hashtable();
            ht.Add("YearValue", date.Year);
            ht.Add("MonthValue", date.Month);
            ht.Add("Currency", currency);

            if (date.Day < 11)
                return sqlmapper.QueryForObject<decimal>("ExchangeRate.GetUpRateByDateAndCurrency", ht);
            else if (date.Day >= 11 && date.Day < 21)
                return sqlmapper.QueryForObject<decimal>("ExchangeRate.GetMiddleRateByDateAndCurrency", ht);
            else
                return sqlmapper.QueryForObject<decimal>("ExchangeRate.GetDownRateByDateAndCurrency", ht);
        }
    }

}
