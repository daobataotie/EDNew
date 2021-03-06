﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：OutgoingKindManager.autogenerated.cs
// author: peidun
// create date：2010-4-7 16:05:17
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class OutgoingKindManager
    {
		///<summary>
		/// Data accessor of dbo.OutgoingKind
		///</summary>
		private static readonly DA.IOutgoingKindAccessor accessor = (DA.IOutgoingKindAccessor)Accessors.Get("OutgoingKindAccessor");
		
		/// <summary>
		/// Select by primary key.
		/// </summary>		
		public Model.OutgoingKind Get(string outgoingKindId)
		{
			return accessor.Get(outgoingKindId);
		}
		
		public bool HasRows(string outgoingKindId)
		{
			return accessor.HasRows(outgoingKindId);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		public bool Exists(string id)
		{
			return accessor.Exists(id);
		}
		
		public Model.OutgoingKind GetById(string id)
		{
			return accessor.GetById(id);
		}		
		public bool ExistsExcept(Model.OutgoingKind e)
		{
			return accessor.ExistsExcept(e);
		}
		
		
		public bool HasRowsBefore(Model.OutgoingKind e)
		{
			return accessor.HasRowsBefore(e);
		}
		
		public bool HasRowsAfter(Model.OutgoingKind e)
		{
			return accessor.HasRowsAfter(e);
		}
		
		public Model.OutgoingKind GetFirst()
		{
			return accessor.GetFirst();
		}
		
		public Model.OutgoingKind GetLast()
		{
			return accessor.GetLast();
		}
		
		public Model.OutgoingKind GetPrev(Model.OutgoingKind e)
		{
			return accessor.GetPrev(e);
		}
		
		public Model.OutgoingKind GetNext(Model.OutgoingKind e)
		{
			return accessor.GetNext(e);
		}
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.OutgoingKind> Select()
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
		public IList<Model.OutgoingKind> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		public bool ExistsPrimary(string id)
		{
		    return accessor.ExistsPrimary(id);	
	    }
		
    }
}
