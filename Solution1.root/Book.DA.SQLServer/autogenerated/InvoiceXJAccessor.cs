﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：InvoiceXJAccessor.autogenerated.cs
// author: peidun
// create date：2009-10-28 16:07:30
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
    public partial class InvoiceXJAccessor
    {
		public Model.InvoiceXJ Get(string id)
		{
			return this.Get<Model.InvoiceXJ>(id);
		}
		
		public void Insert(Model.InvoiceXJ e)
		{
			this.Insert<Model.InvoiceXJ>(e);
		}
		
		public void Update(Model.InvoiceXJ e)
		{
			this.Update<Model.InvoiceXJ>(e);
		}
		
		public IList<Model.InvoiceXJ> Select()
		{
			return this.Select<Model.InvoiceXJ>();
		}
		
		public IList<Model.InvoiceXJ> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.InvoiceXJ>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.InvoiceXJ>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.InvoiceXJ>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.InvoiceXJ>();
		}
		public int Count()
		{
			return this.Count<Model.InvoiceXJ>();
		}
		public bool HasRowsBefore(Model.InvoiceXJ e)
		{
			return sqlmapper.QueryForObject<bool>("InvoiceXJ.has_rows_before", e);
		}
		public bool HasRowsAfter(Model.InvoiceXJ e)
		{
			return sqlmapper.QueryForObject<bool>("InvoiceXJ.has_rows_after", e);
		}
		public Model.InvoiceXJ GetFirst()
		{
			return sqlmapper.QueryForObject<Model.InvoiceXJ>("InvoiceXJ.get_first", null);
		}
		public Model.InvoiceXJ GetLast()
		{
			return sqlmapper.QueryForObject<Model.InvoiceXJ>("InvoiceXJ.get_last", null);
		}
		public Model.InvoiceXJ GetNext(Model.InvoiceXJ e)
		{
			return sqlmapper.QueryForObject<Model.InvoiceXJ>("InvoiceXJ.get_next", e);
		}
		public Model.InvoiceXJ GetPrev(Model.InvoiceXJ e)
		{
			return sqlmapper.QueryForObject<Model.InvoiceXJ>("InvoiceXJ.get_prev", e);
		}
		

    }
}
