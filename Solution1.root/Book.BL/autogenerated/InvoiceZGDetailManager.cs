﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：InvoiceZGDetailManager.autogenerated.cs
// author: mayanjun
// create date：2012-11-19 14:13:50
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class InvoiceZGDetailManager
    {
		///<summary>
		/// Data accessor of dbo.InvoiceZGDetail
		///</summary>
		private static readonly DA.IInvoiceZGDetailAccessor accessor = (DA.IInvoiceZGDetailAccessor)Accessors.Get("InvoiceZGDetailAccessor");
		
		/// <summary>
		/// Select by primary key.
		/// </summary>		
		public Model.InvoiceZGDetail Get(string invoiceZGDetailId)
		{
			return accessor.Get(invoiceZGDetailId);
		}
		
		public bool HasRows(string invoiceZGDetailId)
		{
			return accessor.HasRows(invoiceZGDetailId);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.InvoiceZGDetail> Select()
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
		public IList<Model.InvoiceZGDetail> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		public bool ExistsPrimary(string id)
		{
		    return accessor.ExistsPrimary(id);	
	    }
		
    }
}
