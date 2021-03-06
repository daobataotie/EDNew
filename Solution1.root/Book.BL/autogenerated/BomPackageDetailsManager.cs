﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：BomPackageDetailsManager.autogenerated.cs
// author: peidun
// create date：2009-11-12 11:47:18
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class BomPackageDetailsManager
    {
		///<summary>
		/// Data accessor of dbo.BomPackageDetails
		///</summary>
		private static readonly DA.IBomPackageDetailsAccessor accessor = (DA.IBomPackageDetailsAccessor)Accessors.Get("BomPackageDetailsAccessor");
		
		/// <summary>
		/// Select by primary key.
		/// </summary>		
		public Model.BomPackageDetails Get(string bomPackageDetailsId)
		{
			return accessor.Get(bomPackageDetailsId);
		}
		
		public bool HasRows(string bomPackageDetailsId)
		{
			return accessor.HasRows(bomPackageDetailsId);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.BomPackageDetails> Select()
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
		public IList<Model.BomPackageDetails> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		
    }
}
