﻿//------------------------------------------------------------------------------
//
// file name：InvoiceXSManager.cs
// author: peidun
// create date：2008/6/6 10:00:59
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;

namespace Book.BL
{
    /// <summary>
    /// Business logic for dbo.InvoiceXS.
    /// </summary>
    public partial class InvoiceXSManager : InvoiceManager
    {
        private static readonly DA.IInvoiceXSDetailAccessor invoiceXSDetailAccessor = (DA.IInvoiceXSDetailAccessor)Accessors.Get("InvoiceXSDetailAccessor");
        private static readonly DA.IInvoiceXOAccessor invoiceXOAccessor = (DA.IInvoiceXOAccessor)Accessors.Get("InvoiceXOAccessor");
        private static readonly DA.ICustomerAccessor customerAccessor = (DA.ICustomerAccessor)Accessors.Get("CustomerAccessor");
        private static readonly DA.ICustomerProductsAccessor customerProductsAccessor = (DA.ICustomerProductsAccessor)Accessors.Get("CustomerProductsAccessor");
        private static readonly DA.IInvoiceXODetailAccessor invoiceXODetailAccessor = (DA.IInvoiceXODetailAccessor)Accessors.Get("InvoiceXODetailAccessor");
        private BL.InvoiceXOManager invoiceXOManager = new InvoiceXOManager();
        private static readonly DA.IStockAccessor stockAccessor = (DA.IStockAccessor)Accessors.Get("StockAccessor");
        private ProductManager productManager = new ProductManager();

        #region Select

        public IList<Model.InvoiceXS> Select(DateTime start, DateTime end)
        {
            return accessor.Select(start, end);
        }

        public IList<Model.InvoiceXS> Select(Helper.InvoiceStatus status)
        {
            return accessor.Select(status);
        }

        public Model.InvoiceXS Get(string invoiceId)
        {
            Model.InvoiceXS invoice = accessor.Get(invoiceId);
            if (invoice != null)
                invoice.Details = invoiceXSDetailAccessor.Select(invoice);
            return invoice;
        }

        public Model.InvoiceXS GetDetails(string invoiceId)
        {
            Model.InvoiceXS invoice = accessor.Get(invoiceId);
            if (invoice != null)
                invoice.Details = invoiceXSDetailAccessor.Select(invoice);
            return invoice;
        }
        #endregion



        #region Override

        #region Operations

        protected override void _Insert(Book.Model.Invoice invoice)
        {
            if (!(invoice is Model.InvoiceXS))
                throw new ArgumentException();
            invoice.InsertTime = DateTime.Now;
            invoice.UpdateTime = DateTime.Now;
            _Insert((Model.InvoiceXS)invoice);
        }

        protected override void _Update(Book.Model.Invoice invoice)
        {
            if (!(invoice is Model.InvoiceXS))
                throw new ArgumentException();
            _Update((Model.InvoiceXS)invoice);
        }

        protected override void _TurnNormal(Model.Invoice invoice)
        {
            if (!(invoice is Model.InvoiceXS))
                throw new ArgumentException();

            _TurnNormal((Model.InvoiceXS)invoice);
        }

        protected override void _TurnNull(Model.Invoice invoice)
        {
            if (!(invoice is Model.InvoiceXS))
                throw new ArgumentException();

            _TurnNull((Model.InvoiceXS)invoice);
        }

        #endregion

        private void _TurnNull(Model.InvoiceXS invoice)
        {
            invoice.InvoiceStatus = (int)Helper.InvoiceStatus.Null;
            _Update(invoice);
        }

        private void _TurnNormal(Model.InvoiceXS invoice)
        {
            invoice.InvoiceStatus = (int)Helper.InvoiceStatus.Normal;
            _Update(invoice);
        }

        #region Other

        protected override string GetInvoiceKind()
        {
            return "XS";
        }

        protected override Book.DA.IInvoiceAccessor GetAccessor()
        {
            return accessor;
        }

        #endregion

        #region Validation

