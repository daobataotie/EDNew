﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：PackingListHeaderAccessor.autogenerated.cs
// author: mayanjun
// create date：2018/11/11 17:33:41
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
    public partial class PackingListHeaderAccessor
    {
		public Model.PackingListHeader Get(string id)
		{
			return this.Get<Model.PackingListHeader>(id);
		}
		
		public void Insert(Model.PackingListHeader e)
		{
			this.Insert<Model.PackingListHeader>(e);
		}
		
		public void Update(Model.PackingListHeader e)
		{
			this.Update<Model.PackingListHeader>(e);
		}
		
		public IList<Model.PackingListHeader> Select()
		{
			return this.Select<Model.PackingListHeader>();
		}
		
		public IList<Model.PackingListHeader> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.PackingListHeader>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.PackingListHeader>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.PackingListHeader>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.PackingListHeader>();
		}
		public int Count()
		{
			return this.Count<Model.PackingListHeader>();
		}
		public bool HasRowsBefore(Model.PackingListHeader e)
		{
			return sqlmapper.QueryForObject<bool>("PackingListHeader.has_rows_before", e);
		}
		public bool HasRowsAfter(Model.PackingListHeader e)
		{
			return sqlmapper.QueryForObject<bool>("PackingListHeader.has_rows_after", e);
		}
		public Model.PackingListHeader GetFirst()
		{
			return sqlmapper.QueryForObject<Model.PackingListHeader>("PackingListHeader.get_first", null);
		}
		public Model.PackingListHeader GetLast()
		{
			return sqlmapper.QueryForObject<Model.PackingListHeader>("PackingListHeader.get_last", null);
		}
		public Model.PackingListHeader GetNext(Model.PackingListHeader e)
		{
			return sqlmapper.QueryForObject<Model.PackingListHeader>("PackingListHeader.get_next", e);
		}
		public Model.PackingListHeader GetPrev(Model.PackingListHeader e)
		{
			return sqlmapper.QueryForObject<Model.PackingListHeader>("PackingListHeader.get_prev", e);
		}
		

		public bool ExistsPrimary(string id)
		{			
			return sqlmapper.QueryForObject<bool>("PackingListHeader.existsPrimary", id);
		}
    }
}
