﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：AcbeginAccountPayableDetailAccessor.autogenerated.cs
// author: mayanjun
// create date：2011-6-9 14:42:09
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
    public partial class AcbeginAccountPayableDetailAccessor
    {
		public Model.AcbeginAccountPayableDetail Get(string id)
		{
			return this.Get<Model.AcbeginAccountPayableDetail>(id);
		}
		
		public void Insert(Model.AcbeginAccountPayableDetail e)
		{
			this.Insert<Model.AcbeginAccountPayableDetail>(e);
		}
		
		public void Update(Model.AcbeginAccountPayableDetail e)
		{
			this.Update<Model.AcbeginAccountPayableDetail>(e);
		}
		
		public IList<Model.AcbeginAccountPayableDetail> Select()
		{
			return this.Select<Model.AcbeginAccountPayableDetail>();
		}
		
		public IList<Model.AcbeginAccountPayableDetail> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.AcbeginAccountPayableDetail>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.AcbeginAccountPayableDetail>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.AcbeginAccountPayableDetail>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.AcbeginAccountPayableDetail>();
		}
		public int Count()
		{
			return this.Count<Model.AcbeginAccountPayableDetail>();
		}

		public bool ExistsPrimary(string id)
		{			
			return sqlmapper.QueryForObject<bool>("AcbeginAccountPayableDetail.existsPrimary", id);
		}
    }
}
