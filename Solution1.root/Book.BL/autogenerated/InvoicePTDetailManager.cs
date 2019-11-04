﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：InvoicePTDetailManager.autogenerated.cs
// author: peidun
// create date：2009-10-13 上午 11:45:01
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class InvoicePTDetailManager
    {
		///<summary>
		/// Data accessor of dbo.InvoicePTDetail
		///</summary>
		private static readonly DA.IInvoicePTDetailAccessor accessor = (DA.IInvoicePTDetailAccessor)Accessors.Get("InvoicePTDetailAccessor");
		
		/// <summary>
		/// Select by primary key.
		/// </summary>		
		public Model.InvoicePTDetail Get(string invoicePTDetailId)
		{
			return accessor.Get(invoicePTDetailId);
		}
		
		public bool HasRows(string invoicePTDetailId)
		{
			return accessor.HasRows(invoicePTDetailId);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.InvoicePTDetail> Select()
		{
			return accessor.Select();
		}
		
		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int Count()
		{
			return accessor.Count();
		}
		
		/// <summary>
		/// 获取指定状态、指定分页，并按指定要求排序的记录
		/// </summary>
		public IList<Model.InvoicePTDetail> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		
    }
}
