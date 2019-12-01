//------------------------------------------------------------------------------
//
// file name：PackingInvoiceHeaderAccessor.cs
// author: mayanjun
// create date：2018/12/2 16:05:25
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
    /// Data accessor of PackingInvoiceHeader
    /// </summary>
    public partial class PackingInvoiceHeaderAccessor : EntityAccessor, IPackingInvoiceHeaderAccessor
    {
        public IList<Model.PackingInvoiceHeader> SelectByCondition(DateTime startDate, DateTime endDate, string customerId)
        {
            StringBuilder sql = new StringBuilder("select * from PackingInvoiceHeader where InvoiceDate between '" + startDate.Date.ToString("yyyy-MM-dd") + "' and '" + endDate.Date.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss") + "'");

            if (!string.IsNullOrEmpty(customerId))
                sql.Append(" and CustomerId='" + customerId + "'");

            return this.DataReaderBind<Model.PackingInvoiceHeader>(sql.ToString(), null, CommandType.Text);
        }
    }
}
