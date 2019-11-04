﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：PCEarplugsStayWireCheckAccessor.autogenerated.cs
// author: mayanjun
// create date：2019/5/14 09:57:06
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
    public partial class PCEarplugsStayWireCheckAccessor
    {
		public Model.PCEarplugsStayWireCheck Get(string id)
		{
			return this.Get<Model.PCEarplugsStayWireCheck>(id);
		}
		
		public void Insert(Model.PCEarplugsStayWireCheck e)
		{
			this.Insert<Model.PCEarplugsStayWireCheck>(e);
		}
		
		public void Update(Model.PCEarplugsStayWireCheck e)
		{
			this.Update<Model.PCEarplugsStayWireCheck>(e);
		}
		
		public IList<Model.PCEarplugsStayWireCheck> Select()
		{
			return this.Select<Model.PCEarplugsStayWireCheck>();
		}
		
		public IList<Model.PCEarplugsStayWireCheck> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.PCEarplugsStayWireCheck>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.PCEarplugsStayWireCheck>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.PCEarplugsStayWireCheck>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.PCEarplugsStayWireCheck>();
		}
		public int Count()
		{
			return this.Count<Model.PCEarplugsStayWireCheck>();
		}
		public bool HasRowsBefore(Model.PCEarplugsStayWireCheck e)
		{
			return sqlmapper.QueryForObject<bool>("PCEarplugsStayWireCheck.has_rows_before", e);
		}
		public bool HasRowsAfter(Model.PCEarplugsStayWireCheck e)
		{
			return sqlmapper.QueryForObject<bool>("PCEarplugsStayWireCheck.has_rows_after", e);
		}
		public Model.PCEarplugsStayWireCheck GetFirst()
		{
			return sqlmapper.QueryForObject<Model.PCEarplugsStayWireCheck>("PCEarplugsStayWireCheck.get_first", null);
		}
		public Model.PCEarplugsStayWireCheck GetLast()
		{
			return sqlmapper.QueryForObject<Model.PCEarplugsStayWireCheck>("PCEarplugsStayWireCheck.get_last", null);
		}
		public Model.PCEarplugsStayWireCheck GetNext(Model.PCEarplugsStayWireCheck e)
		{
			return sqlmapper.QueryForObject<Model.PCEarplugsStayWireCheck>("PCEarplugsStayWireCheck.get_next", e);
		}
		public Model.PCEarplugsStayWireCheck GetPrev(Model.PCEarplugsStayWireCheck e)
		{
			return sqlmapper.QueryForObject<Model.PCEarplugsStayWireCheck>("PCEarplugsStayWireCheck.get_prev", e);
		}
		

		public bool ExistsPrimary(string id)
		{			
			return sqlmapper.QueryForObject<bool>("PCEarplugsStayWireCheck.existsPrimary", id);
		}
    }
}
