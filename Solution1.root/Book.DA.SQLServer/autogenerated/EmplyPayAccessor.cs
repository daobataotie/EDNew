﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：EmplyPayAccessor.autogenerated.cs
// author: peidun
// create date：2010-3-24 11:21:42
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
    public partial class EmplyPayAccessor
    {
		public Model.EmplyPay Get(string id)
		{
			return this.Get<Model.EmplyPay>(id);
		}
		
		public void Insert(Model.EmplyPay e)
		{
			this.Insert<Model.EmplyPay>(e);
		}
		
		public void Update(Model.EmplyPay e)
		{
			this.Update<Model.EmplyPay>(e);
		}
		
		public IList<Model.EmplyPay> Select()
		{
			return this.Select<Model.EmplyPay>();
		}
		
		public IList<Model.EmplyPay> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.EmplyPay>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.EmplyPay>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.EmplyPay>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.EmplyPay>();
		}
		public int Count()
		{
			return this.Count<Model.EmplyPay>();
		}
		public bool HasRowsBefore(Model.EmplyPay e)
		{
			return sqlmapper.QueryForObject<bool>("EmplyPay.has_rows_before", e);
		}
		public bool HasRowsAfter(Model.EmplyPay e)
		{
			return sqlmapper.QueryForObject<bool>("EmplyPay.has_rows_after", e);
		}
		public Model.EmplyPay GetFirst()
		{
			return sqlmapper.QueryForObject<Model.EmplyPay>("EmplyPay.get_first", null);
		}
		public Model.EmplyPay GetLast()
		{
			return sqlmapper.QueryForObject<Model.EmplyPay>("EmplyPay.get_last", null);
		}
		public Model.EmplyPay GetNext(Model.EmplyPay e)
		{
			return sqlmapper.QueryForObject<Model.EmplyPay>("EmplyPay.get_next", e);
		}
		public Model.EmplyPay GetPrev(Model.EmplyPay e)
		{
			return sqlmapper.QueryForObject<Model.EmplyPay>("EmplyPay.get_prev", e);
		}
		

    }
}
