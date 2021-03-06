﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：PCImpactCheckDetailManager.autogenerated.cs
// author: mayanjun
// create date：2011-11-15 14:52:25
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class PCImpactCheckDetailManager
    {
		///<summary>
		/// Data accessor of dbo.PCImpactCheckDetail
		///</summary>
		private static readonly DA.IPCImpactCheckDetailAccessor accessor = (DA.IPCImpactCheckDetailAccessor)Accessors.Get("PCImpactCheckDetailAccessor");
		
		
		public bool HasRows(string pCImpactCheckDetailId)
		{
			return accessor.HasRows(pCImpactCheckDetailId);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.PCImpactCheckDetail> Select()
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
		public IList<Model.PCImpactCheckDetail> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		public bool ExistsPrimary(string id)
		{
		    return accessor.ExistsPrimary(id);	
	    }
		
    }
}
