﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：PCHazeAccessor.autogenerated.cs
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
    public partial class PCHazeAccessor
    {
		public Model.PCHaze Get(string id)
		{
			return this.Get<Model.PCHaze>(id);
		}
		
		public void Insert(Model.PCHaze e)
		{
			this.Insert<Model.PCHaze>(e);
		}
		
		public void Update(Model.PCHaze e)
		{
			this.Update<Model.PCHaze>(e);
		}
		
		public IList<Model.PCHaze> Select()
		{
			return this.Select<Model.PCHaze>();
		}
		
		public IList<Model.PCHaze> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.PCHaze>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.PCHaze>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.PCHaze>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.PCHaze>();
		}
		public int Count()
		{
			return this.Count<Model.PCHaze>();
		}

		public bool ExistsPrimary(string id)
		{			
			return sqlmapper.QueryForObject<bool>("PCHaze.existsPrimary", id);
		}
    }
}
