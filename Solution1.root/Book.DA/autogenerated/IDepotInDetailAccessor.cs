﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：IDepotInDetailAccessor.autogenerated.cs
// author: mayanjun
// create date：2010-10-25 16:14:45
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    public partial interface IDepotInDetailAccessor
    {
        bool HasRows();
		
        bool HasRows(string id);
		
		Model.DepotInDetail Get(string id);
		
		void Delete(string id);
		
		int Count();
		
		void Insert(Model.DepotInDetail e);
		
		void Update(Model.DepotInDetail e);
		
		IList<Model.DepotInDetail> Select();
		
		IList<Model.DepotInDetail> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription);
		
		bool ExistsPrimary(string id);

	}
}

