//------------------------------------------------------------------------------
//
// file name：IInvoiceLHDetailAccessor.cs
// author: mayanjun
// create date：2018/10/20 11:17:53
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    /// <summary>
    /// Interface of data accessor of dbo.InvoiceLHDetail
    /// </summary>
    public partial interface IInvoiceLHDetailAccessor : IAccessor
    {
        IList<Model.InvoiceLHDetail> SelectByHeaderId(string invoiceId);

        void DeleteByHeaderId(string invoiceId);

        IList<Model.InvoiceLHDetail> SelectByCondition(DateTime StartDate, DateTime EndDate, string CustomerId);
    }
}
