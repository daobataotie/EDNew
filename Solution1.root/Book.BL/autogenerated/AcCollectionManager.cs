﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：AcCollectionManager.autogenerated.cs
// author: mayanjun
// create date：2011-6-23 09:29:20
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class AcCollectionManager
    {
		///<summary>
		/// Data accessor of dbo.AcCollection
		///</summary>
		private static readonly DA.IAcCollectionAccessor accessor = (DA.IAcCollectionAccessor)Accessors.Get("AcCollectionAccessor");
		
		/// <summary>
		/// Select by primary key.
		/// </summary>		
		public Model.AcCollection Get(string acCollectionId)
		{
			return accessor.Get(acCollectionId);
		}
		
		public bool HasRows(string acCollectionId)
		{
			return accessor.HasRows(acCollectionId);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		
		public bool HasRowsBefore(Model.AcCollection e)
		{
			return accessor.HasRowsBefore(e);
		}
		
		public bool HasRowsAfter(Model.AcCollection e)
		{
			return accessor.HasRowsAfter(e);
		}
		
		public Model.AcCollection GetFirst()
		{
			return accessor.GetFirst();
		}
		
		public Model.AcCollection GetLast()
		{
			return accessor.GetLast();
		}
		
		public Model.AcCollection GetPrev(Model.AcCollection e)
		{
			return accessor.GetPrev(e);
		}
		
		public Model.AcCollection GetNext(Model.AcCollection e)
		{
			return accessor.GetNext(e);
		}
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.AcCollection> Select()
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
		public IList<Model.AcCollection> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		public bool ExistsPrimary(string id)
		{
		    return accessor.ExistsPrimary(id);	
	    }
		
    }
}
