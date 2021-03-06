﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：ThicknessTestDetailsAccessor.autogenerated.cs
// author: mayanjun
// create date：2012-4-24 10:33:14
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
    public partial class ThicknessTestDetailsAccessor
    {
		public Model.ThicknessTestDetails Get(string id)
		{
			return this.Get<Model.ThicknessTestDetails>(id);
		}
		
		public void Insert(Model.ThicknessTestDetails e)
		{
			this.Insert<Model.ThicknessTestDetails>(e);
		}
		
		public void Update(Model.ThicknessTestDetails e)
		{
			this.Update<Model.ThicknessTestDetails>(e);
		}
		
		public IList<Model.ThicknessTestDetails> Select()
		{
			return this.Select<Model.ThicknessTestDetails>();
		}
		
		public IList<Model.ThicknessTestDetails> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.ThicknessTestDetails>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.ThicknessTestDetails>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.ThicknessTestDetails>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.ThicknessTestDetails>();
		}
		public int Count()
		{
			return this.Count<Model.ThicknessTestDetails>();
		}

		public bool ExistsPrimary(string id)
		{			
			return sqlmapper.QueryForObject<bool>("ThicknessTestDetails.existsPrimary", id);
		}
    }
}
