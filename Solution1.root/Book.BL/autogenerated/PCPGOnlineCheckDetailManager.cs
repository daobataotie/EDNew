﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：PCPGOnlineCheckDetailManager.autogenerated.cs
// author: mayanjun
// create date：2011-12-6 14:34:43
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class PCPGOnlineCheckDetailManager
    {
		///<summary>
		/// Data accessor of dbo.PCPGOnlineCheckDetail
		///</summary>
		private static readonly DA.IPCPGOnlineCheckDetailAccessor accessor = (DA.IPCPGOnlineCheckDetailAccessor)Accessors.Get("PCPGOnlineCheckDetailAccessor");
		
		/// <summary>
		/// Select by primary key.
		/// </summary>		
		public Model.PCPGOnlineCheckDetail Get(string pCPGOnlineCheckDetailId)
		{
			return accessor.Get(pCPGOnlineCheckDetailId);
		}
		
		public bool HasRows(string pCPGOnlineCheckDetailId)
		{
			return accessor.HasRows(pCPGOnlineCheckDetailId);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.PCPGOnlineCheckDetail> Select()
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
		public IList<Model.PCPGOnlineCheckDetail> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		public bool ExistsPrimary(string id)
		{
		    return accessor.ExistsPrimary(id);	
	    }
		
    }
}
