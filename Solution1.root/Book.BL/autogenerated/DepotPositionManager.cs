﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：DepotPositionManager.autogenerated.cs
// author: peidun
// create date：2009-10-13 上午 11:45:01
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class DepotPositionManager
    {
		///<summary>
		/// Data accessor of dbo.DepotPosition
		///</summary>
		private static readonly DA.IDepotPositionAccessor accessor = (DA.IDepotPositionAccessor)Accessors.Get("DepotPositionAccessor");
		
		/// <summary>
		/// Select by primary key.
		/// </summary>		
		public Model.DepotPosition Get(string depotPositionId)
		{
			return accessor.Get(depotPositionId);
		}
		
		public bool HasRows(string depotPositionId)
		{
			return accessor.HasRows(depotPositionId);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		public bool Exists(string id)
		{
			return accessor.Exists(id);
		}
		
		public Model.DepotPosition GetById(string id)
		{
			return accessor.GetById(id);
		}
		
		public bool ExistsExcept(Model.DepotPosition e)
		{
			return accessor.ExistsExcept(e);
		}
		public bool HasRowsBefore(Model.DepotPosition e)
		{
			return accessor.HasRowsBefore(e);
		}
		
		public bool HasRowsAfter(Model.DepotPosition e)
		{
			return accessor.HasRowsAfter(e);
		}
		
		public Model.DepotPosition GetFirst()
		{
			return accessor.GetFirst();
		}
		
		public Model.DepotPosition GetLast()
		{
			return accessor.GetLast();
		}
		
		public Model.DepotPosition GetPrev(Model.DepotPosition e)
		{
			return accessor.GetPrev(e);
		}
		
		public Model.DepotPosition GetNext(Model.DepotPosition e)
		{
			return accessor.GetNext(e);
		}
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.DepotPosition> Select()
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
		public IList<Model.DepotPosition> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		
    }
}
