﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：IBGHandbookAccessor.autogenerated.cs
// author: mayanjun
// create date：2013-4-16 11:59:00
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    public partial interface IBGHandbookAccessor
    {
        bool HasRows();
		
        bool HasRows(string id);
		
		Model.BGHandbook Get(string id);
		
		void Delete(string id);
		
		int Count();
		
		void Insert(Model.BGHandbook e);
		
		void Update(Model.BGHandbook e);
		
		IList<Model.BGHandbook> Select();
		
		IList<Model.BGHandbook> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription);
		
		bool ExistsPrimary(string id);
		bool HasRowsBefore(Model.BGHandbook e);
		
		bool HasRowsAfter(Model.BGHandbook e);
		
		Model.BGHandbook GetFirst();
		
		Model.BGHandbook GetLast();
		
		Model.BGHandbook GetPrev(Model.BGHandbook e);
		
		Model.BGHandbook GetNext(Model.BGHandbook e);

		bool Exists(string id);
		
		Model.BGHandbook GetById(string id);
		
		bool ExistsExcept(Model.BGHandbook e);
		
	}
}

