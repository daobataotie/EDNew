﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：AtCurrencyCategoryManager.autogenerated.cs
// author: mayanjun
// create date：2011-6-8 10:03:40
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class AtCurrencyCategoryManager
    {
		///<summary>
		/// Data accessor of dbo.AtCurrencyCategory
		///</summary>
		private static readonly DA.IAtCurrencyCategoryAccessor accessor = (DA.IAtCurrencyCategoryAccessor)Accessors.Get("AtCurrencyCategoryAccessor");
		
		/// <summary>
		/// Select by primary key.
		/// </summary>		
		public Model.AtCurrencyCategory Get(string atCurrencyCategoryId)
		{
			return accessor.Get(atCurrencyCategoryId);
		}
		
		public bool HasRows(string atCurrencyCategoryId)
		{
			return accessor.HasRows(atCurrencyCategoryId);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		public bool Exists(string id)
		{
			return accessor.Exists(id);
		}
		
		public Model.AtCurrencyCategory GetById(string id)
		{
			return accessor.GetById(id);
		}		
		public bool ExistsExcept(Model.AtCurrencyCategory e)
		{
			return accessor.ExistsExcept(e);
		}
		
		
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.AtCurrencyCategory> Select()
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
		public IList<Model.AtCurrencyCategory> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		public bool ExistsPrimary(string id)
		{
		    return accessor.ExistsPrimary(id);	
	    }
		
    }
}
