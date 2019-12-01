//------------------------------------------------------------------------------
//
// file name：IPackingListHeaderAccessor.cs
// author: mayanjun
// create date：2018/11/11 17:33:41
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    /// <summary>
    /// Interface of data accessor of dbo.PackingListHeader
    /// </summary>
    public partial interface IPackingListHeaderAccessor : IAccessor
    {
        IList<Model.PackingListHeader> SelectByCondition(DateTime startDate, DateTime endDate, string customerId);
    }
}
