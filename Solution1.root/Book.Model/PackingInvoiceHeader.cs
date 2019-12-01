//------------------------------------------------------------------------------
//
// file name：PackingInvoiceHeader.cs
// author: mayanjun
// create date：2018/12/2 16:05:25
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public partial class PackingInvoiceHeader:Invoice
	{
        System.Collections.Generic.IList<Model.PackingInvoiceDetail> _details = new System.Collections.Generic.List<Model.PackingInvoiceDetail>();

        public System.Collections.Generic.IList<Model.PackingInvoiceDetail> Details
        {
            get { return _details; }
            set { _details = value; }
        }
	}
}