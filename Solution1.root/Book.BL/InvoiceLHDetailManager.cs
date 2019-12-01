//------------------------------------------------------------------------------
//
// file name：InvoiceLHDetailManager.cs
// author: mayanjun
// create date：2018/10/20 11:17:53
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    /// <summary>
    /// Business logic for dbo.InvoiceLHDetail.
    /// </summary>
    public partial class InvoiceLHDetailManager
    {

        /// <summary>
        /// Delete InvoiceLHDetail by primary key.
        /// </summary>
        public void Delete(string invoiceLHDetailId)
        {
            //
            // todo:add other logic here
            //
            accessor.Delete(invoiceLHDetailId);
        }

        /// <summary>
        /// Insert a InvoiceLHDetail.
        /// </summary>
        public void Insert(Model.InvoiceLHDetail invoiceLHDetail)
        {
            //
            // todo:add other logic here
            //
            accessor.Insert(invoiceLHDetail);
        }

        /// <summary>
        /// Update a InvoiceLHDetail.
        /// </summary>
        public void Update(Model.InvoiceLHDetail invoiceLHDetail)
        {
            //
            // todo: add other logic here.
            //
            accessor.Update(invoiceLHDetail);
        }

        public IList<Model.InvoiceLHDetail> SelectByHeaderId(string invoiceId)
        {
            return accessor.SelectByHeaderId(invoiceId);
        }

        public void DeleteByHeaderId(string invoiceId)
        {
            accessor.DeleteByHeaderId(invoiceId);
        }

        public IList<Model.InvoiceLHDetail> SelectByCondition(DateTime StartDate, DateTime EndDate, string CustomerId)
        {
            return accessor.SelectByCondition(StartDate, EndDate, CustomerId);
        }
    }
}
