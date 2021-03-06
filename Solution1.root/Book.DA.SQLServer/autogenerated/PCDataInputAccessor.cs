﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：PCDataInputAccessor.autogenerated.cs
// author: mayanjun
// create date：2015/1/18 下午 08:12:17
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
    public partial class PCDataInputAccessor
    {
		public Model.PCDataInput Get(string id)
		{
			return this.Get<Model.PCDataInput>(id);
		}
		
		public void Insert(Model.PCDataInput e)
		{
			this.Insert<Model.PCDataInput>(e);
		}
		
		public void Update(Model.PCDataInput e)
		{
			this.Update<Model.PCDataInput>(e);
		}
		
		public IList<Model.PCDataInput> Select()
		{
			return this.Select<Model.PCDataInput>();
		}
		
		public IList<Model.PCDataInput> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.PCDataInput>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.PCDataInput>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.PCDataInput>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.PCDataInput>();
		}
		public int Count()
		{
			return this.Count<Model.PCDataInput>();
		}
		public bool HasRowsBefore(Model.PCDataInput e)
		{
			return sqlmapper.QueryForObject<bool>("PCDataInput.has_rows_before", e);
		}
		public bool HasRowsAfter(Model.PCDataInput e)
		{
			return sqlmapper.QueryForObject<bool>("PCDataInput.has_rows_after", e);
		}
		public Model.PCDataInput GetFirst()
		{
			return sqlmapper.QueryForObject<Model.PCDataInput>("PCDataInput.get_first", null);
		}
		public Model.PCDataInput GetLast()
		{
			return sqlmapper.QueryForObject<Model.PCDataInput>("PCDataInput.get_last", null);
		}
		public Model.PCDataInput GetNext(Model.PCDataInput e)
		{
			return sqlmapper.QueryForObject<Model.PCDataInput>("PCDataInput.get_next", e);
		}
		public Model.PCDataInput GetPrev(Model.PCDataInput e)
		{
			return sqlmapper.QueryForObject<Model.PCDataInput>("PCDataInput.get_prev", e);
		}
		

		public bool ExistsPrimary(string id)
		{			
			return sqlmapper.QueryForObject<bool>("PCDataInput.existsPrimary", id);
		}
    }
}
