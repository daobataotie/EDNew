﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：PCFlameRetardantDetailAccessor.autogenerated.cs
// author: mayanjun
// create date：2019/1/4 10:22:36
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
    public partial class PCFlameRetardantDetailAccessor
    {
		public Model.PCFlameRetardantDetail Get(string id)
		{
			return this.Get<Model.PCFlameRetardantDetail>(id);
		}
		
		public void Insert(Model.PCFlameRetardantDetail e)
		{
			this.Insert<Model.PCFlameRetardantDetail>(e);
		}
		
		public void Update(Model.PCFlameRetardantDetail e)
		{
			this.Update<Model.PCFlameRetardantDetail>(e);
		}
		
		public IList<Model.PCFlameRetardantDetail> Select()
		{
			return this.Select<Model.PCFlameRetardantDetail>();
		}
		
		public IList<Model.PCFlameRetardantDetail> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.PCFlameRetardantDetail>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.PCFlameRetardantDetail>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.PCFlameRetardantDetail>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.PCFlameRetardantDetail>();
		}
		public int Count()
		{
			return this.Count<Model.PCFlameRetardantDetail>();
		}

		public bool ExistsPrimary(string id)
		{			
			return sqlmapper.QueryForObject<bool>("PCFlameRetardantDetail.existsPrimary", id);
		}
    }
}
