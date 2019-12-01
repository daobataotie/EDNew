//------------------------------------------------------------------------------
//
// file name：IPackingInvoiceHeaderAccessor.cs
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
    /// Interface of data accessor of dbo.PackingInvoiceHeader
    /// </summary>
    public partial interface IPackingInvoiceHeaderAccessor : IAccessor
    {
        IList<Model.PackingInvoiceHeader> SelectByCondition(DateTime startDate, DateTime endDate, string customerId);
    }
}
