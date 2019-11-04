﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：CustomerPicturesAccessor.autogenerated.cs
// author: peidun
// create date：2009-10-26 下午 05:56:41
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
    public partial class CustomerPicturesAccessor
    {
		public Model.CustomerPictures Get(string id)
		{
			return this.Get<Model.CustomerPictures>(id);
		}
		
		public void Insert(Model.CustomerPictures e)
		{
			this.Insert<Model.CustomerPictures>(e);
		}
		
		public void Update(Model.CustomerPictures e)
		{
			this.Update<Model.CustomerPictures>(e);
		}
		
		public IList<Model.CustomerPictures> Select()
		{
			return this.Select<Model.CustomerPictures>();
		}
		
		public IList<Model.CustomerPictures> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.CustomerPictures>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.CustomerPictures>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.CustomerPictures>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.CustomerPictures>();
		}
		public int Count()
		{
			return this.Count<Model.CustomerPictures>();
		}
		public bool HasRowsBefore(Model.CustomerPictures e)
		{
			return sqlmapper.QueryForObject<bool>("CustomerPictures.has_rows_before", e);
		}
		public bool HasRowsAfter(Model.CustomerPictures e)
		{
			return sqlmapper.QueryForObject<bool>("CustomerPictures.has_rows_after", e);
		}
		public Model.CustomerPictures GetFirst()
		{
			return sqlmapper.QueryForObject<Model.CustomerPictures>("CustomerPictures.get_first", null);
		}
		public Model.CustomerPictures GetLast()
		{
			return sqlmapper.QueryForObject<Model.CustomerPictures>("CustomerPictures.get_last", null);
		}
		public Model.CustomerPictures GetNext(Model.CustomerPictures e)
		{
			return sqlmapper.QueryForObject<Model.CustomerPictures>("CustomerPictures.get_next", e);
		}
		public Model.CustomerPictures GetPrev(Model.CustomerPictures e)
		{
			return sqlmapper.QueryForObject<Model.CustomerPictures>("CustomerPictures.get_prev", e);
		}
		

		public bool Exists(string id)
		{
			return sqlmapper.QueryForObject<bool>("CustomerPictures.exists", id);
		}
		
		public Model.CustomerPictures GetById(string id)
		{
			return sqlmapper.QueryForObject<Model.CustomerPictures>("CustomerPictures.get_by_id", id);
		}
		
		public bool ExistsExcept(Model.CustomerPictures e)
		{
			Hashtable paras = new Hashtable();
			paras.Add("newId", e.Id);
            paras.Add("oldId", Get(e.PicturesId).Id);
			return sqlmapper.QueryForObject<bool>("CustomerPictures.existsexcept", paras);
		}
    }
}
