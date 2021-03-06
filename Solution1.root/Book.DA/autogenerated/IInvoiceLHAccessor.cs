﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：IInvoiceLHAccessor.autogenerated.cs
// author: mayanjun
// create date：2018/10/20 15:49:33
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    public partial interface IInvoiceLHAccessor
    {
        bool HasRows();
		
        bool HasRows(string id);
		
		Model.InvoiceLH Get(string id);
		
		void Delete(string id);
		
		int Count();
		
		void Insert(Model.InvoiceLH e);
		
		void Update(Model.InvoiceLH e);
		
		IList<Model.InvoiceLH> Select();
		
		IList<Model.InvoiceLH> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription);
		
		bool ExistsPrimary(string id);
		bool HasRowsBefore(Model.InvoiceLH e);
		
		bool HasRowsAfter(Model.InvoiceLH e);
		
		Model.InvoiceLH GetFirst();
		
		Model.InvoiceLH GetLast();
		
		Model.InvoiceLH GetPrev(Model.InvoiceLH e);
		
		Model.InvoiceLH GetNext(Model.InvoiceLH e);

	}
}
