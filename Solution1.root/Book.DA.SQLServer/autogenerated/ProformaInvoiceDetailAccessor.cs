﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：ProformaInvoiceDetailAccessor.autogenerated.cs
// author: mayanjun
// create date：2019/3/13 20:30:29
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
    public partial class ProformaInvoiceDetailAccessor
    {
		public Model.ProformaInvoiceDetail Get(string id)
		{
			return this.Get<Model.ProformaInvoiceDetail>(id);
		}
		
		public void Insert(Model.ProformaInvoiceDetail e)
		{
			this.Insert<Model.ProformaInvoiceDetail>(e);
		}
		
		public void Update(Model.ProformaInvoiceDetail e)
		{
			this.Update<Model.ProformaInvoiceDetail>(e);
		}
		
		public IList<Model.ProformaInvoiceDetail> Select()
		{
			return this.Select<Model.ProformaInvoiceDetail>();
		}
		
		public IList<Model.ProformaInvoiceDetail> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.ProformaInvoiceDetail>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.ProformaInvoiceDetail>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.ProformaInvoiceDetail>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.ProformaInvoiceDetail>();
		}
		public int Count()
		{
			return this.Count<Model.ProformaInvoiceDetail>();
		}

		public bool ExistsPrimary(string id)
		{			
			return sqlmapper.QueryForObject<bool>("ProformaInvoiceDetail.existsPrimary", id);
		}
    }
}