        protected override void _ValidateForUpdate(Book.Model.Invoice invoice)
        {
            base._ValidateForUpdate(invoice);
            Validate((Model.InvoiceXS)invoice);
            //
        }

        protected override void _ValidateForInsert(Book.Model.Invoice invoice)
        {
            base._ValidateForInsert(invoice);

            Validate((Model.InvoiceXS)invoice);
        }

        #endregion

        #endregion

        private void _Insert(Model.InvoiceXS invoice)
        {
            //invoice.DepotId = invoice.Depot.DepotId;
            invoice.Employee0Id = invoice.Employee0.EmployeeId;
            invoice.Employee1Id = invoice.Employee1 == null ? null : invoice.Employee1.EmployeeId;
            invoice.Employee2Id = invoice.Employee2 == null ? null : invoice.Employee2.EmployeeId;
            accessor.Insert(invoice);
            foreach (Model.InvoiceXSDetail detail in invoice.Details)
            {
                //  if (detail.PrimaryKey == null || string.IsNullOrEmpty(detail.PrimaryKey.PrimaryKeyId)) continue;    
                if (detail.Product == null || string.IsNullOrEmpty(detail.Product.ProductId))
                    continue;
                //Model.Stock stock = stockAccessor.GetStockByProductIdAndDepotPositionId(detail.ProductId, detail.DepotPositionId);
                //if (stock == null || Convert.ToDecimal(stock.StockQuantity1) < Convert.ToDecimal(detail.InvoiceXSDetailQuantity))
                //    throw new Helper.MessageValueException("" + detail.Product + "\r出貨數量不能大於貨位庫存");

                detail.InvoiceId = invoice.InvoiceId;
                invoiceXSDetailAccessor.Insert(detail);
                Model.InvoiceXODetail xodetail = invoiceXODetailAccessor.Get(detail.InvoiceXODetailId);
                if (xodetail != null)
                {
                    if (detail.InvoiceXSDetailQuantity >= xodetail.InvoiceXODetailQuantity0)
                    {
                        xodetail.DetailsFlag = (int)Helper.DetailsFlag.AllArrived;
                    }
                    else
                    {
                        xodetail.DetailsFlag = (int)Helper.DetailsFlag.PartArrived;
                    }


                    if (!xodetail.InvoiceXODetailBeenQuantity.HasValue)
                        xodetail.InvoiceXODetailBeenQuantity = 0;
                    if (!xodetail.InvoiceXTDetailQuantity.HasValue)
                        xodetail.InvoiceXTDetailQuantity = 0;
                    xodetail.InvoiceXODetailBeenQuantity += detail.InvoiceXSDetailQuantity;
                    xodetail.InvoiceXODetailQuantity0 = xodetail.InvoiceXODetailQuantity - xodetail.InvoiceXODetailBeenQuantity + xodetail.InvoiceXTDetailQuantity;
                    if (xodetail.InvoiceXODetailQuantity0 < 0)
                        xodetail.InvoiceXODetailQuantity0 = 0;
                    invoiceXODetailAccessor.Update(xodetail);
                    //改变客户订单和生产加工单的结案状态
                    invoiceXOManager.UpdateInvoiceFlag(xodetail.Invoice);

                }

                //更新产品表库存
                // customerProductsAccessor.Update(p);
                //更新销售订单出货量和未出货量             
                //单位转化过程
                //1
                //2
                //3

                //if (detail.DepotPosition != null)
                //{
                //    // 更新库存
                //    stockAccessor.Decrement(detail.DepotPosition, detail.Product, detail.InvoiceXSDetailQuantity.Value);
                //    //更新产品库存
                //    //this.productManager.UpdateProduct_Stock(detail.Product);
                //    detail.Product.StocksQuantity = stockAccessor.GetTheCountByProduct(detail.Product);
                //    detail.Product.ProductNearXSDate = DateTime.Now;
                //    this.productManager.update(detail.Product);
                //}
            }



            //客户最近交易日
            invoice.Customer.LastTransactionDate = DateTime.Now;
            customerAccessor.Update(invoice.Customer);
        }

