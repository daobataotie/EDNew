﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：PackingListDetailManager.autogenerated.cs
// author: mayanjun
// create date：2018/11/11 17:33:41
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class PackingListDetailManager
    {
		///<summary>
		/// Data accessor of dbo.PackingListDetail
		///</summary>
		private static readonly DA.IPackingListDetailAccessor accessor = (DA.IPackingListDetailAccessor)Accessors.Get("PackingListDetailAccessor");
		
		/// <summary>
		/// Select by primary key.
		/// </summary>		
		public Model.PackingListDetail Get(string packingListDetailId)
		{
			return accessor.Get(packingListDetailId);
		}
		
		public bool HasRows(string packingListDetailId)
		{
			return accessor.HasRows(packingListDetailId);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.PackingListDetail> Select()
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
		public IList<Model.PackingListDetail> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		public bool ExistsPrimary(string id)
		{
		    return accessor.ExistsPrimary(id);	
	    }
		
    }
}
