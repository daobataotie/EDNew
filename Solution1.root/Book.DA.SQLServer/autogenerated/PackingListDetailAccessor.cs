﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：PackingListDetailAccessor.autogenerated.cs
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
    public partial class PackingListDetailAccessor
    {
		public Model.PackingListDetail Get(string id)
		{
			return this.Get<Model.PackingListDetail>(id);
		}
		
		public void Insert(Model.PackingListDetail e)
		{
			this.Insert<Model.PackingListDetail>(e);
		}
		
		public void Update(Model.PackingListDetail e)
		{
			this.Update<Model.PackingListDetail>(e);
		}
		
		public IList<Model.PackingListDetail> Select()
		{
			return this.Select<Model.PackingListDetail>();
		}
		
		public IList<Model.PackingListDetail> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.PackingListDetail>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.PackingListDetail>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.PackingListDetail>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.PackingListDetail>();
		}
		public int Count()
		{
			return this.Count<Model.PackingListDetail>();
		}

		public bool ExistsPrimary(string id)
		{			
			return sqlmapper.QueryForObject<bool>("PackingListDetail.existsPrimary", id);
		}
    }
}
