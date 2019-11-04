﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：ProductMaterialManager.autogenerated.cs
// author: mayanjun
// create date：2012-7-11 15:10:12
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class ProductMaterialManager
    {
		///<summary>
		/// Data accessor of dbo.ProductMaterial
		///</summary>
		private static readonly DA.IProductMaterialAccessor accessor = (DA.IProductMaterialAccessor)Accessors.Get("ProductMaterialAccessor");
		
		/// <summary>
		/// Select by primary key.
		/// </summary>		
		public Model.ProductMaterial Get(string productMaterialId)
		{
			return accessor.Get(productMaterialId);
		}
		
		public bool HasRows(string productMaterialId)
		{
			return accessor.HasRows(productMaterialId);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		public bool Exists(string id)
		{
			return accessor.Exists(id);
		}
		
		public Model.ProductMaterial GetById(string id)
		{
			return accessor.GetById(id);
		}		
		public bool ExistsExcept(Model.ProductMaterial e)
		{
			return accessor.ExistsExcept(e);
		}
		
		
		public bool HasRowsBefore(Model.ProductMaterial e)
		{
			return accessor.HasRowsBefore(e);
		}
		
		public bool HasRowsAfter(Model.ProductMaterial e)
		{
			return accessor.HasRowsAfter(e);
		}
		
		public Model.ProductMaterial GetFirst()
		{
			return accessor.GetFirst();
		}
		
		public Model.ProductMaterial GetLast()
		{
			return accessor.GetLast();
		}
		
		public Model.ProductMaterial GetPrev(Model.ProductMaterial e)
		{
			return accessor.GetPrev(e);
		}
		
		public Model.ProductMaterial GetNext(Model.ProductMaterial e)
		{
			return accessor.GetNext(e);
		}
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.ProductMaterial> Select()
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
		public IList<Model.ProductMaterial> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		public bool ExistsPrimary(string id)
		{
		    return accessor.ExistsPrimary(id);	
	    }
		
    }
}
