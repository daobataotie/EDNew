﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：InvoiceZZDetailAccessor.autogenerated.cs
// author: peidun
// create date：2009-10-13 上午 11:45:04
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
    public partial class InvoiceZZDetailAccessor
    {
		public Model.InvoiceZZDetail Get(string id)
		{
			return this.Get<Model.InvoiceZZDetail>(id);
		}
		
		public void Insert(Model.InvoiceZZDetail e)
		{
			this.Insert<Model.InvoiceZZDetail>(e);
		}
		
		public void Update(Model.InvoiceZZDetail e)
		{
			this.Update<Model.InvoiceZZDetail>(e);
		}
		
		public IList<Model.InvoiceZZDetail> Select()
		{
			return this.Select<Model.InvoiceZZDetail>();
		}
		
		public IList<Model.InvoiceZZDetail> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.InvoiceZZDetail>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.InvoiceZZDetail>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.InvoiceZZDetail>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.InvoiceZZDetail>();
		}
		public int Count()
		{
			return this.Count<Model.InvoiceZZDetail>();
		}

    }
}
