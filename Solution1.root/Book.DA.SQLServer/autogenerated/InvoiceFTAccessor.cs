﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：InvoiceFTAccessor.autogenerated.cs
// author: peidun
// create date：2009-10-13 上午 11:45:03
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
    public partial class InvoiceFTAccessor
    {
		public Model.InvoiceFT Get(string id)
		{
			return this.Get<Model.InvoiceFT>(id);
		}
		
		public void Insert(Model.InvoiceFT e)
		{
			this.Insert<Model.InvoiceFT>(e);
		}
		
		public void Update(Model.InvoiceFT e)
		{
			this.Update<Model.InvoiceFT>(e);
		}
		
		public IList<Model.InvoiceFT> Select()
		{
			return this.Select<Model.InvoiceFT>();
		}
		
		public IList<Model.InvoiceFT> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.InvoiceFT>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.InvoiceFT>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.InvoiceFT>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.InvoiceFT>();
		}
		public int Count()
		{
			return this.Count<Model.InvoiceFT>();
		}
		public bool HasRowsBefore(Model.InvoiceFT e)
		{
			return sqlmapper.QueryForObject<bool>("InvoiceFT.has_rows_before", e);
		}
		public bool HasRowsAfter(Model.InvoiceFT e)
		{
			return sqlmapper.QueryForObject<bool>("InvoiceFT.has_rows_after", e);
		}
		public Model.InvoiceFT GetFirst()
		{
			return sqlmapper.QueryForObject<Model.InvoiceFT>("InvoiceFT.get_first", null);
		}
		public Model.InvoiceFT GetLast()
		{
			return sqlmapper.QueryForObject<Model.InvoiceFT>("InvoiceFT.get_last", null);
		}
		public Model.InvoiceFT GetNext(Model.InvoiceFT e)
		{
			return sqlmapper.QueryForObject<Model.InvoiceFT>("InvoiceFT.get_next", e);
		}
		public Model.InvoiceFT GetPrev(Model.InvoiceFT e)
		{
			return sqlmapper.QueryForObject<Model.InvoiceFT>("InvoiceFT.get_prev", e);
		}
		

    }
}
