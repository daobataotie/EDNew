﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：ShouldPayAccountAccessor.autogenerated.cs
// author: mayanjun
// create date：2014/8/11 19:47:22
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
    public partial class ShouldPayAccountAccessor
    {
		public Model.ShouldPayAccount Get(string id)
		{
			return this.Get<Model.ShouldPayAccount>(id);
		}
		
		public void Insert(Model.ShouldPayAccount e)
		{
			this.Insert<Model.ShouldPayAccount>(e);
		}
		
		public void Update(Model.ShouldPayAccount e)
		{
			this.Update<Model.ShouldPayAccount>(e);
		}
		
		public IList<Model.ShouldPayAccount> Select()
		{
			return this.Select<Model.ShouldPayAccount>();
		}
		
		public IList<Model.ShouldPayAccount> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.ShouldPayAccount>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.ShouldPayAccount>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.ShouldPayAccount>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.ShouldPayAccount>();
		}
		public int Count()
		{
			return this.Count<Model.ShouldPayAccount>();
		}
		public bool HasRowsBefore(Model.ShouldPayAccount e)
		{
			return sqlmapper.QueryForObject<bool>("ShouldPayAccount.has_rows_before", e);
		}
		public bool HasRowsAfter(Model.ShouldPayAccount e)
		{
			return sqlmapper.QueryForObject<bool>("ShouldPayAccount.has_rows_after", e);
		}
		public Model.ShouldPayAccount GetFirst()
		{
			return sqlmapper.QueryForObject<Model.ShouldPayAccount>("ShouldPayAccount.get_first", null);
		}
		public Model.ShouldPayAccount GetLast()
		{
			return sqlmapper.QueryForObject<Model.ShouldPayAccount>("ShouldPayAccount.get_last", null);
		}
		public Model.ShouldPayAccount GetNext(Model.ShouldPayAccount e)
		{
			return sqlmapper.QueryForObject<Model.ShouldPayAccount>("ShouldPayAccount.get_next", e);
		}
		public Model.ShouldPayAccount GetPrev(Model.ShouldPayAccount e)
		{
			return sqlmapper.QueryForObject<Model.ShouldPayAccount>("ShouldPayAccount.get_prev", e);
		}
		

		public bool ExistsPrimary(string id)
		{			
			return sqlmapper.QueryForObject<bool>("ShouldPayAccount.existsPrimary", id);
		}
    }
}
