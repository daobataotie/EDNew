﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：BillIdSetManager.autogenerated.cs
// author: mayanjun
// create date：2015/11/20 18:57:00
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class BillIdSetManager
    {
		///<summary>
		/// Data accessor of dbo.BillIdSet
		///</summary>
		private static readonly DA.IBillIdSetAccessor accessor = (DA.IBillIdSetAccessor)Accessors.Get("BillIdSetAccessor");
		
		/// <summary>
		/// Select by primary key.
		/// </summary>		
		public Model.BillIdSet Get(string billIdSetId)
		{
			return accessor.Get(billIdSetId);
		}
		
		public bool HasRows(string billIdSetId)
		{
			return accessor.HasRows(billIdSetId);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		
		public bool HasRowsBefore(Model.BillIdSet e)
		{
			return accessor.HasRowsBefore(e);
		}
		
		public bool HasRowsAfter(Model.BillIdSet e)
		{
			return accessor.HasRowsAfter(e);
		}
		
		public Model.BillIdSet GetFirst()
		{
			return accessor.GetFirst();
		}
		
		public Model.BillIdSet GetLast()
		{
			return accessor.GetLast();
		}
		
		public Model.BillIdSet GetPrev(Model.BillIdSet e)
		{
			return accessor.GetPrev(e);
		}
		
		public Model.BillIdSet GetNext(Model.BillIdSet e)
		{
			return accessor.GetNext(e);
		}
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.BillIdSet> Select()
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
		public IList<Model.BillIdSet> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		public bool ExistsPrimary(string id)
		{
		    return accessor.ExistsPrimary(id);	
	    }
		
    }
}
