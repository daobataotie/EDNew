﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：PCEarplugsResilienceWeightManager.autogenerated.cs
// author: mayanjun
// create date：2019/8/25 22:18:54
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class PCEarplugsResilienceWeightManager
    {
		///<summary>
		/// Data accessor of dbo.PCEarplugsResilienceWeight
		///</summary>
		private static readonly DA.IPCEarplugsResilienceWeightAccessor accessor = (DA.IPCEarplugsResilienceWeightAccessor)Accessors.Get("PCEarplugsResilienceWeightAccessor");
		
		/// <summary>
		/// Select by primary key.
		/// </summary>		
		public Model.PCEarplugsResilienceWeight Get(string pCEarplugsResilienceWeightId)
		{
			return accessor.Get(pCEarplugsResilienceWeightId);
		}
		
		public bool HasRows(string pCEarplugsResilienceWeightId)
		{
			return accessor.HasRows(pCEarplugsResilienceWeightId);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		
		public bool HasRowsBefore(Model.PCEarplugsResilienceWeight e)
		{
			return accessor.HasRowsBefore(e);
		}
		
		public bool HasRowsAfter(Model.PCEarplugsResilienceWeight e)
		{
			return accessor.HasRowsAfter(e);
		}
		
		public Model.PCEarplugsResilienceWeight GetFirst()
		{
			return accessor.GetFirst();
		}
		
		public Model.PCEarplugsResilienceWeight GetLast()
		{
			return accessor.GetLast();
		}
		
		public Model.PCEarplugsResilienceWeight GetPrev(Model.PCEarplugsResilienceWeight e)
		{
			return accessor.GetPrev(e);
		}
		
		public Model.PCEarplugsResilienceWeight GetNext(Model.PCEarplugsResilienceWeight e)
		{
			return accessor.GetNext(e);
		}
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.PCEarplugsResilienceWeight> Select()
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
		public IList<Model.PCEarplugsResilienceWeight> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		public bool ExistsPrimary(string id)
		{
		    return accessor.ExistsPrimary(id);	
	    }
		
    }
}
