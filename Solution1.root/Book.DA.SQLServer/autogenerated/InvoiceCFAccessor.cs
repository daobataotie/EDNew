﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：InvoiceCFAccessor.autogenerated.cs
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
    public partial class InvoiceCFAccessor
    {
		public Model.InvoiceCF Get(string id)
		{
			return this.Get<Model.InvoiceCF>(id);
		}
		
		public void Insert(Model.InvoiceCF e)
		{
			this.Insert<Model.InvoiceCF>(e);
		}
		
		public void Update(Model.InvoiceCF e)
		{
			this.Update<Model.InvoiceCF>(e);
		}
		
		public IList<Model.InvoiceCF> Select()
		{
			return this.Select<Model.InvoiceCF>();
		}
		
		public IList<Model.InvoiceCF> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.InvoiceCF>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.InvoiceCF>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.InvoiceCF>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.InvoiceCF>();
		}
		public int Count()
		{
			return this.Count<Model.InvoiceCF>();
		}
		public bool HasRowsBefore(Model.InvoiceCF e)
		{
			return sqlmapper.QueryForObject<bool>("InvoiceCF.has_rows_before", e);
		}
		public bool HasRowsAfter(Model.InvoiceCF e)
		{
			return sqlmapper.QueryForObject<bool>("InvoiceCF.has_rows_after", e);
		}
		public Model.InvoiceCF GetFirst()
		{
			return sqlmapper.QueryForObject<Model.InvoiceCF>("InvoiceCF.get_first", null);
		}
		public Model.InvoiceCF GetLast()
		{
			return sqlmapper.QueryForObject<Model.InvoiceCF>("InvoiceCF.get_last", null);
		}
		public Model.InvoiceCF GetNext(Model.InvoiceCF e)
		{
			return sqlmapper.QueryForObject<Model.InvoiceCF>("InvoiceCF.get_next", e);
		}
		public Model.InvoiceCF GetPrev(Model.InvoiceCF e)
		{
			return sqlmapper.QueryForObject<Model.InvoiceCF>("InvoiceCF.get_prev", e);
		}
		

    }
}