        private void _Update(Model.InvoiceXS invoice)
        {
            _ValidateForUpdate(invoice);
            invoice.UpdateTime = DateTime.Now;
            invoice.CustomerId = invoice.Customer.CustomerId;
            //invoice.DepotId = invoice.Depot.DepotId;
            invoice.Employee0Id = invoice.Employee0.EmployeeId;
            invoice.Employee1Id = invoice.Employee1 == null ? null : invoice.Employee1.EmployeeId;
            invoice.Employee2Id = invoice.Employee2 == null ? null : invoice.Employee2.EmployeeId;
            Model.InvoiceXS invoiceOriginal = this.Get(invoice.InvoiceId);
            switch ((Helper.InvoiceStatus)invoiceOriginal.InvoiceStatus)
            {
                case Helper.InvoiceStatus.Normal:
                    switch ((Helper.InvoiceStatus)invoice.InvoiceStatus)
                    {
                        case Helper.InvoiceStatus.Draft:
                            throw new InvalidOperationException();
                        case Helper.InvoiceStatus.Normal:
                            invoiceOriginal.InvoiceStatus = (int)Helper.InvoiceStatus.Null;
                            _TurnNull(invoiceOriginal);
                            accessor.Delete(invoiceOriginal.InvoiceId);
                            invoice.InsertTime = invoiceOriginal.InsertTime;
                            invoice.UpdateTime = DateTime.Now;
                            _Insert(invoice);
                            break;
                        case Helper.InvoiceStatus.Null:

                            foreach (Model.InvoiceXSDetail detail in invoice.Details)
                            {
                                Model.InvoiceXODetail xodetail = invoiceXODetailAccessor.Get(detail.InvoiceXODetailId);
                                if (xodetail != null)
                                {
                                    xodetail.InvoiceXODetailBeenQuantity = Convert.ToDouble(xodetail.InvoiceXODetailBeenQuantity) - detail.InvoiceXSDetailQuantity;
                                    if (!xodetail.InvoiceXTDetailQuantity.HasValue)
                                        xodetail.InvoiceXTDetailQuantity = 0;
                                    xodetail.InvoiceXODetailQuantity0 = xodetail.InvoiceXODetailQuantity - xodetail.InvoiceXODetailBeenQuantity + xodetail.InvoiceXTDetailQuantity;
                                    if (xodetail.InvoiceXODetailQuantity0 < 0)
                                        xodetail.InvoiceXODetailQuantity0 = 0;

                                    if (xodetail.InvoiceXODetailQuantity0 == 0)
                                        xodetail.DetailsFlag = 2;
                                    else if (xodetail.InvoiceXODetailQuantity0 == xodetail.InvoiceXODetailQuantity)
                                        xodetail.DetailsFlag = 0;
                                    else
                                        xodetail.DetailsFlag = 1;

                                    invoiceXODetailAccessor.Update(xodetail);
                                    invoiceXOManager.UpdateInvoiceFlag(xodetail.Invoice);

                                }
                                //if (detail.DepotPosition != null)
                                //{
                                //    stockAccessor.Increment(detail.DepotPosition, detail.Product, detail.InvoiceXSDetailQuantity.Value);
                                //    //更新产品库存                         

                                //    this.productManager.UpdateProduct_Stock(detail.Product);
                                //}
                                //临时注销客户产品
                                //Model.CustomerProducts p = detail.PrimaryKey;
                                //p.PrimaryKeyId = detail.PrimaryKey.PrimaryKeyId;
                                //if (p.DepotQuantity == null)
                                //    p.DepotQuantity = 0;
                                //if (p.OrderQuantity == null)
                                //    p.OrderQuantity = 0;
                                //p.DepotQuantity -= detail.InvoiceXSDetailQuantity;
                                //p.OrderQuantity += detail.InvoiceXSDetailQuantity;
                                //customerProductsAccessor.Update(p);
                            }
                            if (invoice.InvoiceXO != null)
                                this.invoiceXOManager.UpdateInvoiceFlag(invoice.InvoiceXO);
                            break;
                    }
                    break;
            }
        }

