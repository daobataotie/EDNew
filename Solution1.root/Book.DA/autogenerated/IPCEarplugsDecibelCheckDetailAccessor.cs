﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：IPCEarplugsDecibelCheckDetailAccessor.autogenerated.cs
// author: mayanjun
// create date：2019/5/12 14:43:54
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    public partial interface IPCEarplugsDecibelCheckDetailAccessor
    {
        bool HasRows();
		
        bool HasRows(string id);
		
		Model.PCEarplugsDecibelCheckDetail Get(string id);
		
		void Delete(string id);
		
		int Count();
		
		void Insert(Model.PCEarplugsDecibelCheckDetail e);
		
		void Update(Model.PCEarplugsDecibelCheckDetail e);
		
		IList<Model.PCEarplugsDecibelCheckDetail> Select();
		
		IList<Model.PCEarplugsDecibelCheckDetail> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription);
		
		bool ExistsPrimary(string id);

	}
}
