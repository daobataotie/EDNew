﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：PronotedetailsMaterialAccessor.autogenerated.cs
// author: mayanjun
// create date：2010-9-15 10:11:08
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
    public partial class PronotedetailsMaterialAccessor
    {
		public Model.PronotedetailsMaterial Get(string id)
		{
			return this.Get<Model.PronotedetailsMaterial>(id);
		}
		
		public void Insert(Model.PronotedetailsMaterial e)
		{
			this.Insert<Model.PronotedetailsMaterial>(e);
		}
		
		public void Update(Model.PronotedetailsMaterial e)
		{
			this.Update<Model.PronotedetailsMaterial>(e);
		}
		
		public IList<Model.PronotedetailsMaterial> Select()
		{
			return this.Select<Model.PronotedetailsMaterial>();
		}
		
		public IList<Model.PronotedetailsMaterial> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.PronotedetailsMaterial>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.PronotedetailsMaterial>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.PronotedetailsMaterial>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.PronotedetailsMaterial>();
		}
		public int Count()
		{
			return this.Count<Model.PronotedetailsMaterial>();
		}

		public bool ExistsPrimary(string id)
		{			
			return sqlmapper.QueryForObject<bool>("PronotedetailsMaterial.existsPrimary", id);
		}
    }
}
