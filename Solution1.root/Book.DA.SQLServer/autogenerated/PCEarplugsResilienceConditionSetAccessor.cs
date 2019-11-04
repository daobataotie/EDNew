﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：PCEarplugsResilienceConditionSetAccessor.autogenerated.cs
// author: mayanjun
// create date：2019/6/15 19:29:48
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
    public partial class PCEarplugsResilienceConditionSetAccessor
    {
		public Model.PCEarplugsResilienceConditionSet Get(string id)
		{
			return this.Get<Model.PCEarplugsResilienceConditionSet>(id);
		}
		
		public void Insert(Model.PCEarplugsResilienceConditionSet e)
		{
			this.Insert<Model.PCEarplugsResilienceConditionSet>(e);
		}
		
		public void Update(Model.PCEarplugsResilienceConditionSet e)
		{
			this.Update<Model.PCEarplugsResilienceConditionSet>(e);
		}
		
		public IList<Model.PCEarplugsResilienceConditionSet> Select()
		{
			return this.Select<Model.PCEarplugsResilienceConditionSet>();
		}
		
		public IList<Model.PCEarplugsResilienceConditionSet> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.PCEarplugsResilienceConditionSet>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.PCEarplugsResilienceConditionSet>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.PCEarplugsResilienceConditionSet>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.PCEarplugsResilienceConditionSet>();
		}
		public int Count()
		{
			return this.Count<Model.PCEarplugsResilienceConditionSet>();
		}
		public bool HasRowsBefore(Model.PCEarplugsResilienceConditionSet e)
		{
			return sqlmapper.QueryForObject<bool>("PCEarplugsResilienceConditionSet.has_rows_before", e);
		}
		public bool HasRowsAfter(Model.PCEarplugsResilienceConditionSet e)
		{
			return sqlmapper.QueryForObject<bool>("PCEarplugsResilienceConditionSet.has_rows_after", e);
		}
		public Model.PCEarplugsResilienceConditionSet GetFirst()
		{
			return sqlmapper.QueryForObject<Model.PCEarplugsResilienceConditionSet>("PCEarplugsResilienceConditionSet.get_first", null);
		}
		public Model.PCEarplugsResilienceConditionSet GetLast()
		{
			return sqlmapper.QueryForObject<Model.PCEarplugsResilienceConditionSet>("PCEarplugsResilienceConditionSet.get_last", null);
		}
		public Model.PCEarplugsResilienceConditionSet GetNext(Model.PCEarplugsResilienceConditionSet e)
		{
			return sqlmapper.QueryForObject<Model.PCEarplugsResilienceConditionSet>("PCEarplugsResilienceConditionSet.get_next", e);
		}
		public Model.PCEarplugsResilienceConditionSet GetPrev(Model.PCEarplugsResilienceConditionSet e)
		{
			return sqlmapper.QueryForObject<Model.PCEarplugsResilienceConditionSet>("PCEarplugsResilienceConditionSet.get_prev", e);
		}
		

		public bool ExistsPrimary(string id)
		{			
			return sqlmapper.QueryForObject<bool>("PCEarplugsResilienceConditionSet.existsPrimary", id);
		}
    }
}
