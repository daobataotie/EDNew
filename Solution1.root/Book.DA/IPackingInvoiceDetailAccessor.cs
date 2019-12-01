//------------------------------------------------------------------------------
//
// file name：IPackingInvoiceDetailAccessor.cs
// author: mayanjun
// create date：2018/12/2 16:05:25
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    /// <summary>
    /// Interface of data accessor of dbo.PackingInvoiceDetail
    /// </summary>
    public partial interface IPackingInvoiceDetailAccessor : IAccessor
    {
        void DeleteByHeader(string headerId);

        IList<Model.PackingInvoiceDetail> SelectByHeader(string headerId);
    }
}
