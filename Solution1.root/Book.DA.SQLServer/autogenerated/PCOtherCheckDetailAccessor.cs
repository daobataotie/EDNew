﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：PCOtherCheckDetailAccessor.autogenerated.cs
// author: mayanjun
// create date：2011-11-21 17:15:36
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
    public partial class PCOtherCheckDetailAccessor
    {
		public Model.PCOtherCheckDetail Get(string id)
		{
			return this.Get<Model.PCOtherCheckDetail>(id);
		}
		
		public void Insert(Model.PCOtherCheckDetail e)
		{
			this.Insert<Model.PCOtherCheckDetail>(e);
		}
		
		public void Update(Model.PCOtherCheckDetail e)
		{
			this.Update<Model.PCOtherCheckDetail>(e);
		}
		
		public IList<Model.PCOtherCheckDetail> Select()
		{
			return this.Select<Model.PCOtherCheckDetail>();
		}
		
		public IList<Model.PCOtherCheckDetail> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.PCOtherCheckDetail>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.PCOtherCheckDetail>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.PCOtherCheckDetail>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.PCOtherCheckDetail>();
		}
		public int Count()
		{
			return this.Count<Model.PCOtherCheckDetail>();
		}

		public bool ExistsPrimary(string id)
		{			
			return sqlmapper.QueryForObject<bool>("PCOtherCheckDetail.existsPrimary", id);
		}
    }
}
