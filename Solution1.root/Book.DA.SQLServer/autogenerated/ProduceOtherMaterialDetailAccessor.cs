﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：ProduceOtherMaterialDetailAccessor.autogenerated.cs
// author: peidun
// create date：2010-1-5 15:39:19
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
    public partial class ProduceOtherMaterialDetailAccessor
    {
		public Model.ProduceOtherMaterialDetail Get(string id)
		{
			return this.Get<Model.ProduceOtherMaterialDetail>(id);
		}
		
		public void Insert(Model.ProduceOtherMaterialDetail e)
		{
			this.Insert<Model.ProduceOtherMaterialDetail>(e);
		}
		
		public void Update(Model.ProduceOtherMaterialDetail e)
		{
			this.Update<Model.ProduceOtherMaterialDetail>(e);
		}
		
		public IList<Model.ProduceOtherMaterialDetail> Select()
		{
			return this.Select<Model.ProduceOtherMaterialDetail>();
		}
		
		public IList<Model.ProduceOtherMaterialDetail> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.ProduceOtherMaterialDetail>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.ProduceOtherMaterialDetail>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.ProduceOtherMaterialDetail>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.ProduceOtherMaterialDetail>();
		}
		public int Count()
		{
			return this.Count<Model.ProduceOtherMaterialDetail>();
		}

    }
}
