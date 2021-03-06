﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：PackingInvoiceHeaderManager.autogenerated.cs
// author: mayanjun
// create date：2018/12/2 16:05:25
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class PackingInvoiceHeaderManager
    {
		///<summary>
		/// Data accessor of dbo.PackingInvoiceHeader
		///</summary>
		private static readonly DA.IPackingInvoiceHeaderAccessor accessor = (DA.IPackingInvoiceHeaderAccessor)Accessors.Get("PackingInvoiceHeaderAccessor");
		
		/// <summary>
		/// Select by primary key.
		/// </summary>		
		public Model.PackingInvoiceHeader Get(string invoiceNo)
		{
			return accessor.Get(invoiceNo);
		}
		
		public bool HasRows(string invoiceNo)
		{
			return accessor.HasRows(invoiceNo);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		
		public bool HasRowsBefore(Model.PackingInvoiceHeader e)
		{
			return accessor.HasRowsBefore(e);
		}
		
		public bool HasRowsAfter(Model.PackingInvoiceHeader e)
		{
			return accessor.HasRowsAfter(e);
		}
		
		public Model.PackingInvoiceHeader GetFirst()
		{
			return accessor.GetFirst();
		}
		
		public Model.PackingInvoiceHeader GetLast()
		{
			return accessor.GetLast();
		}
		
		public Model.PackingInvoiceHeader GetPrev(Model.PackingInvoiceHeader e)
		{
			return accessor.GetPrev(e);
		}
		
		public Model.PackingInvoiceHeader GetNext(Model.PackingInvoiceHeader e)
		{
			return accessor.GetNext(e);
		}
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.PackingInvoiceHeader> Select()
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
		public IList<Model.PackingInvoiceHeader> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		public bool ExistsPrimary(string id)
		{
		    return accessor.ExistsPrimary(id);	
	    }
		
    }
}
