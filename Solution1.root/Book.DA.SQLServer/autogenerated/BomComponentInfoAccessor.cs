﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：BomComponentInfoAccessor.autogenerated.cs
// author: peidun
// create date：2009-10-26 上午 11:26:03
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
    public partial class BomComponentInfoAccessor
    {
		public Model.BomComponentInfo Get(string id)
		{
			return this.Get<Model.BomComponentInfo>(id);
		}
		
		public void Insert(Model.BomComponentInfo e)
		{
			this.Insert<Model.BomComponentInfo>(e);
		}
		
		public void Update(Model.BomComponentInfo e)
		{
			this.Update<Model.BomComponentInfo>(e);
		}
		
		public IList<Model.BomComponentInfo> Select()
		{
			return this.Select<Model.BomComponentInfo>();
		}
		
		public IList<Model.BomComponentInfo> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.BomComponentInfo>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.BomComponentInfo>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.BomComponentInfo>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.BomComponentInfo>();
		}
		public int Count()
		{
			return this.Count<Model.BomComponentInfo>();
		}

    }
}
