//------------------------------------------------------------------------------
//
// file name：IProformaInvoiceDetailAccessor.cs
// author: mayanjun
// create date：2019/3/13 20:30:28
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    /// <summary>
    /// Interface of data accessor of dbo.ProformaInvoiceDetail
    /// </summary>
    public partial interface IProformaInvoiceDetailAccessor : IAccessor
    {
        IList<Model.ProformaInvoiceDetail> SelectByHeader(string headerId);

        void DeleteByHeader(string headerId);
    }
}
