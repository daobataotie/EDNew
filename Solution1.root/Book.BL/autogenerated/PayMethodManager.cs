﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：PayMethodManager.autogenerated.cs
// author: peidun
// create date：2009-10-13 上午 11:45:02
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class PayMethodManager
    {
		///<summary>
		/// Data accessor of dbo.PayMethod
		///</summary>
		private static readonly DA.IPayMethodAccessor accessor = (DA.IPayMethodAccessor)Accessors.Get("PayMethodAccessor");
		
		/// <summary>
		/// Select by primary key.
		/// </summary>		
		public Model.PayMethod Get(string payMethodId)
		{
			return accessor.Get(payMethodId);
		}
		
		public bool HasRows(string payMethodId)
		{
			return accessor.HasRows(payMethodId);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		public bool Exists(string name)
		{
			return accessor.Exists(name);
		}
		
		public Model.PayMethod GetById(string id)
		{
			return accessor.GetById(id);
		}
		
		public bool ExistsExcept(Model.PayMethod e)
		{
			return accessor.ExistsExcept(e);
		}
		public bool HasRowsBefore(Model.PayMethod e)
		{
			return accessor.HasRowsBefore(e);
		}
		
		public bool HasRowsAfter(Model.PayMethod e)
		{
			return accessor.HasRowsAfter(e);
		}
		
		public Model.PayMethod GetFirst()
		{
			return accessor.GetFirst();
		}
		
		public Model.PayMethod GetLast()
		{
			return accessor.GetLast();
		}
		
		public Model.PayMethod GetPrev(Model.PayMethod e)
		{
			return accessor.GetPrev(e);
		}
		
		public Model.PayMethod GetNext(Model.PayMethod e)
		{
			return accessor.GetNext(e);
		}
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.PayMethod> Select()
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
		public IList<Model.PayMethod> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		
    }
}
