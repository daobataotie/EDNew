﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：StockCheckDetailAccessor.autogenerated.cs
// author: mayanjun
// create date：2010-7-30 11:43:38
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
    public partial class StockCheckDetailAccessor
    {
		public Model.StockCheckDetail Get(string id)
		{
			return this.Get<Model.StockCheckDetail>(id);
		}
		
		public void Insert(Model.StockCheckDetail e)
		{
			this.Insert<Model.StockCheckDetail>(e);
		}
		
		public void Update(Model.StockCheckDetail e)
		{
			this.Update<Model.StockCheckDetail>(e);
		}
		
		public IList<Model.StockCheckDetail> Select()
		{
			return this.Select<Model.StockCheckDetail>();
		}
		
		public IList<Model.StockCheckDetail> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.StockCheckDetail>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.StockCheckDetail>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.StockCheckDetail>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.StockCheckDetail>();
		}
		public int Count()
		{
			return this.Count<Model.StockCheckDetail>();
		}

		public bool ExistsPrimary(string id)
		{			
			return sqlmapper.QueryForObject<bool>("StockCheckDetail.existsPrimary", id);
		}

    }
}
