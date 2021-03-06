﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：AtInvoiceSetManager.autogenerated.cs
// author: mayanjun
// create date：2011-3-3 14:30:19
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class AtInvoiceSetManager
    {
		///<summary>
		/// Data accessor of dbo.AtInvoiceSet
		///</summary>
		private static readonly DA.IAtInvoiceSetAccessor accessor = (DA.IAtInvoiceSetAccessor)Accessors.Get("AtInvoiceSetAccessor");
		
		/// <summary>
		/// Select by primary key.
		/// </summary>		
		public Model.AtInvoiceSet Get(string id)
		{
			return accessor.Get(id);
		}
		
		public bool HasRows(string id)
		{
			return accessor.HasRows(id);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		public bool Exists(string id)
		{
			return accessor.Exists(id);
		}
		
		public Model.AtInvoiceSet GetById(string id)
		{
			return accessor.GetById(id);
		}		
		public bool ExistsExcept(Model.AtInvoiceSet e)
		{
			return accessor.ExistsExcept(e);
		}
		
		
		public bool HasRowsBefore(Model.AtInvoiceSet e)
		{
			return accessor.HasRowsBefore(e);
		}
		
		public bool HasRowsAfter(Model.AtInvoiceSet e)
		{
			return accessor.HasRowsAfter(e);
		}
		
		public Model.AtInvoiceSet GetFirst()
		{
			return accessor.GetFirst();
		}
		
		public Model.AtInvoiceSet GetLast()
		{
			return accessor.GetLast();
		}
		
		public Model.AtInvoiceSet GetPrev(Model.AtInvoiceSet e)
		{
			return accessor.GetPrev(e);
		}
		
		public Model.AtInvoiceSet GetNext(Model.AtInvoiceSet e)
		{
			return accessor.GetNext(e);
		}
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.AtInvoiceSet> Select()
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
		public IList<Model.AtInvoiceSet> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		public bool ExistsPrimary(string id)
		{
		    return accessor.ExistsPrimary(id);	
	    }
		
    }
}
