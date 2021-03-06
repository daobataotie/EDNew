﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：BGHandbookRangeDetailAccessor.autogenerated.cs
// author: mayanjun
// create date：2013-4-17 15:13:05
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
    public partial class BGHandbookRangeDetailAccessor
    {
		public Model.BGHandbookRangeDetail Get(string id)
		{
			return this.Get<Model.BGHandbookRangeDetail>(id);
		}
		
		public void Insert(Model.BGHandbookRangeDetail e)
		{
			this.Insert<Model.BGHandbookRangeDetail>(e);
		}
		
		public void Update(Model.BGHandbookRangeDetail e)
		{
			this.Update<Model.BGHandbookRangeDetail>(e);
		}
		
		public IList<Model.BGHandbookRangeDetail> Select()
		{
			return this.Select<Model.BGHandbookRangeDetail>();
		}
		
		public IList<Model.BGHandbookRangeDetail> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.BGHandbookRangeDetail>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.BGHandbookRangeDetail>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.BGHandbookRangeDetail>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.BGHandbookRangeDetail>();
		}
		public int Count()
		{
			return this.Count<Model.BGHandbookRangeDetail>();
		}

		public bool Exists(string id)
		{
			return sqlmapper.QueryForObject<bool>("BGHandbookRangeDetail.exists", id);
		}
		
		public Model.BGHandbookRangeDetail GetById(string id)
		{
			return sqlmapper.QueryForObject<Model.BGHandbookRangeDetail>("BGHandbookRangeDetail.get_by_id", id);
		}
		
		public bool ExistsExcept(Model.BGHandbookRangeDetail e)
		{
			Hashtable paras = new Hashtable();
			paras.Add("newId", e.Id);
            paras.Add("oldId", Get(e.BGHandbookRangeDetailId)==null?null:Get(e.BGHandbookRangeDetailId).Id);
			return sqlmapper.QueryForObject<bool>("BGHandbookRangeDetail.existsexcept", paras);
		}
		
		
		
		public bool ExistsPrimary(string id)
		{			
			return sqlmapper.QueryForObject<bool>("BGHandbookRangeDetail.existsPrimary", id);
		}
    }
}
