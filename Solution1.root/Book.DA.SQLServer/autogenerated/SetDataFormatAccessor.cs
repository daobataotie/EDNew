﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：SetDataFormatAccessor.autogenerated.cs
// author: mayanjun
// create date：2012-4-5 15:34:50
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
    public partial class SetDataFormatAccessor
    {
		public Model.SetDataFormat Get(string id)
		{
			return this.Get<Model.SetDataFormat>(id);
		}
		
		public void Insert(Model.SetDataFormat e)
		{
			this.Insert<Model.SetDataFormat>(e);
		}
		
		public void Update(Model.SetDataFormat e)
		{
			this.Update<Model.SetDataFormat>(e);
		}
		
		public IList<Model.SetDataFormat> Select()
		{
			return this.Select<Model.SetDataFormat>();
		}
		
		public IList<Model.SetDataFormat> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.SetDataFormat>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.SetDataFormat>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.SetDataFormat>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.SetDataFormat>();
		}
		public int Count()
		{
			return this.Count<Model.SetDataFormat>();
		}
		public bool HasRowsBefore(Model.SetDataFormat e)
		{
			return sqlmapper.QueryForObject<bool>("SetDataFormat.has_rows_before", e);
		}
		public bool HasRowsAfter(Model.SetDataFormat e)
		{
			return sqlmapper.QueryForObject<bool>("SetDataFormat.has_rows_after", e);
		}
		public Model.SetDataFormat GetFirst()
		{
			return sqlmapper.QueryForObject<Model.SetDataFormat>("SetDataFormat.get_first", null);
		}
		public Model.SetDataFormat GetLast()
		{
			return sqlmapper.QueryForObject<Model.SetDataFormat>("SetDataFormat.get_last", null);
		}
		public Model.SetDataFormat GetNext(Model.SetDataFormat e)
		{
			return sqlmapper.QueryForObject<Model.SetDataFormat>("SetDataFormat.get_next", e);
		}
		public Model.SetDataFormat GetPrev(Model.SetDataFormat e)
		{
			return sqlmapper.QueryForObject<Model.SetDataFormat>("SetDataFormat.get_prev", e);
		}
		

		public bool ExistsPrimary(string id)
		{			
			return sqlmapper.QueryForObject<bool>("SetDataFormat.existsPrimary", id);
		}
    }
}
