//------------------------------------------------------------------------------
//
// file name：ProformaInvoiceAccessor.cs
// author: mayanjun
// create date：2019/3/13 18:44:58
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
    /// Data accessor of ProformaInvoice
    /// </summary>
    public partial class ProformaInvoiceAccessor : EntityAccessor, IProformaInvoiceAccessor
    {
        public IList<Model.ProformaInvoice> SelectByCondition(DateTime dateStart, DateTime dateEnd, string customerId)
        {
            StringBuilder sql = new StringBuilder("select *,c.CustomerFullName,b.BankName from ProformaInvoice  pfi left join Customer c on pfi.CustomerId=c.CustomerId left join Bank b on pfi.BankId=b.BankId where pfi.InvoiceDate between '" + dateStart.Date.ToString("yyyy-MM-dd") + "' and '" + dateEnd.Date.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss") + "'");

            if (!string.IsNullOrEmpty(customerId))
                sql.Append(" and pfi.CustomerId='" + customerId + "'");
            sql.Append(" order by pfi.InsertTime");

            return this.DataReaderBind<Model.ProformaInvoice>(sql.ToString(), null, CommandType.Text);
        }
    }
}
