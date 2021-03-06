﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：IBillIdSetAccessor.autogenerated.cs
// author: mayanjun
// create date：2015/11/20 18:57:00
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    public partial interface IBillIdSetAccessor
    {
        bool HasRows();
		
        bool HasRows(string id);
		
		Model.BillIdSet Get(string id);
		
		void Delete(string id);
		
		int Count();
		
		void Insert(Model.BillIdSet e);
		
		void Update(Model.BillIdSet e);
		
		IList<Model.BillIdSet> Select();
		
		IList<Model.BillIdSet> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription);
		
		bool ExistsPrimary(string id);
		bool HasRowsBefore(Model.BillIdSet e);
		
		bool HasRowsAfter(Model.BillIdSet e);
		
		Model.BillIdSet GetFirst();
		
		Model.BillIdSet GetLast();
		
		Model.BillIdSet GetPrev(Model.BillIdSet e);
		
		Model.BillIdSet GetNext(Model.BillIdSet e);

	}
}
