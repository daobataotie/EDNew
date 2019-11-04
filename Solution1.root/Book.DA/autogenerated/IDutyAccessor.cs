﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：IDutyAccessor.autogenerated.cs
// author: peidun
// create date：2009-10-13 上午 11:45:02
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    public partial interface IDutyAccessor
    {
        bool HasRows();
		
        bool HasRows(string id);
		
		Model.Duty Get(string id);
		
		void Delete(string id);
		
		int Count();
		
		void Insert(Model.Duty e);
		
		void Update(Model.Duty e);
		
		IList<Model.Duty> Select();
		
		IList<Model.Duty> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription);
		bool HasRowsBefore(Model.Duty e);
		
		bool HasRowsAfter(Model.Duty e);
		
		Model.Duty GetFirst();
		
		Model.Duty GetLast();
		
		Model.Duty GetPrev(Model.Duty e);
		
		Model.Duty GetNext(Model.Duty e);

		bool Exists(string id);
		
		Model.Duty GetById(string id);
		
		bool ExistsExcept(Model.Duty e);
	}
}

