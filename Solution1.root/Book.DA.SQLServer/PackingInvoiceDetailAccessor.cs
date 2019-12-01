//------------------------------------------------------------------------------
//
// file name：PackingInvoiceDetailAccessor.cs
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
    /// Data accessor of PackingInvoiceDetail
    /// </summary>
    public partial class PackingInvoiceDetailAccessor : EntityAccessor, IPackingInvoiceDetailAccessor
    {
        public void DeleteByHeader(string headerId)
        {
            sqlmapper.Delete("PackingInvoiceDetail.DeleteByHeader", headerId);
        }

        public IList<Model.PackingInvoiceDetail> SelectByHeader(string headerId)
        {
            return sqlmapper.QueryForList<Model.PackingInvoiceDetail>("PackingInvoiceDetail.SelectByHeader", headerId);
        }
    }
}
