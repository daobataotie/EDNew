//------------------------------------------------------------------------------
//
// file name：IProformaInvoiceAccessor.cs
// author: mayanjun
// create date：2019/3/13 18:44:58
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    /// <summary>
    /// Interface of data accessor of dbo.ProformaInvoice
    /// </summary>
    public partial interface IProformaInvoiceAccessor : IAccessor
    {
        IList<Model.ProformaInvoice> SelectByCondition(DateTime dateStart, DateTime dateEnd, string customerId);
    }
}
