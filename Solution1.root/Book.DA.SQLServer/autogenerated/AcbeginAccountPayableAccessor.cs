﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：AcbeginAccountPayableAccessor.autogenerated.cs
// author: mayanjun
// create date：2011-6-9 16:24:48
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
    public partial class AcbeginAccountPayableAccessor
    {
		public Model.AcbeginAccountPayable Get(string id)
		{
			return this.Get<Model.AcbeginAccountPayable>(id);
		}
		
		public void Insert(Model.AcbeginAccountPayable e)
		{
			this.Insert<Model.AcbeginAccountPayable>(e);
		}
		
		public void Update(Model.AcbeginAccountPayable e)
		{
			this.Update<Model.AcbeginAccountPayable>(e);
		}
		
		public IList<Model.AcbeginAccountPayable> Select()
		{
			return this.Select<Model.AcbeginAccountPayable>();
		}
		
		public IList<Model.AcbeginAccountPayable> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.AcbeginAccountPayable>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.AcbeginAccountPayable>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.AcbeginAccountPayable>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.AcbeginAccountPayable>();
		}
		public int Count()
		{
			return this.Count<Model.AcbeginAccountPayable>();
		}
		public bool HasRowsBefore(Model.AcbeginAccountPayable e)
		{
			return sqlmapper.QueryForObject<bool>("AcbeginAccountPayable.has_rows_before", e);
		}
		public bool HasRowsAfter(Model.AcbeginAccountPayable e)
		{
			return sqlmapper.QueryForObject<bool>("AcbeginAccountPayable.has_rows_after", e);
		}
		public Model.AcbeginAccountPayable GetFirst()
		{
			return sqlmapper.QueryForObject<Model.AcbeginAccountPayable>("AcbeginAccountPayable.get_first", null);
		}
		public Model.AcbeginAccountPayable GetLast()
		{
			return sqlmapper.QueryForObject<Model.AcbeginAccountPayable>("AcbeginAccountPayable.get_last", null);
		}
		public Model.AcbeginAccountPayable GetNext(Model.AcbeginAccountPayable e)
		{
			return sqlmapper.QueryForObject<Model.AcbeginAccountPayable>("AcbeginAccountPayable.get_next", e);
		}
		public Model.AcbeginAccountPayable GetPrev(Model.AcbeginAccountPayable e)
		{
			return sqlmapper.QueryForObject<Model.AcbeginAccountPayable>("AcbeginAccountPayable.get_prev", e);
		}
		

		public bool ExistsPrimary(string id)
		{			
			return sqlmapper.QueryForObject<bool>("AcbeginAccountPayable.existsPrimary", id);
		}
    }
}
