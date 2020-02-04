//------------------------------------------------------------------------------
//
// file name:InvoiceXSAccessor.cs
// author: peidun
// create date:2008/6/6 10:00:50
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Book.DA.SQLServer
{
    /// <summary>
    /// Data accessor of InvoiceXS
    /// </summary>
    public partial class InvoiceXSAccessor : EntityAccessor, IInvoiceXSAccessor
    {
        public IList<Book.Model.InvoiceXS> Select(DateTime start, DateTime end)
        {
            Hashtable pars = new Hashtable();
            pars.Add("startTime", start);
            pars.Add("endTime", end);
            return sqlmapper.QueryForList<Model.InvoiceXS>("InvoiceXS.select_byTime", pars);
        }

        public void OwedIncrement(Book.Model.InvoiceXS invoice, decimal money)
        {
            this.OwedIncrement(invoice.InvoiceId, money);
        }

        public void OwedDecrement(Book.Model.InvoiceXS invoice, decimal money)
        {
            this.OwedDecrement(invoice.InvoiceId, money);
        }

        public void OwedIncrement(Book.Model.InvoiceXS invoice, decimal? money)
        {
            this.OwedDecrement(invoice.InvoiceId, money.Value);
        }

        public void OwedDecrement(Book.Model.InvoiceXS invoice, decimal? money)
        {
            this.OwedDecrement(invoice.InvoiceId, money.Value);
        }

        public void OwedIncrement(string invoiceId, decimal money)
        {
            System.Collections.Hashtable paras = new Hashtable();
            paras.Add("InvoiceOwed", money);
            paras.Add("InvoiceId", invoiceId);
            sqlmapper.Update("InvoiceCT.owedincrement", paras);
        }

        public void OwedDecrement(string invoiceId, decimal money)
        {
            System.Collections.Hashtable paras = new Hashtable();
            paras.Add("InvoiceOwed", money);
            paras.Add("InvoiceId", invoiceId);
            sqlmapper.Update("InvoiceXS.oweddecrement", paras);
        }

        public void OwedIncrement(string invoiceId, decimal? money)
        {
            this.OwedIncrement(invoiceId, money.Value);
        }

        public void OwedDecrement(string invoiceId, decimal? money)
        {
            this.OwedDecrement(invoiceId, money.Value);
        }

        public IList<Book.Model.InvoiceXS> Select(Helper.InvoiceStatus status)
        {
            return sqlmapper.QueryForList<Model.InvoiceXS>("InvoiceXS.select_byStatus", (int)status);
        }

        public IList<Book.Model.InvoiceXS> Select(DateTime start, DateTime end, Book.Model.Employee employee)
        {
            Hashtable pars = new Hashtable();
            pars.Add("start", start);
            pars.Add("end", end);
            pars.Add("EmployeeId", employee.EmployeeId);
            return sqlmapper.QueryForList<Book.Model.InvoiceXS>("InvoiceXS.select_byDateRengeAndEmployee0", pars);
        }

        public IList<Book.Model.InvoiceXS> Select(DateTime start, DateTime end, string startId, string endId)
        {
            Hashtable pars = new Hashtable();
            pars.Add("start", start);
            pars.Add("end", end);
            pars.Add("startId", startId);
            pars.Add("endId", endId);
            return sqlmapper.QueryForList<Book.Model.InvoiceXS>("InvoiceXS.select_byDateRengeAndCompanyIdRenge", pars);
        }

        public IList<Book.Model.InvoiceXS> Select1(DateTime start, DateTime end)
        {
            Hashtable pars = new Hashtable();
            pars.Add("start", start);
            pars.Add("end", end);
            return sqlmapper.QueryForList<Book.Model.InvoiceXS>("InvoiceXS.select_byDateRenge", pars);
        }

        public IList<Book.Model.InvoiceXS> Select(Model.InvoiceXO invoicexo)
        {
            return sqlmapper.QueryForList<Book.Model.InvoiceXS>("InvoiceXS.select_byDateXOId", invoicexo.InvoiceId);
        }

        public IList<Book.Model.InvoiceXS> Select(Model.Customer customer)
        {
            return sqlmapper.QueryForList<Book.Model.InvoiceXS>("InvoiceXS.select_bycustomerId", customer.CustomerId);
        }

        public IList<Book.Model.InvoiceXS> Select(string customerStart, string customerEnd, string productStart, string productEnd, DateTime dateStart, DateTime dateEnd)
        {
            IList<Book.Model.InvoiceXS> invoiceXS;
            Hashtable ht = new Hashtable();
            ht.Add("customerStart", customerStart);
            ht.Add("customerEnd", customerEnd);
            ht.Add("productStart", productStart);
            ht.Add("productEnd", productEnd);
            ht.Add("dateStart", dateStart);
            ht.Add("dateEnd", dateEnd);
            if (string.IsNullOrEmpty(productEnd))
                invoiceXS = sqlmapper.QueryForList<Book.Model.InvoiceXS>("InvoiceXS.selectbydateProENDNUll", ht);
            else
                invoiceXS = sqlmapper.QueryForList<Book.Model.InvoiceXS>("InvoiceXS.selectbydatePro", ht);

            return invoiceXS;
        }

        public IList<Model.InvoiceXS> SelectInvoice(Model.Customer customer)
        {
            return sqlmapper.QueryForList<Model.InvoiceXS>("InvoiceXS.selectByCustomerId", customer.CustomerId);
        }

        public IList<Model.InvoiceXS> SelectCustomerInfo(string xoid)
        {
            return sqlmapper.QueryForList<Model.InvoiceXS>("InvoiceXS.selectCustomerInfo", xoid);
        }

        public IList<Book.Model.InvoiceXS> SelectDateRangAndWhere(Model.Customer customer, DateTime? dateStart, DateTime? dateEnd, string cusxoid, Model.Product product, string invoicexoid, string FreightedCompanyId, string ConveyanceMethodId)
        {
            Hashtable ht = new Hashtable();
            ht.Add("dateStart", dateStart);
            ht.Add("dateEnd", dateEnd);
            StringBuilder sql = new StringBuilder();
            if (customer != null)
                sql.Append(" and  customerid='" + customer.CustomerId + "'");
            if (!string.IsNullOrEmpty(cusxoid))
                sql.Append(" and  InvoiceId in(select invoiceid from invoicexsdetail where invoicexoid in(select invoiceid from invoicexo where  CustomerInvoiceXOId like '%" + cusxoid + "%' ))");
            if (!string.IsNullOrEmpty(invoicexoid))
                sql.Append(" and  InvoiceId in(select invoiceid from invoicexsdetail where invoicexoid='" + invoicexoid + "')");
            if (product != null)
                sql.Append(" and  InvoiceId in(select invoiceid from invoicexsdetail where productid='" + product.ProductId + "')  ");
            //if (IsForeigntrade == true)
            //    sql.Append(" AND InvoiceXS.InvoiceId IN (SELECT InvoiceXSDetail.InvoiceId FROM InvoiceXSDetail WHERE InvoiceXOId IN (SELECT InvoiceXO.InvoiceId FROM InvoiceXO WHERE IsForeigntrade=1))");
            if (!string.IsNullOrEmpty(FreightedCompanyId))
                sql.Append(" and  InvoiceId in(select invoiceid from InvoiceXS where  TransportCompany='" + FreightedCompanyId + "') ");
            if (!string.IsNullOrEmpty(ConveyanceMethodId))
                sql.Append(" and  InvoiceId in(select invoiceid from InvoiceXS where  ConveyanceMethodId='" + ConveyanceMethodId + "')");
            ht.Add("sql", sql.ToString());
            return sqlmapper.QueryForList<Book.Model.InvoiceXS>("InvoiceXS.select_where", ht);
        }

        public string SelectByInvoiceCusID(string ID)
        {
            return sqlmapper.QueryForObject<string>("InvoiceXS.SelectByInvoiceCusID", ID);
        }

        public DataTable SelectDateRangAndWhereToTable(Model.Customer customerStart, Model.Customer customerEnd, DateTime? dateStart, DateTime? dateEnd, DateTime yjrq1, DateTime yjrq2, string cusxoid, Model.Product product1, Model.Product product2, string invoicexoid1, string invoicexoid2, string FreightedCompanyId, string ConveyanceMethodId, Model.Employee startEmp, Model.Employee endEmp, string product_Id, string productCategoryId)
        {
            StringBuilder sql = new StringBuilder(
@"select xs.InvoiceId,xs.InvoiceDate,xs.InvoiceNote,c.CustomerShortName as Customer,e.EmployeeName as Employee0,dp.DepotName as Depot,xo.CustomerInvoiceXOId,isnull(xsd.InvoiceXSDetailPrice*xsd.InvoiceXSDetailQuantity,0)*(case when Donatetowards=1 then 0 else 1 end) as XOMoney,ISNULL(xsd.InvoiceXSDetailPrice*xsd.InvoiceXSDetailQuantity*(case when ExchangeRate = 0 then 1 when ExchangeRate is null then 1 else ExchangeRate end),0)*(case when Donatetowards=1 then 0 else 1 end) as XSMoney from InvoiceXSDetail xsd left join InvoiceXS xs on xs.InvoiceId=xsd.InvoiceId
left join InvoiceXO xo on xo.InvoiceId=xsd.InvoiceXOId
left join Depot dp on dp.DepotId=xs.DepotId
left join Employee e on e.EmployeeId=xs.Employee0Id
left join Customer c on c.CustomerId=xs.CustomerId");


            sql.Append(" where (xs.InvoiceStatus<>2 or xs.InvoiceStatus is null) and (xs.InvoiceDate between '" + dateStart.Value.ToString("yyyy-MM-dd") + "' and '" + dateEnd.Value.ToString("yyyy-MM-dd HH:mm:ss") + "')");

            if (customerStart != null && customerEnd != null)
                sql.Append(" and  xs.customerid in (select CustomerId from Customer where Id between '" + customerStart.Id + "' and '" + customerEnd.Id + "')");
            if (yjrq1 != global::Helper.DateTimeParse.NullDate && yjrq2 != global::Helper.DateTimeParse.EndDate)
                sql.Append(" and xsd.InvoiceXOId in (select InvoiceId from InvoiceXO where InvoiceYjrq between '" + yjrq1.ToString("yyyy-MM-dd") + "' and '" + yjrq2.ToString("yyyy-MM-dd HH:mm:ss") + "')");
            if (!string.IsNullOrEmpty(cusxoid))
                sql.Append(" and xsd.InvoiceXOId in(select invoiceid from invoicexo where  CustomerInvoiceXOId = '" + cusxoid + "' )");
            if (!string.IsNullOrEmpty(invoicexoid1) && !string.IsNullOrEmpty(invoicexoid2))
                sql.Append(" and xs.InvoiceId between '" + invoicexoid1 + "' and '" + invoicexoid2 + "'");
            if (product1 != null && product2 != null)
                sql.Append(" and xsd.productid in (select ProductId from Product where Id between '" + product1.Id + "' and '" + product2.Id + "') ");
            if (startEmp != null && endEmp != null)
            {
                sql.Append(" And xs.Employee0Id in (select EmployeeId from Employee where IDNo between '" + startEmp.IDNo + "' and '" + endEmp.IDNo + "')");
            }
            if (!string.IsNullOrEmpty(FreightedCompanyId))
                sql.Append(" and  xs.TransportCompany='" + FreightedCompanyId + "'");
            if (!string.IsNullOrEmpty(ConveyanceMethodId))
                sql.Append(" and  xs.ConveyanceMethodId='" + ConveyanceMethodId + "'");
            if (!string.IsNullOrEmpty(product_Id))
                sql.Append(" and xsd.ProductId in (select ProductId from Product where Id='" + product_Id + "')");
            if (!string.IsNullOrEmpty(productCategoryId))
                sql.Append(" and xsd.productId in (select ProductId from Product where ProductCategoryId='" + productCategoryId + "') ");

            sql.Append(" order by xs.InvoiceId");

            SqlDataAdapter sda = new SqlDataAdapter(sql.ToString(), sqlmapper.DataSource.ConnectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            return dt;
        }

        public IList<Model.InvoiceXS> AmountStatistics(string employeeId, DateTime startDate, DateTime endDate, string currency)
        {
            string sql = "select InvoiceTotal,InvoiceDate from InvoiceXS where Employee0Id='" + employeeId + "' and InvoiceDate between '" + startDate.ToString("yyyy-MM-dd") + "' and '" + endDate.Date.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss") + "' and Currency='" + currency + "' and InvoiceTotal >0";

            return this.DataReaderBind<Model.InvoiceXS>(sql, null, CommandType.Text);
        }
    }
}
