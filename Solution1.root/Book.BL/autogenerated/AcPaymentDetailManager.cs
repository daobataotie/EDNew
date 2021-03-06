﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：AcPaymentDetailManager.autogenerated.cs
// author: mayanjun
// create date：2011-6-23 09:29:20
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class AcPaymentDetailManager
    {
		///<summary>
		/// Data accessor of dbo.AcPaymentDetail
		///</summary>
		private static readonly DA.IAcPaymentDetailAccessor accessor = (DA.IAcPaymentDetailAccessor)Accessors.Get("AcPaymentDetailAccessor");
		
		/// <summary>
		/// Select by primary key.
		/// </summary>		
		public Model.AcPaymentDetail Get(string acPaymentDetailId)
		{
			return accessor.Get(acPaymentDetailId);
		}
		
		public bool HasRows(string acPaymentDetailId)
		{
			return accessor.HasRows(acPaymentDetailId);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.AcPaymentDetail> Select()
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
		public IList<Model.AcPaymentDetail> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		public bool ExistsPrimary(string id)
		{
		    return accessor.ExistsPrimary(id);	
	    }
		
    }
}
