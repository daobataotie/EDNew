﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：RetailDetailManager.autogenerated.cs
// author: peidun
// create date：2009-10-13 上午 11:45:02
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class RetailDetailManager
    {
		///<summary>
		/// Data accessor of dbo.RetailDetail
		///</summary>
		private static readonly DA.IRetailDetailAccessor accessor = (DA.IRetailDetailAccessor)Accessors.Get("RetailDetailAccessor");
		
		/// <summary>
		/// Select by primary key.
		/// </summary>		
		public Model.RetailDetail Get(string retailDetailId)
		{
			return accessor.Get(retailDetailId);
		}
		
		public bool HasRows(string retailDetailId)
		{
			return accessor.HasRows(retailDetailId);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.RetailDetail> Select()
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
		public IList<Model.RetailDetail> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		
    }
}
