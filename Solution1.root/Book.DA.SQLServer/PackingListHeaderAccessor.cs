//------------------------------------------------------------------------------
//
// file name：PackingListHeaderAccessor.cs
// author: mayanjun
// create date：2018/11/11 17:33:41
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
    /// Data accessor of PackingListHeader
    /// </summary>
    public partial class PackingListHeaderAccessor : EntityAccessor, IPackingListHeaderAccessor
    {
        public IList<Model.PackingListHeader> SelectByCondition(DateTime startDate, DateTime endDate, string customerId)
        {
            StringBuilder sql = new StringBuilder("select * from PackingListHeader where PackingDate between '" + startDate.Date.ToString("yyyy-MM-dd") + "' and '" + endDate.Date.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss") + "'");

            if (!string.IsNullOrEmpty(customerId))
                sql.Append(" and CustomerId='" + customerId + "'");

            return this.DataReaderBind<Model.PackingListHeader>(sql.ToString(), null, CommandType.Text);
        }
    }
}
