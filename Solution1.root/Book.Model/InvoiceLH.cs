//------------------------------------------------------------------------------
//
// file name：InvoiceLH.cs
// author: mayanjun
// create date：2018/10/20 11:17:54
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.Model
{
    /// <summary>
    /// 理货单
    /// </summary>
    [Serializable]
    public partial class InvoiceLH : Invoice
    {
        IList<InvoiceLHDetail> _detail = new List<InvoiceLHDetail>();

        public IList<InvoiceLHDetail> Detail
        {
            get { return _detail; }
            set { _detail = value; }
        }
    }
}