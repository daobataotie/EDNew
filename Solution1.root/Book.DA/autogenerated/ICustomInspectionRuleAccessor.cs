﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：ICustomInspectionRuleAccessor.autogenerated.cs
// author: peidun
// create date：2009-10-26 下午 05:56:40
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    public partial interface ICustomInspectionRuleAccessor
    {
        bool HasRows();
		
        bool HasRows(string id);
		
		Model.CustomInspectionRule Get(string id);
		
		void Delete(string id);
		
		int Count();
		
		void Insert(Model.CustomInspectionRule e);
		
		void Update(Model.CustomInspectionRule e);
		
		IList<Model.CustomInspectionRule> Select();
		
		IList<Model.CustomInspectionRule> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription);
		bool HasRowsBefore(Model.CustomInspectionRule e);
		
		bool HasRowsAfter(Model.CustomInspectionRule e);
		
		Model.CustomInspectionRule GetFirst();
		
		Model.CustomInspectionRule GetLast();
		
		Model.CustomInspectionRule GetPrev(Model.CustomInspectionRule e);
		
		Model.CustomInspectionRule GetNext(Model.CustomInspectionRule e);

		bool Exists(string id);
		
		Model.CustomInspectionRule GetById(string id);
		
		bool ExistsExcept(Model.CustomInspectionRule e);
	}
}

