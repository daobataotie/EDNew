//------------------------------------------------------------------------------
//
// file name：ExchangeRateManager.cs
// author: mayanjun
// create date：2018/11/15 23:30:48
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    /// <summary>
    /// Business logic for dbo.ExchangeRate.
    /// </summary>
    public partial class ExchangeRateManager
    {

        /// <summary>
        /// Delete ExchangeRate by primary key.
        /// </summary>
        public void Delete(string id)
        {
            //
            // todo:add other logic here
            //
            accessor.Delete(id);
        }

        /// <summary>
        /// Insert a ExchangeRate.
        /// </summary>
        public void Insert(Model.ExchangeRate exchangeRate)
        {
            //
            // todo:add other logic here
            //
            accessor.Insert(exchangeRate);
        }

        /// <summary>
        /// Update a ExchangeRate.
        /// </summary>
        public void Update(Model.ExchangeRate exchangeRate)
        {
            //
            // todo: add other logic here.
            //
            accessor.Update(exchangeRate);
        }

        public bool IsExistsSame(Model.ExchangeRate model)
        {
            return accessor.IsExistsSame(model);
        }

        public decimal GetRateByDateAndCurrency(DateTime date, string currency)
        {
            return accessor.GetRateByDateAndCurrency(date, currency);
        }

        public void Update(IList<Model.ExchangeRate> list)
        {
            foreach (var item in list)
            {
                if (item.YearValue == null)
                    throw new Helper.RequireValueException(Model.ExchangeRate.PRO_YearValue);
                if (item.MonthValue == null)
                    throw new Helper.RequireValueException(Model.ExchangeRate.PRO_MonthValue);
                if (string.IsNullOrEmpty(item.Currency))
                    throw new Helper.RequireValueException(Model.ExchangeRate.PRO_Currency);
                //if (IsExistsSame(item))
                //    throw new Helper.RequireValueException(Model.ExchangeRate.PRO_Id);

                if (IsExistsSame(item))
                    throw new Exception(string.Format("已存在相同月份 {0}-{1} 相同的幣別 {2}", item.YearValue, item.MonthValue, item.Currency));
            }

            foreach (var item in list)
            {
                if (accessor.ExistsPrimary(item.Id))
                {
                    accessor.Update(item);
                }
                else
                {
                    this.Insert(item);
                }
            }
        }
    }
}
