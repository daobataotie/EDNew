﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：IProduceOtherReturnDetailAccessor.autogenerated.cs
// author: mayanjun
// create date：2011-08-31 15:05:11
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    public partial interface IProduceOtherReturnDetailAccessor
    {
        bool HasRows();
		
        bool HasRows(string id);
		
		Model.ProduceOtherReturnDetail Get(string id);
		
		void Delete(string id);
		
		int Count();
		
		void Insert(Model.ProduceOtherReturnDetail e);
		
		void Update(Model.ProduceOtherReturnDetail e);
		
		IList<Model.ProduceOtherReturnDetail> Select();
		
		IList<Model.ProduceOtherReturnDetail> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription);
		
		bool ExistsPrimary(string id);

	}
}

