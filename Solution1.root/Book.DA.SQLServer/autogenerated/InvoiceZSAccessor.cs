﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：InvoiceZSAccessor.autogenerated.cs
// author: peidun
// create date：2009-10-23 下午 09:47:43
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
    public partial class InvoiceZSAccessor
    {
		public Model.InvoiceZS Get(string id)
		{
			return this.Get<Model.InvoiceZS>(id);
		}
		
		public void Insert(Model.InvoiceZS e)
		{
			this.Insert<Model.InvoiceZS>(e);
		}
		
		public void Update(Model.InvoiceZS e)
		{
			this.Update<Model.InvoiceZS>(e);
		}
		
		public IList<Model.InvoiceZS> Select()
		{
			return this.Select<Model.InvoiceZS>();
		}
		
		public IList<Model.InvoiceZS> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.InvoiceZS>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.InvoiceZS>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.InvoiceZS>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.InvoiceZS>();
		}
		public int Count()
		{
			return this.Count<Model.InvoiceZS>();
		}
		public bool HasRowsBefore(Model.InvoiceZS e)
		{
			return sqlmapper.QueryForObject<bool>("InvoiceZS.has_rows_before", e);
		}
		public bool HasRowsAfter(Model.InvoiceZS e)
		{
			return sqlmapper.QueryForObject<bool>("InvoiceZS.has_rows_after", e);
		}
		public Model.InvoiceZS GetFirst()
		{
			return sqlmapper.QueryForObject<Model.InvoiceZS>("InvoiceZS.get_first", null);
		}
		public Model.InvoiceZS GetLast()
		{
			return sqlmapper.QueryForObject<Model.InvoiceZS>("InvoiceZS.get_last", null);
		}
		public Model.InvoiceZS GetNext(Model.InvoiceZS e)
		{
			return sqlmapper.QueryForObject<Model.InvoiceZS>("InvoiceZS.get_next", e);
		}
		public Model.InvoiceZS GetPrev(Model.InvoiceZS e)
		{
			return sqlmapper.QueryForObject<Model.InvoiceZS>("InvoiceZS.get_prev", e);
		}
		

    }
}
