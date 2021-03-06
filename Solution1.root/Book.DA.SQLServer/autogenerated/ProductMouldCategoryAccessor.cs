﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：ProductMouldCategoryAccessor.autogenerated.cs
// author: mayanjun
// create date：2013-3-7 14:17:19
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Book.DA.SQLServer
{
    public partial class ProductMouldCategoryAccessor
    {
		public Model.ProductMouldCategory Get(string id)
		{
			return this.Get<Model.ProductMouldCategory>(id);
		}
		
		public void Insert(Model.ProductMouldCategory e)
		{
			this.Insert<Model.ProductMouldCategory>(e);
		}
		
		public void Update(Model.ProductMouldCategory e)
		{
			this.Update<Model.ProductMouldCategory>(e);
		}
		
		public IList<Model.ProductMouldCategory> Select()
		{
			return this.Select<Model.ProductMouldCategory>();
		}
		
		public IList<Model.ProductMouldCategory> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.ProductMouldCategory>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.ProductMouldCategory>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.ProductMouldCategory>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.ProductMouldCategory>();
		}
		public int Count()
		{
			return this.Count<Model.ProductMouldCategory>();
		}
		public bool HasRowsBefore(Model.ProductMouldCategory e)
		{
			return sqlmapper.QueryForObject<bool>("ProductMouldCategory.has_rows_before", e);
		}
		public bool HasRowsAfter(Model.ProductMouldCategory e)
		{
			return sqlmapper.QueryForObject<bool>("ProductMouldCategory.has_rows_after", e);
		}
		public Model.ProductMouldCategory GetFirst()
		{
			return sqlmapper.QueryForObject<Model.ProductMouldCategory>("ProductMouldCategory.get_first", null);
		}
		public Model.ProductMouldCategory GetLast()
		{
			return sqlmapper.QueryForObject<Model.ProductMouldCategory>("ProductMouldCategory.get_last", null);
		}
		public Model.ProductMouldCategory GetNext(Model.ProductMouldCategory e)
		{
			return sqlmapper.QueryForObject<Model.ProductMouldCategory>("ProductMouldCategory.get_next", e);
		}
		public Model.ProductMouldCategory GetPrev(Model.ProductMouldCategory e)
		{
			return sqlmapper.QueryForObject<Model.ProductMouldCategory>("ProductMouldCategory.get_prev", e);
		}
		

		public bool Exists(string id)
		{
			return sqlmapper.QueryForObject<bool>("ProductMouldCategory.exists", id);
		}
		
		public Model.ProductMouldCategory GetById(string id)
		{
			return sqlmapper.QueryForObject<Model.ProductMouldCategory>("ProductMouldCategory.get_by_id", id);
		}
		
		public bool ExistsExcept(Model.ProductMouldCategory e)
		{
			Hashtable paras = new Hashtable();
			paras.Add("newId", e.Id);
            paras.Add("oldId", Get(e.ProductMouldCategoryId)==null?null:Get(e.ProductMouldCategoryId).Id);
			return sqlmapper.QueryForObject<bool>("ProductMouldCategory.existsexcept", paras);
		}
		
		
		
		public bool ExistsPrimary(string id)
		{			
			return sqlmapper.QueryForObject<bool>("ProductMouldCategory.existsPrimary", id);
		}
    }
}
