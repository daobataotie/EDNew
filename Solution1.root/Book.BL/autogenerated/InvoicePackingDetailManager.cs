﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：InvoicePackingDetailManager.autogenerated.cs
// author: mayanjun
// create date：2013-1-14 11:19:06
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class InvoicePackingDetailManager
    {
		///<summary>
		/// Data accessor of dbo.InvoicePackingDetail
		///</summary>
		private static readonly DA.IInvoicePackingDetailAccessor accessor = (DA.IInvoicePackingDetailAccessor)Accessors.Get("InvoicePackingDetailAccessor");
		
		/// <summary>
		/// Select by primary key.
		/// </summary>		
		public Model.InvoicePackingDetail Get(string invoicePackingDetailId)
		{
			return accessor.Get(invoicePackingDetailId);
		}
		
		public bool HasRows(string invoicePackingDetailId)
		{
			return accessor.HasRows(invoicePackingDetailId);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.InvoicePackingDetail> Select()
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
		public IList<Model.InvoicePackingDetail> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		public bool ExistsPrimary(string id)
		{
		    return accessor.ExistsPrimary(id);	
	    }
		
    }
}
