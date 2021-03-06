﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：IBillIdDeletedAccessor.autogenerated.cs
// author: mayanjun
// create date：2015/11/20 18:57:00
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    public partial interface IBillIdDeletedAccessor
    {
        bool HasRows();
		
        bool HasRows(string id);
		
		Model.BillIdDeleted Get(string id);
		
		void Delete(string id);
		
		int Count();
		
		void Insert(Model.BillIdDeleted e);
		
		void Update(Model.BillIdDeleted e);
		
		IList<Model.BillIdDeleted> Select();
		
		IList<Model.BillIdDeleted> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription);
		
		bool ExistsPrimary(string id);

	}
}
