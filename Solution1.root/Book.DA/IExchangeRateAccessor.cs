//------------------------------------------------------------------------------
//
// file name：IExchangeRateAccessor.cs
// author: mayanjun
// create date：2018/11/15 23:30:48
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    /// <summary>
    /// Interface of data accessor of dbo.ExchangeRate
    /// </summary>
    public partial interface IExchangeRateAccessor : IAccessor
    {
        bool IsExistsSame(Model.ExchangeRate model);

        decimal GetRateByDateAndCurrency(DateTime date, string currency);
    }
}
