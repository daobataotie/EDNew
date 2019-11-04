﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：PCPGOnlineCheckAccessor.autogenerated.cs
// author: mayanjun
// create date：2011-12-6 14:19:08
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
    public partial class PCPGOnlineCheckAccessor
    {
		public Model.PCPGOnlineCheck Get(string id)
		{
			return this.Get<Model.PCPGOnlineCheck>(id);
		}
		
		public void Insert(Model.PCPGOnlineCheck e)
		{
			this.Insert<Model.PCPGOnlineCheck>(e);
		}
		
		public void Update(Model.PCPGOnlineCheck e)
		{
			this.Update<Model.PCPGOnlineCheck>(e);
		}
		
		public IList<Model.PCPGOnlineCheck> Select()
		{
			return this.Select<Model.PCPGOnlineCheck>();
		}
		
		public IList<Model.PCPGOnlineCheck> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.PCPGOnlineCheck>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.PCPGOnlineCheck>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.PCPGOnlineCheck>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.PCPGOnlineCheck>();
		}
		public int Count()
		{
			return this.Count<Model.PCPGOnlineCheck>();
		}
		public bool HasRowsBefore(Model.PCPGOnlineCheck e)
		{
			return sqlmapper.QueryForObject<bool>("PCPGOnlineCheck.has_rows_before", e);
		}
		public bool HasRowsAfter(Model.PCPGOnlineCheck e)
		{
			return sqlmapper.QueryForObject<bool>("PCPGOnlineCheck.has_rows_after", e);
		}
		public Model.PCPGOnlineCheck GetFirst()
		{
			return sqlmapper.QueryForObject<Model.PCPGOnlineCheck>("PCPGOnlineCheck.get_first", null);
		}
		public Model.PCPGOnlineCheck GetLast()
		{
			return sqlmapper.QueryForObject<Model.PCPGOnlineCheck>("PCPGOnlineCheck.get_last", null);
		}
		public Model.PCPGOnlineCheck GetNext(Model.PCPGOnlineCheck e)
		{
			return sqlmapper.QueryForObject<Model.PCPGOnlineCheck>("PCPGOnlineCheck.get_next", e);
		}
		public Model.PCPGOnlineCheck GetPrev(Model.PCPGOnlineCheck e)
		{
			return sqlmapper.QueryForObject<Model.PCPGOnlineCheck>("PCPGOnlineCheck.get_prev", e);
		}
		

		public bool ExistsPrimary(string id)
		{			
			return sqlmapper.QueryForObject<bool>("PCPGOnlineCheck.existsPrimary", id);
		}
    }
}
