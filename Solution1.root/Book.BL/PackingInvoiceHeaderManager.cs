//------------------------------------------------------------------------------
//
// file name：PackingInvoiceHeaderManager.cs
// author: mayanjun
// create date：2018/12/2 16:05:25
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    /// <summary>
    /// Business logic for dbo.PackingInvoiceHeader.
    /// </summary>
    public partial class PackingInvoiceHeaderManager
    {
        private static readonly DA.IPackingInvoiceDetailAccessor accessorDetail = (DA.IPackingInvoiceDetailAccessor)Accessors.Get("PackingInvoiceDetailAccessor");

        /// <summary>
        /// Delete PackingInvoiceHeader by primary key.
        /// </summary>
        public void Delete(string invoiceNo)
        {
            //
            // todo:add other logic here
            //
            try
            {
                BL.V.BeginTransaction();

                accessorDetail.DeleteByHeader(invoiceNo);
                accessor.Delete(invoiceNo);

                BL.V.CommitTransaction();
            }
            catch (Exception ex)
            {
                BL.V.RollbackTransaction();
                throw ex;
            }
        }

        /// <summary>
        /// Insert a PackingInvoiceHeader.
        /// </summary>
        public void Insert(Model.PackingInvoiceHeader packingInvoiceHeader)
        {
            //
            // todo:add other logic here
            //
            Validate(packingInvoiceHeader);

            if (this.ExistsPrimary(packingInvoiceHeader.InvoiceNo))
                throw new Helper.MessageValueException(string.Format("已存在相同的InvoiceNO：{0}", packingInvoiceHeader.InvoiceNo));

            try
            {
                BL.V.BeginTransaction();

                packingInvoiceHeader.InsertTime = DateTime.Now;
                packingInvoiceHeader.UpdateTime = DateTime.Now;
                accessor.Insert(packingInvoiceHeader);

                foreach (var item in packingInvoiceHeader.Details)
                {
                    item.PackingInvoiceHeaderId = packingInvoiceHeader.InvoiceNo;

                    accessorDetail.Insert(item);
                }

                BL.V.CommitTransaction();
            }
            catch (Exception ex)
            {
                BL.V.RollbackTransaction();
                throw ex;
            }
        }

        /// <summary>
        /// Update a PackingInvoiceHeader.
        /// </summary>
        public void Update(Model.PackingInvoiceHeader packingInvoiceHeader)
        {
            //
            // todo: add other logic here.
            //
            Validate(packingInvoiceHeader);

            try
            {
                BL.V.BeginTransaction();

                packingInvoiceHeader.UpdateTime = DateTime.Now;
                accessor.Update(packingInvoiceHeader);

                accessorDetail.DeleteByHeader(packingInvoiceHeader.InvoiceNo);
                foreach (var item in packingInvoiceHeader.Details)
                {
                    item.PackingInvoiceHeaderId = packingInvoiceHeader.InvoiceNo;

                    accessorDetail.Insert(item);
                }

                BL.V.CommitTransaction();
            }
            catch (Exception ex)
            {
                BL.V.RollbackTransaction();
                throw ex;
            }
        }

        private void Validate(Model.PackingInvoiceHeader model)
        {
            if (string.IsNullOrEmpty(model.InvoiceNo))
                throw new Helper.RequireValueException(Model.PackingInvoiceHeader.PRO_InvoiceNo);
            if (model.InvoiceDate == null)
                throw new Helper.RequireValueException(Model.PackingInvoiceHeader.PRO_InvoiceDate);

            //foreach (var item in model.Details)
            //{
            //    if (string.IsNullOrEmpty(item.Number))
            //        throw new Helper.RequireValueException(Model.PackingInvoiceDetail.PRO_Number);
            //}
        }

        public Book.Model.PackingInvoiceHeader GetDetail(string invoiceNo)
        {
            Model.PackingInvoiceHeader header = this.Get(invoiceNo);
            if (header != null)
                header.Details = accessorDetail.SelectByHeader(invoiceNo);

            return header;
        }

        public IList<Model.PackingInvoiceHeader> SelectByCondition(DateTime startDate, DateTime endDate, string customerId)
        {
            return accessor.SelectByCondition(startDate, endDate, customerId);
        }
    }
}
