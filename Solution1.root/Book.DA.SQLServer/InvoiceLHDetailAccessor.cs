//------------------------------------------------------------------------------
//
// file name：InvoiceLHDetailAccessor.cs
// author: mayanjun
// create date：2018/10/20 11:17:53
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
    /// Data accessor of InvoiceLHDetail
    /// </summary>
    public partial class InvoiceLHDetailAccessor : EntityAccessor, IInvoiceLHDetailAccessor
    {
        public IList<Model.InvoiceLHDetail> SelectByHeaderId(string invoiceId)
        {
            return sqlmapper.QueryForList<Model.InvoiceLHDetail>("InvoiceLHDetail.SelectByHeaderId", invoiceId);
        }

        public void DeleteByHeaderId(string invoiceId)
        {
            sqlmapper.Delete("InvoiceLHDetail.DeleteByHeaderId", invoiceId);
        }

        public IList<Model.InvoiceLHDetail> SelectByCondition(DateTime StartDate, DateTime EndDate, string CustomerId)
        {
            Hashtable ht = new Hashtable();
            ht.Add("StartDate", StartDate);
            ht.Add("EndDate", EndDate);
            if (!string.IsNullOrEmpty(CustomerId))
                ht.Add("sql", "and lh.CustomerId='" + CustomerId + "'");

            return sqlmapper.QueryForList<Model.InvoiceLHDetail>("InvoiceLHDetail.SelectByCondition", ht);
        }
    }
}
