﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：PCMouldOnlineCheckDetailAccessor.autogenerated.cs
// author: mayanjun
// create date：2015/4/13 上午 10:11:44
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
    public partial class PCMouldOnlineCheckDetailAccessor
    {
		public Model.PCMouldOnlineCheckDetail Get(string id)
		{
			return this.Get<Model.PCMouldOnlineCheckDetail>(id);
		}
		
		public void Insert(Model.PCMouldOnlineCheckDetail e)
		{
			this.Insert<Model.PCMouldOnlineCheckDetail>(e);
		}
		
		public void Update(Model.PCMouldOnlineCheckDetail e)
		{
			this.Update<Model.PCMouldOnlineCheckDetail>(e);
		}
		
		public IList<Model.PCMouldOnlineCheckDetail> Select()
		{
			return this.Select<Model.PCMouldOnlineCheckDetail>();
		}
		
		public IList<Model.PCMouldOnlineCheckDetail> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.PCMouldOnlineCheckDetail>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.PCMouldOnlineCheckDetail>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.PCMouldOnlineCheckDetail>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.PCMouldOnlineCheckDetail>();
		}
		public int Count()
		{
			return this.Count<Model.PCMouldOnlineCheckDetail>();
		}

		public bool ExistsPrimary(string id)
		{			
			return sqlmapper.QueryForObject<bool>("PCMouldOnlineCheckDetail.existsPrimary", id);
		}
    }
}
