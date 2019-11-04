﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：IInvoiceZSAccessor.autogenerated.cs
// author: peidun
// create date：2009-10-23 下午 09:47:43
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    public partial interface IInvoiceZSAccessor
    {
        bool HasRows();
		
        bool HasRows(string id);
		
		Model.InvoiceZS Get(string id);
		
		void Delete(string id);
		
		int Count();
		
		void Insert(Model.InvoiceZS e);
		
		void Update(Model.InvoiceZS e);
		
		IList<Model.InvoiceZS> Select();
		
		IList<Model.InvoiceZS> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription);
		bool HasRowsBefore(Model.InvoiceZS e);
		
		bool HasRowsAfter(Model.InvoiceZS e);
		
		Model.InvoiceZS GetFirst();
		
		Model.InvoiceZS GetLast();
		
		Model.InvoiceZS GetPrev(Model.InvoiceZS e);
		
		Model.InvoiceZS GetNext(Model.InvoiceZS e);

	}
}

