//------------------------------------------------------------------------------
//
// file name：ProformaInvoiceDetailManager.cs
// author: mayanjun
// create date：2019/3/13 20:30:28
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    /// <summary>
    /// Business logic for dbo.ProformaInvoiceDetail.
    /// </summary>
    public partial class ProformaInvoiceDetailManager
    {

        /// <summary>
        /// Delete ProformaInvoiceDetail by primary key.
        /// </summary>
        public void Delete(string proformaInvoiceDetailId)
        {
            //
            // todo:add other logic here
            //
            accessor.Delete(proformaInvoiceDetailId);
        }

        /// <summary>
        /// Insert a ProformaInvoiceDetail.
        /// </summary>
        public void Insert(Model.ProformaInvoiceDetail proformaInvoiceDetail)
        {
            //
            // todo:add other logic here
            //
            accessor.Insert(proformaInvoiceDetail);
        }

        /// <summary>
        /// Update a ProformaInvoiceDetail.
        /// </summary>
        public void Update(Model.ProformaInvoiceDetail proformaInvoiceDetail)
        {
            //
            // todo: add other logic here.
            //
            accessor.Update(proformaInvoiceDetail);
        }


        public IList<Model.ProformaInvoiceDetail> SelectByHeader(string headerId)
        {
            return accessor.SelectByHeader(headerId);
        }

        public void DeleteByHeader(string headerId)
        {
            accessor.DeleteByHeader(headerId);
        }
    }
}
