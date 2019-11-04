﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：StockCheckManager.autogenerated.cs
// author: mayanjun
// create date：2010-7-30 11:43:32
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class StockCheckManager
    {
		///<summary>
		/// Data accessor of dbo.StockCheck
		///</summary>
		private static readonly DA.IStockCheckAccessor accessor = (DA.IStockCheckAccessor)Accessors.Get("StockCheckAccessor");
        //private static readonly DA.IStockCheckDetailAccessor stockCheckDetailAccessor = (DA.IStockCheckDetailAccessor)Accessors.Get("StockCheckDetailAccessor");
		/// <summary>
		/// Select by primary key.
		/// </summary>		
		public Model.StockCheck Get(string stockCheckId)
		{

			return accessor.Get(stockCheckId);
		}
		
		public bool HasRows(string stockCheckId)
		{
			return accessor.HasRows(stockCheckId);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		
		public bool HasRowsBefore(Model.StockCheck e)
		{
			return accessor.HasRowsBefore(e);
		}
		
		public bool HasRowsAfter(Model.StockCheck e)
		{
			return accessor.HasRowsAfter(e);
		}
		
		public Model.StockCheck GetFirst()
		{
			return accessor.GetFirst();
		}
		
		public Model.StockCheck GetLast()
		{
			return accessor.GetLast();
		}
		
		public Model.StockCheck GetPrev(Model.StockCheck e)
		{
			return accessor.GetPrev(e);
		}
		
		public Model.StockCheck GetNext(Model.StockCheck e)
		{
			return accessor.GetNext(e);
		}
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.StockCheck> Select()
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
		public IList<Model.StockCheck> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		public bool ExistsPrimary(string id)
		{
		    return accessor.ExistsPrimary(id);	
	    }

        
		
    }
}
