﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：DepartmentAccessor.autogenerated.cs
// author: peidun
// create date：2010-4-22 11:01:39
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
    public partial class DepartmentAccessor
    {
		public Model.Department Get(string id)
		{
			return this.Get<Model.Department>(id);
		}
		
		public void Insert(Model.Department e)
		{
			this.Insert<Model.Department>(e);
		}
		
		public void Update(Model.Department e)
		{
			this.Update<Model.Department>(e);
		}
		
		public IList<Model.Department> Select()
		{
			return this.Select<Model.Department>();
		}
		
		public IList<Model.Department> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.Department>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.Department>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.Department>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.Department>();
		}
		public int Count()
		{
			return this.Count<Model.Department>();
		}
		public bool HasRowsBefore(Model.Department e)
		{
			return sqlmapper.QueryForObject<bool>("Department.has_rows_before", e);
		}
		public bool HasRowsAfter(Model.Department e)
		{
			return sqlmapper.QueryForObject<bool>("Department.has_rows_after", e);
		}
		public Model.Department GetFirst()
		{
			return sqlmapper.QueryForObject<Model.Department>("Department.get_first", null);
		}
		public Model.Department GetLast()
		{
			return sqlmapper.QueryForObject<Model.Department>("Department.get_last", null);
		}
		public Model.Department GetNext(Model.Department e)
		{
			return sqlmapper.QueryForObject<Model.Department>("Department.get_next", e);
		}
		public Model.Department GetPrev(Model.Department e)
		{
			return sqlmapper.QueryForObject<Model.Department>("Department.get_prev", e);
		}
		

		public bool Exists(string id)
		{
			return sqlmapper.QueryForObject<bool>("Department.exists", id);
		}
		
		public Model.Department GetById(string id)
		{
			return sqlmapper.QueryForObject<Model.Department>("Department.get_by_id", id);
		}
		
		public bool ExistsExcept(Model.Department e)
		{
			Hashtable paras = new Hashtable();
			paras.Add("newId", e.Id);
            paras.Add("oldId", Get(e.DepartmentId)==null?null:Get(e.DepartmentId).Id);
			return sqlmapper.QueryForObject<bool>("Department.existsexcept", paras);
		}
		
		
		
		public bool ExistsPrimary(string id)
		{			
			return sqlmapper.QueryForObject<bool>("Department.existsPrimary", id);
		}
    }
}