        private void Validate(Model.InvoiceXS invoice)
        {
            if (string.IsNullOrEmpty(invoice.InvoiceId))
                throw new Helper.RequireValueException("Id");

            if (invoice.Employee0 == null)
                throw new Helper.RequireValueException("Employee0");

            if (invoice.Customer == null)
                throw new Helper.RequireValueException("Company");

            //if (invoice.Depot == null)
            //    throw new Helper.RequireValueException("Depot");

            //foreach (Model.InvoiceXSDetail detail in invoice.Details)
            //{
            //    if (detail.DepotPositionId == null)
            //        throw new Helper.RequireValueException(Model.InvoiceXSDetail.PRO_DepotPositionId);
            //    //if (detail.PrimaryKey == null || string.IsNullOrEmpty(detail.PrimaryKey.PrimaryKeyId)) continue;                
            //    //if (detail.DepotPosition == null || string.IsNullOrEmpty(detail.DepotPositionId)) 
            //    //{
            //    //    throw new Helper.RequireValueException(Model.InvoiceXSDetail.PROPERTY_DEPOTPOSITIONID);
            //    //}
            //}

        }

        public IList<Model.InvoiceXS> Select(DateTime start, DateTime end, Model.Employee employee)
        {
            return accessor.Select(start, end, employee);
        }
        public IList<Book.Model.InvoiceXS> Select(DateTime start, DateTime end, string startId, string endId)
        {
            return accessor.Select(start, end, startId, endId);
        }
        public IList<Book.Model.InvoiceXS> Select1(DateTime start, DateTime end)
        {
            return accessor.Select1(start, end);
        }
        public IList<Book.Model.InvoiceXS> Select(Model.InvoiceXO invoicexo)
        {
            return accessor.Select(invoicexo);
        }
        public IList<Book.Model.InvoiceXS> Select(Model.Customer customer)
        {
            return accessor.Select(customer);
        }
        public IList<Book.Model.InvoiceXS> Select(string customerStart, string customerEnd, string productStart, string productEnd, DateTime dateStart, DateTime dateEnd)
        {
            return accessor.Select(customerStart, customerEnd, productStart, productEnd, dateStart, dateEnd);
        }
        public IList<Model.InvoiceXS> SelectInvoice(Model.Customer customer)
        {
            return accessor.SelectInvoice(customer);
        }
        public IList<Model.InvoiceXS> SelectCustomerInfo(string xoid)
        {
            return accessor.SelectCustomerInfo(xoid);
        }
        public IList<Book.Model.InvoiceXS> SelectDateRangAndWhere(Model.Customer customer, DateTime? dateStart, DateTime? dateEnd, string cusxoid, Model.Product product, string invoicexoid, string FreightedCompanyId, string ConveyanceMethodId)
        {
            return accessor.SelectDateRangAndWhere(customer, dateStart, dateEnd, cusxoid, product, invoicexoid, FreightedCompanyId, ConveyanceMethodId);
        }

        public string SelectByInvoiceCusID(string ID)
        {
            return accessor.SelectByInvoiceCusID(ID);
        }

        public DataTable SelectDateRangAndWhereToTable(Model.Customer customerStart, Model.Customer customerEnd, DateTime? dateStart, DateTime? dateEnd, DateTime yjrq1, DateTime yjrq2, string cusxoid, Model.Product product1, Model.Product product2, string invoicexoid1, string invoicexoid2, string FreightedCompanyId, string ConveyanceMethodId, Model.Employee startEmp, Model.Employee endEmp, string product_Id, string productCategoryId)
        {
            return accessor.SelectDateRangAndWhereToTable(customerStart, customerEnd, dateStart, dateEnd, yjrq1, yjrq2, cusxoid, product1, product2, invoicexoid1, invoicexoid2, FreightedCompanyId, ConveyanceMethodId, startEmp, endEmp, product_Id, productCategoryId);
        }

        public IList<Model.InvoiceXS> AmountStatistics(string employeeId, DateTime startDate, DateTime endDate, string currency)
        {
            return accessor.AmountStatistics(employeeId, startDate, endDate, currency);
        }
    }
}

