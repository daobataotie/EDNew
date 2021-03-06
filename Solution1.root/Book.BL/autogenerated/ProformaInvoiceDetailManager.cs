﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：ProformaInvoiceDetailManager.autogenerated.cs
// author: mayanjun
// create date：2019/3/13 20:30:28
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class ProformaInvoiceDetailManager
    {
		///<summary>
		/// Data accessor of dbo.ProformaInvoiceDetail
		///</summary>
		private static readonly DA.IProformaInvoiceDetailAccessor accessor = (DA.IProformaInvoiceDetailAccessor)Accessors.Get("ProformaInvoiceDetailAccessor");
		
		/// <summary>
		/// Select by primary key.
		/// </summary>		
		public Model.ProformaInvoiceDetail Get(string proformaInvoiceDetailId)
		{
			return accessor.Get(proformaInvoiceDetailId);
		}
		
		public bool HasRows(string proformaInvoiceDetailId)
		{
			return accessor.HasRows(proformaInvoiceDetailId);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.ProformaInvoiceDetail> Select()
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
		public IList<Model.ProformaInvoiceDetail> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		public bool ExistsPrimary(string id)
		{
		    return accessor.ExistsPrimary(id);	
	    }
		
    }
}
