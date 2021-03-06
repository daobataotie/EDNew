﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：PCEuropeOpticalAccessor.autogenerated.cs
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
    public partial class PCEuropeOpticalAccessor
    {
		public Model.PCEuropeOptical Get(string id)
		{
			return this.Get<Model.PCEuropeOptical>(id);
		}
		
		public void Insert(Model.PCEuropeOptical e)
		{
			this.Insert<Model.PCEuropeOptical>(e);
		}
		
		public void Update(Model.PCEuropeOptical e)
		{
			this.Update<Model.PCEuropeOptical>(e);
		}
		
		public IList<Model.PCEuropeOptical> Select()
		{
			return this.Select<Model.PCEuropeOptical>();
		}
		
		public IList<Model.PCEuropeOptical> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.PCEuropeOptical>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.PCEuropeOptical>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.PCEuropeOptical>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.PCEuropeOptical>();
		}
		public int Count()
		{
			return this.Count<Model.PCEuropeOptical>();
		}

		public bool ExistsPrimary(string id)
		{			
			return sqlmapper.QueryForObject<bool>("PCEuropeOptical.existsPrimary", id);
		}
    }
}
