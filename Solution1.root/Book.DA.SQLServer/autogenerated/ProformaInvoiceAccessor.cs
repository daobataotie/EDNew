﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：ProformaInvoiceAccessor.autogenerated.cs
// author: mayanjun
// create date：2019/3/13 18:44:59
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
    public partial class ProformaInvoiceAccessor
    {
		public Model.ProformaInvoice Get(string id)
		{
			return this.Get<Model.ProformaInvoice>(id);
		}
		
		public void Insert(Model.ProformaInvoice e)
		{
			this.Insert<Model.ProformaInvoice>(e);
		}
		
		public void Update(Model.ProformaInvoice e)
		{
			this.Update<Model.ProformaInvoice>(e);
		}
		
		public IList<Model.ProformaInvoice> Select()
		{
			return this.Select<Model.ProformaInvoice>();
		}
		
		public IList<Model.ProformaInvoice> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.ProformaInvoice>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.ProformaInvoice>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.ProformaInvoice>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.ProformaInvoice>();
		}
		public int Count()
		{
			return this.Count<Model.ProformaInvoice>();
		}
		public bool HasRowsBefore(Model.ProformaInvoice e)
		{
			return sqlmapper.QueryForObject<bool>("ProformaInvoice.has_rows_before", e);
		}
		public bool HasRowsAfter(Model.ProformaInvoice e)
		{
			return sqlmapper.QueryForObject<bool>("ProformaInvoice.has_rows_after", e);
		}
		public Model.ProformaInvoice GetFirst()
		{
			return sqlmapper.QueryForObject<Model.ProformaInvoice>("ProformaInvoice.get_first", null);
		}
		public Model.ProformaInvoice GetLast()
		{
			return sqlmapper.QueryForObject<Model.ProformaInvoice>("ProformaInvoice.get_last", null);
		}
		public Model.ProformaInvoice GetNext(Model.ProformaInvoice e)
		{
			return sqlmapper.QueryForObject<Model.ProformaInvoice>("ProformaInvoice.get_next", e);
		}
		public Model.ProformaInvoice GetPrev(Model.ProformaInvoice e)
		{
			return sqlmapper.QueryForObject<Model.ProformaInvoice>("ProformaInvoice.get_prev", e);
		}
		

		public bool ExistsPrimary(string id)
		{			
			return sqlmapper.QueryForObject<bool>("ProformaInvoice.existsPrimary", id);
		}
    }
}
