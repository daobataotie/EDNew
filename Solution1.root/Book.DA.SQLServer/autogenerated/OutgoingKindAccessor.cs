﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：OutgoingKindAccessor.autogenerated.cs
// author: peidun
// create date：2010-4-22 11:01:39
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
    public partial class OutgoingKindAccessor
    {
		public Model.OutgoingKind Get(string id)
		{
			return this.Get<Model.OutgoingKind>(id);
		}
		
		public void Insert(Model.OutgoingKind e)
		{
			this.Insert<Model.OutgoingKind>(e);
		}
		
		public void Update(Model.OutgoingKind e)
		{
			this.Update<Model.OutgoingKind>(e);
		}
		
		public IList<Model.OutgoingKind> Select()
		{
			return this.Select<Model.OutgoingKind>();
		}
		
		public IList<Model.OutgoingKind> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.OutgoingKind>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.OutgoingKind>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.OutgoingKind>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.OutgoingKind>();
		}
		public int Count()
		{
			return this.Count<Model.OutgoingKind>();
		}
		public bool HasRowsBefore(Model.OutgoingKind e)
		{
			return sqlmapper.QueryForObject<bool>("OutgoingKind.has_rows_before", e);
		}
		public bool HasRowsAfter(Model.OutgoingKind e)
		{
			return sqlmapper.QueryForObject<bool>("OutgoingKind.has_rows_after", e);
		}
		public Model.OutgoingKind GetFirst()
		{
			return sqlmapper.QueryForObject<Model.OutgoingKind>("OutgoingKind.get_first", null);
		}
		public Model.OutgoingKind GetLast()
		{
			return sqlmapper.QueryForObject<Model.OutgoingKind>("OutgoingKind.get_last", null);
		}
		public Model.OutgoingKind GetNext(Model.OutgoingKind e)
		{
			return sqlmapper.QueryForObject<Model.OutgoingKind>("OutgoingKind.get_next", e);
		}
		public Model.OutgoingKind GetPrev(Model.OutgoingKind e)
		{
			return sqlmapper.QueryForObject<Model.OutgoingKind>("OutgoingKind.get_prev", e);
		}
		

		public bool Exists(string id)
		{
			return sqlmapper.QueryForObject<bool>("OutgoingKind.exists", id);
		}
		
		public Model.OutgoingKind GetById(string id)
		{
			return sqlmapper.QueryForObject<Model.OutgoingKind>("OutgoingKind.get_by_id", id);
		}
		
		public bool ExistsExcept(Model.OutgoingKind e)
		{
			Hashtable paras = new Hashtable();
			paras.Add("newId", e.Id);
            paras.Add("oldId", Get(e.OutgoingKindId)==null?null:Get(e.OutgoingKindId).Id);
			return sqlmapper.QueryForObject<bool>("OutgoingKind.existsexcept", paras);
		}
		
		
		
		public bool ExistsPrimary(string id)
		{			
			return sqlmapper.QueryForObject<bool>("OutgoingKind.existsPrimary", id);
		}
    }
}
