//------------------------------------------------------------------------------
//
// file name：InvoiceLHManager.cs
// author: mayanjun
// create date：2018/10/20 11:17:53
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    /// <summary>
    /// Business logic for dbo.InvoiceLH.
    /// </summary>
    public partial class InvoiceLHManager : InvoiceManager
    {
        private static readonly DA.IInvoiceLHDetailAccessor accessorDetail = (DA.IInvoiceLHDetailAccessor)Accessors.Get("InvoiceLHDetailAccessor");

        /// <summary>
        /// Delete InvoiceLH by primary key.
        /// </summary>
        public void Delete(string invoiceId)
        {
            //
            // todo:add other logic here
            //
            accessorDetail.DeleteByHeaderId(invoiceId);
            accessor.Delete(invoiceId);
        }

        /// <summary>
        /// Insert a InvoiceLH.
        /// </summary>
        public void _Insert(Model.InvoiceLH invoiceLH)
        {
            //
            // todo:add other logic here
            // 

            //Validate(invoiceLH);
            invoiceLH.InsertTime = DateTime.Now;
            invoiceLH.UpdateTime = DateTime.Now;

            accessor.Insert(invoiceLH);

            foreach (var item in invoiceLH.Detail)
            {
                item.InvoiceLHId = invoiceLH.InvoiceId;

                accessorDetail.Insert(item);
            }
        }

        /// <summary>
        /// Update a InvoiceLH.
        /// </summary>
        public void Update(Model.InvoiceLH invoiceLH)
        {
            //
            // todo: add other logic here.
            //

            Validate(invoiceLH);

            invoiceLH.UpdateTime = DateTime.Now;
            accessor.Update(invoiceLH);

            accessorDetail.DeleteByHeaderId(invoiceLH.InvoiceId);
            foreach (var item in invoiceLH.Detail)
            {
                item.InvoiceLHId = invoiceLH.InvoiceId;

                accessorDetail.Insert(item);
            }
        }

        protected override void _Insert(Book.Model.Invoice invoice)
        {
            _Insert((Model.InvoiceLH)invoice);
        }

        protected override void _Update(Book.Model.Invoice invoice)
        {
            Update(invoice);
        }

        protected override void _TurnNormal(Book.Model.Invoice invoice)
        {
            throw new NotImplementedException();
        }

        protected override void _TurnNull(Book.Model.Invoice invoice)
        {
            throw new NotImplementedException();
        }

        protected override string GetInvoiceKind()
        {
            return "LH";
        }

        protected override string GetSettingId()
        {
            return "InvoiceNumberRuleOfLH";
        }

        public Model.InvoiceLH GetDetail(string invoiceId)
        {
            Model.InvoiceLH invoice = this.Get(invoiceId);
            if (invoice != null)
            {
                invoice.Detail = accessorDetail.SelectByHeaderId(invoiceId);

                if (invoice.Detail == null)
                    invoice.Detail = new List<Model.InvoiceLHDetail>();
            }

            return invoice;
        }

        protected void TiGuiExists(Book.Model.Invoice model)
        {
            Model.InvoiceLH lh = this.Get(model.InvoiceId);
            if (lh != null)
            {
                //设置KEY值
                string invoiceKind = this.GetInvoiceKind().ToLower();
                string sequencekey_d = string.Format("{0}-d-{1}", invoiceKind, model.InsertTime.Value.ToString("yyyy-MM-dd"));
                SequenceManager.Increment(sequencekey_d);
                //string sequencekey_m = string.Format("{0}-m-{1}-{2}", invoiceKind, model.InvoiceDate.Value.Year, model.InvoiceDate.Value.Month);
                //SequenceManager.Increment(sequencekey_m);
                //model.InvoiceId = this.GetIdSimple(model.InsertTime.Value);
                model.InvoiceId = this.GetId(model.InsertTime.Value);
                TiGuiExists(model);
            }
        }

        protected override void _ValidateForUpdate(Book.Model.Invoice invoice)
        {
            Validate((Model.InvoiceLH)invoice);
            //
        }

        protected override void _ValidateForInsert(Book.Model.Invoice invoice)
        {
            Validate((Model.InvoiceLH)invoice);
        }

        private void Validate(Model.InvoiceLH invoice)
        {
            if (string.IsNullOrEmpty(invoice.InvoiceId))
                throw new Helper.RequireValueException(Model.InvoiceLH.PRO_InvoiceId);

            if (invoice.InvoiceDate == null)
                throw new Helper.RequireValueException(Model.InvoiceLH.PRO_InvoiceDate);

            if (string.IsNullOrEmpty(invoice.CustomerId))
                throw new Helper.RequireValueException(Model.InvoiceLH.PRO_CustomerId);
        }
    }
}
