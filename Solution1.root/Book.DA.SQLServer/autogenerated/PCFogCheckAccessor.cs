﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：PCFogCheckAccessor.autogenerated.cs
// author: mayanjun
// create date：2012-3-16 17:42:23
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
    public partial class PCFogCheckAccessor
    {
		public Model.PCFogCheck Get(string id)
		{
			return this.Get<Model.PCFogCheck>(id);
		}
		
		public void Insert(Model.PCFogCheck e)
		{
			this.Insert<Model.PCFogCheck>(e);
		}
		
		public void Update(Model.PCFogCheck e)
		{
			this.Update<Model.PCFogCheck>(e);
		}
		
		public IList<Model.PCFogCheck> Select()
		{
			return this.Select<Model.PCFogCheck>();
		}
		
		public IList<Model.PCFogCheck> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.PCFogCheck>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.PCFogCheck>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.PCFogCheck>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.PCFogCheck>();
		}
		public int Count()
		{
			return this.Count<Model.PCFogCheck>();
		}
		public bool HasRowsBefore(Model.PCFogCheck e)
		{
			return sqlmapper.QueryForObject<bool>("PCFogCheck.has_rows_before", e);
		}
		public bool HasRowsAfter(Model.PCFogCheck e)
		{
			return sqlmapper.QueryForObject<bool>("PCFogCheck.has_rows_after", e);
		}
		public Model.PCFogCheck GetFirst()
		{
			return sqlmapper.QueryForObject<Model.PCFogCheck>("PCFogCheck.get_first", null);
		}
		public Model.PCFogCheck GetLast()
		{
			return sqlmapper.QueryForObject<Model.PCFogCheck>("PCFogCheck.get_last", null);
		}
		public Model.PCFogCheck GetNext(Model.PCFogCheck e)
		{
			return sqlmapper.QueryForObject<Model.PCFogCheck>("PCFogCheck.get_next", e);
		}
		public Model.PCFogCheck GetPrev(Model.PCFogCheck e)
		{
			return sqlmapper.QueryForObject<Model.PCFogCheck>("PCFogCheck.get_prev", e);
		}
		

		public bool ExistsPrimary(string id)
		{			
			return sqlmapper.QueryForObject<bool>("PCFogCheck.existsPrimary", id);
		}
    }
}
