//------------------------------------------------------------------------------
//
// file name：ProformaInvoiceManager.cs
// author: mayanjun
// create date：2019/3/13 18:44:58
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    /// <summary>
    /// Business logic for dbo.ProformaInvoice.
    /// </summary>
    public partial class ProformaInvoiceManager
    {
        DA.IProformaInvoiceDetailAccessor detailAccessor = (DA.IProformaInvoiceDetailAccessor)Accessors.Get("ProformaInvoiceDetailAccessor");

        /// <summary>
        /// Delete ProformaInvoice by primary key.
        /// </summary>
        public void Delete(string pO)
        {
            //
            // todo:add other logic here
            // 
            try
            {
                BL.V.BeginTransaction();

                detailAccessor.DeleteByHeader(pO);
                accessor.Delete(pO);

                BL.V.CommitTransaction();
            }
            catch (Exception ex)
            {
                BL.V.RollbackTransaction();
                throw ex;
            }
        }

        /// <summary>
        /// Insert a ProformaInvoice.
        /// </summary>
        public void Insert(Model.ProformaInvoice proformaInvoice)
        {
            //
            // todo:add other logic here
            //
            Validate(proformaInvoice);
            if (ExistsPrimary(proformaInvoice.PO))
                throw new Helper.MessageValueException(string.Format("已存在相同的PO：{0}", proformaInvoice.PO));

            try
            {
                BL.V.BeginTransaction();

                proformaInvoice.InsertTime = DateTime.Now;
                proformaInvoice.UpdateTime = DateTime.Now;
                accessor.Insert(proformaInvoice);

                foreach (var item in proformaInvoice.Details)
                {
                    item.ProformaInvoiceId = proformaInvoice.PO;

                    detailAccessor.Insert(item);
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
        /// Update a ProformaInvoice.
        /// </summary>
        public void Update(Model.ProformaInvoice proformaInvoice)
        {
            //
            // todo: add other logic here.
            //

            Validate(proformaInvoice);

            try
            {
                BL.V.BeginTransaction();

                proformaInvoice.UpdateTime = DateTime.Now;
                accessor.Update(proformaInvoice);

                detailAccessor.DeleteByHeader(proformaInvoice.PO);
                foreach (var item in proformaInvoice.Details)
                {
                    item.ProformaInvoiceId = proformaInvoice.PO;

                    detailAccessor.Insert(item);
                }

                BL.V.CommitTransaction();
            }
            catch (Exception ex)
            {
                BL.V.RollbackTransaction();
                throw ex;
            }
        }

        private void Validate(Model.ProformaInvoice model)
        {
            if (string.IsNullOrEmpty(model.PO))
                throw new Helper.RequireValueException(Model.ProformaInvoice.PRO_PO);
            if (model.InvoiceDate == null)
                throw new Helper.RequireValueException(Model.ProformaInvoice.PRO_InvoiceDate);
            if (string.IsNullOrEmpty(model.CustomerId))
                throw new Helper.RequireValueException(Model.ProformaInvoice.PRO_CustomerId);
        }

        public Model.ProformaInvoice GetDetail(string id)
        {
            Model.ProformaInvoice model = this.Get(id);
            if (model != null)
            {
                model.Details = detailAccessor.SelectByHeader(id);
            }

            return model;
        }

        public IList<Model.ProformaInvoice> SelectByCondition(DateTime dateStart, DateTime dateEnd, string customerId)
        {
            return accessor.SelectByCondition(dateStart, dateEnd, customerId);
        }
    }
}
