﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：IProduceMaterialdetailsAccessor.autogenerated.cs
// author: peidun
// create date：2009-12-30 16:37:29
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    public partial interface IProduceMaterialdetailsAccessor
    {
        bool HasRows();
		
        bool HasRows(string id);
		
		Model.ProduceMaterialdetails Get(string id);
		
		void Delete(string id);
		
		int Count();
		
		void Insert(Model.ProduceMaterialdetails e);
		
		void Update(Model.ProduceMaterialdetails e);
		
		IList<Model.ProduceMaterialdetails> Select();
		
		IList<Model.ProduceMaterialdetails> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription);

	}
}

