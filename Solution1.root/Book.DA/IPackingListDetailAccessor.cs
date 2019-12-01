//------------------------------------------------------------------------------
//
// file name：IPackingListDetailAccessor.cs
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
    /// Interface of data accessor of dbo.PackingListDetail
    /// </summary>
    public partial interface IPackingListDetailAccessor : IAccessor
    {
        IList<Model.PackingListDetail> SelectByHeader(string headerId);

        void DeleteByHeader(string headerId);
    }
}
