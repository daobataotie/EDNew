﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：IProductOnlineCheckAccessor.autogenerated.cs
// author: mayanjun
// create date：2013-3-26 10:59:21
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    public partial interface IProductOnlineCheckAccessor
    {
        bool HasRows();
		
        bool HasRows(string id);
		
		Model.ProductOnlineCheck Get(string id);
		
		void Delete(string id);
		
		int Count();
		
		void Insert(Model.ProductOnlineCheck e);
		
		void Update(Model.ProductOnlineCheck e);
		
		IList<Model.ProductOnlineCheck> Select();
		
		IList<Model.ProductOnlineCheck> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription);
		
		bool ExistsPrimary(string id);
		bool HasRowsBefore(Model.ProductOnlineCheck e);
		
		bool HasRowsAfter(Model.ProductOnlineCheck e);
		
		Model.ProductOnlineCheck GetFirst();
		
		Model.ProductOnlineCheck GetLast();
		
		Model.ProductOnlineCheck GetPrev(Model.ProductOnlineCheck e);
		
		Model.ProductOnlineCheck GetNext(Model.ProductOnlineCheck e);

	}
}

