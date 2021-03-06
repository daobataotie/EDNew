﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：BankManager.autogenerated.cs
// author: peidun
// create date：2009-10-13 上午 11:45:01
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class BankManager
    {
		///<summary>
		/// Data accessor of dbo.Bank
		///</summary>
		private static readonly DA.IBankAccessor accessor = (DA.IBankAccessor)Accessors.Get("BankAccessor");
		
		/// <summary>
		/// Select by primary key.
		/// </summary>		
		public Model.Bank Get(string bankId)
		{
			return accessor.Get(bankId);
		}
		
		public bool HasRows(string bankId)
		{
			return accessor.HasRows(bankId);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		public bool HasRowsBefore(Model.Bank e)
		{
			return accessor.HasRowsBefore(e);
		}
		
		public bool HasRowsAfter(Model.Bank e)
		{
			return accessor.HasRowsAfter(e);
		}
		
		public Model.Bank GetFirst()
		{
			return accessor.GetFirst();
		}
		
		public Model.Bank GetLast()
		{
			return accessor.GetLast();
		}
		
		public Model.Bank GetPrev(Model.Bank e)
		{
			return accessor.GetPrev(e);
		}
		
		public Model.Bank GetNext(Model.Bank e)
		{
			return accessor.GetNext(e);
		}
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.Bank> Select()
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
		public IList<Model.Bank> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		
    }
}
