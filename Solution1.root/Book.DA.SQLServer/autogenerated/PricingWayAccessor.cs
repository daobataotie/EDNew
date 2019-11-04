﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：PricingWayAccessor.autogenerated.cs
// author: peidun
// create date：2009-12-9 10:27:05
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
    public partial class PricingWayAccessor
    {
		public Model.PricingWay Get(string id)
		{
			return this.Get<Model.PricingWay>(id);
		}
		
		public void Insert(Model.PricingWay e)
		{
			this.Insert<Model.PricingWay>(e);
		}
		
		public void Update(Model.PricingWay e)
		{
			this.Update<Model.PricingWay>(e);
		}
		
		public IList<Model.PricingWay> Select()
		{
			return this.Select<Model.PricingWay>();
		}
		
		public IList<Model.PricingWay> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.PricingWay>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.PricingWay>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.PricingWay>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.PricingWay>();
		}
		public int Count()
		{
			return this.Count<Model.PricingWay>();
		}
		public bool HasRowsBefore(Model.PricingWay e)
		{
			return sqlmapper.QueryForObject<bool>("PricingWay.has_rows_before", e);
		}
		public bool HasRowsAfter(Model.PricingWay e)
		{
			return sqlmapper.QueryForObject<bool>("PricingWay.has_rows_after", e);
		}
		public Model.PricingWay GetFirst()
		{
			return sqlmapper.QueryForObject<Model.PricingWay>("PricingWay.get_first", null);
		}
		public Model.PricingWay GetLast()
		{
			return sqlmapper.QueryForObject<Model.PricingWay>("PricingWay.get_last", null);
		}
		public Model.PricingWay GetNext(Model.PricingWay e)
		{
			return sqlmapper.QueryForObject<Model.PricingWay>("PricingWay.get_next", e);
		}
		public Model.PricingWay GetPrev(Model.PricingWay e)
		{
			return sqlmapper.QueryForObject<Model.PricingWay>("PricingWay.get_prev", e);
		}
		

    }
}
