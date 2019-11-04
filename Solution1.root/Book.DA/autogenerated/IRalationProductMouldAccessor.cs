﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：IRalationProductMouldAccessor.autogenerated.cs
// author: peidun
// create date：2009-08-03 10:49:37
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    public partial interface IRalationProductMouldAccessor
    {
        bool HasRows();
        bool HasRows(string id);
		
		Model.RalationProductMould Get(string id);
		
		void Delete(string id);
		
		int Count();
		
		void Insert(Model.RalationProductMould e);
		
		void Update(Model.RalationProductMould e);
		
		IList<Model.RalationProductMould> Select();
		
		IList<Model.RalationProductMould> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription);
	}
}

