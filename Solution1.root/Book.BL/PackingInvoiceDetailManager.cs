//------------------------------------------------------------------------------
//
// file name：PackingInvoiceDetailManager.cs
// author: mayanjun
// create date：2018/12/2 16:05:25
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    /// <summary>
    /// Business logic for dbo.PackingInvoiceDetail.
    /// </summary>
    public partial class PackingInvoiceDetailManager
    {

        /// <summary>
        /// Delete PackingInvoiceDetail by primary key.
        /// </summary>
        public void Delete(string packingInvoiceDetailId)
        {
            //
            // todo:add other logic here
            //
            accessor.Delete(packingInvoiceDetailId);
        }

        /// <summary>
        /// Insert a PackingInvoiceDetail.
        /// </summary>
        public void Insert(Model.PackingInvoiceDetail packingInvoiceDetail)
        {
            //
            // todo:add other logic here
            //
            accessor.Insert(packingInvoiceDetail);
        }

        /// <summary>
        /// Update a PackingInvoiceDetail.
        /// </summary>
        public void Update(Model.PackingInvoiceDetail packingInvoiceDetail)
        {
            //
            // todo: add other logic here.
            //
            accessor.Update(packingInvoiceDetail);
        }

        public IList<Model.PackingInvoiceDetail> SelectByHeader(string headerId)
        {
            return accessor.SelectByHeader(headerId);
        }

    }
}
