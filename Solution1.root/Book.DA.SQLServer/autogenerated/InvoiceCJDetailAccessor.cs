﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：InvoiceCJDetailAccessor.autogenerated.cs
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
    public partial class InvoiceCJDetailAccessor
    {
		public Model.InvoiceCJDetail Get(string id)
		{
			return this.Get<Model.InvoiceCJDetail>(id);
		}
		
		public void Insert(Model.InvoiceCJDetail e)
		{
			this.Insert<Model.InvoiceCJDetail>(e);
		}
		
		public void Update(Model.InvoiceCJDetail e)
		{
			this.Update<Model.InvoiceCJDetail>(e);
		}
		
		public IList<Model.InvoiceCJDetail> Select()
		{
			return this.Select<Model.InvoiceCJDetail>();
		}
		
		public IList<Model.InvoiceCJDetail> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.InvoiceCJDetail>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.InvoiceCJDetail>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.InvoiceCJDetail>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.InvoiceCJDetail>();
		}
		public int Count()
		{
			return this.Count<Model.InvoiceCJDetail>();
		}

    }
}
