﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：IPronoteHeaderAccessor.autogenerated.cs
// author: mayanjun
// create date：2011-10-21 17:08:43
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    public partial interface IPronoteHeaderAccessor
    {
        bool HasRows();
		
        bool HasRows(string id);
		
		Model.PronoteHeader Get(string id);
		
		void Delete(string id);
		
		int Count();
		
		void Insert(Model.PronoteHeader e);
		
		void Update(Model.PronoteHeader e);
		
		IList<Model.PronoteHeader> Select();
		
		IList<Model.PronoteHeader> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription);
		
		bool ExistsPrimary(string id);
		bool HasRowsBefore(Model.PronoteHeader e);
		
		bool HasRowsAfter(Model.PronoteHeader e);
		
		Model.PronoteHeader GetFirst();
		
		Model.PronoteHeader GetLast();
		
		Model.PronoteHeader GetPrev(Model.PronoteHeader e);
		
		Model.PronoteHeader GetNext(Model.PronoteHeader e);

	}
}

