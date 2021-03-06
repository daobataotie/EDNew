﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：IInvoiceBYAccessor.autogenerated.cs
// author: peidun
// create date：2009-10-23 下午 09:47:43
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    public partial interface IInvoiceBYAccessor
    {
        bool HasRows();
		
        bool HasRows(string id);
		
		Model.InvoiceBY Get(string id);
		
		void Delete(string id);
		
		int Count();
		
		void Insert(Model.InvoiceBY e);
		
		void Update(Model.InvoiceBY e);
		
		IList<Model.InvoiceBY> Select();
		
		IList<Model.InvoiceBY> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription);
		bool HasRowsBefore(Model.InvoiceBY e);
		
		bool HasRowsAfter(Model.InvoiceBY e);
		
		Model.InvoiceBY GetFirst();
		
		Model.InvoiceBY GetLast();
		
		Model.InvoiceBY GetPrev(Model.InvoiceBY e);
		
		Model.InvoiceBY GetNext(Model.InvoiceBY e);

	}
}

