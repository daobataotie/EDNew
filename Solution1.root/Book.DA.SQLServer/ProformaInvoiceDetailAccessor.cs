//------------------------------------------------------------------------------
//
// file name：ProformaInvoiceDetailAccessor.cs
// author: mayanjun
// create date：2019/3/13 20:30:28
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
    /// Data accessor of ProformaInvoiceDetail
    /// </summary>
    public partial class ProformaInvoiceDetailAccessor : EntityAccessor, IProformaInvoiceDetailAccessor
    {
        public IList<Model.ProformaInvoiceDetail> SelectByHeader(string headerId)
        {
            return sqlmapper.QueryForList<Model.ProformaInvoiceDetail>("ProformaInvoiceDetail.SelectByHeader", headerId);
        }

        public void DeleteByHeader(string headerId)
        {
            sqlmapper.Delete("ProformaInvoiceDetail.DeleteByHeader", headerId);
        }
    }
}
