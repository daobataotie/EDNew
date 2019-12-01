//------------------------------------------------------------------------------
//
// file name：PackingListHeader.cs
// author: mayanjun
// create date：2018/11/11 17:33:41
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.Model
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class PackingListHeader : Model.Invoice
    {
        IList<Model.PackingListDetail> _details = new List<Model.PackingListDetail>();

        public IList<Model.PackingListDetail> Details
        {
            get { return _details; }
            set { _details = value; }
        }
    }
}