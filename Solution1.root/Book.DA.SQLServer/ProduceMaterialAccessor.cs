﻿//------------------------------------------------------------------------------
//
// file name：ProduceMaterialAccessor.cs
// author: peidun
// create date：2009-12-30 16:33:31
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
    /// Data accessor of ProduceMaterial
    /// </summary>
    public partial class ProduceMaterialAccessor : EntityAccessor, IProduceMaterialAccessor
    {
        // 根据来源编号查询  0加工单 1物料需求      
        public IList<Model.ProduceMaterial> SelectInvoiceId(string invoiceid)
        {
            string sql = "SELECT p.*,e.EmployeeName as Employee0Name,ee.EmployeeName as AuditEmpName ,w.Workhousename as Workhousename FROM ProduceMaterial p left join employee e on p.Employee0Id=e.EmployeeId left join employee ee on p.AuditEmpId=ee.EmployeeId left join WorkHouse w on p.WorkHouseId=w.WorkHouseId WHERE InvoiceId='" + invoiceid + "'";
            return this.DataReaderBind<Model.ProduceMaterial>(sql.ToString(), null, CommandType.Text);
        }

        public IList<Model.ProduceMaterial> SelectByInvoiceIdList(string invoiceidList)
        {
            string sql = "SELECT p.*,e.EmployeeName as Employee0Name,ee.EmployeeName as AuditEmpName ,w.Workhousename as Workhousename FROM ProduceMaterial p left join employee e on p.Employee0Id=e.EmployeeId left join employee ee on p.AuditEmpId=ee.EmployeeId left join WorkHouse w on p.WorkHouseId=w.WorkHouseId WHERE InvoiceId in " + invoiceidList;
            return this.DataReaderBind<Model.ProduceMaterial>(sql.ToString(), null, CommandType.Text);
        }

        public IList<Model.ProduceMaterial> SelectState()
        {
            return sqlmapper.QueryForList<Model.ProduceMaterial>("ProduceMaterial.select_byState", null);
        }

        //public void UpdateProduceMaterial(DataTable dt)
        //{
        //    SqlConnection conn = new SqlConnection(sqlmapper.DataSource.ConnectionString);
        //    SqlDataAdapter dataAdapter = new SqlDataAdapter();
        //    dataAdapter.UpdateCommand = new SqlCommand("UPDATE ProduceMaterial SET Employee0Id=@Employee0Id,UpdateTime=GETDATE() WHERE ProduceMaterialID=@ProduceMaterialID", conn);
        //    dataAdapter.UpdateCommand.Parameters.Add(new SqlParameter("@Employee0Id", SqlDbType.VarChar, 50, "Employee0Id"));
        //    dataAdapter.UpdateCommand.Parameters.Add(new SqlParameter("@ProduceMaterialID", SqlDbType.VarChar, 50, "ProduceMaterialID"));
        //    dataAdapter.Update(dt);
        //}

        /// <summary>
        /// 0查询全被 1只查询未出仓
        /// </summary>
        /// <param name="startdate"></param>
        /// <param name="enddate"></param>
        /// <param name="product"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public IList<Model.ProduceMaterial> SelectByDateRage(DateTime startdate, DateTime enddate, Model.Product product, bool isNoClose)
        {
            Hashtable ht = new Hashtable();
            ht.Add("startdate", startdate);
            ht.Add("enddate", enddate);
            StringBuilder str = new StringBuilder();
            if (product != null)
                str.Append(" and ProduceMaterialId in(select ProduceMaterialId from ProduceMaterialdetails where productid='" + product.ProductId + "')");
            if (isNoClose)
                str.Append(" and (DepotOutState<>2 or DepotOutState is null)");
            ht.Add("sql", str);
            return sqlmapper.QueryForList<Model.ProduceMaterial>("ProduceMaterial.selectByDateRage", ht);
        }

        public bool ExistsId(string id)
        {
            return sqlmapper.QueryForObject<bool>("ProduceMaterial.existsId", id);
        }

        public IList<Book.Model.ProduceMaterial> SelectBycondition(DateTime startDate, DateTime endDate, string produceMaterialId0, string produceMaterialId1, Book.Model.Product pId0, Book.Model.Product pId1, string departmentId0, string departmentId1, string PronoteHeaderId0, string PronoteHeaderId1, string CusInvoiceXOId, string customerId)
        {
            SqlParameter[] parames = { 
                    new SqlParameter("@startDate", DbType.DateTime), 
                    new SqlParameter("@endDate", DbType.DateTime), 
                    new SqlParameter("@produceMaterialId0", DbType.String), 
                    new SqlParameter("@produceMaterialId1", DbType.String),
                    new SqlParameter("@pId0", DbType.String), 
                    new SqlParameter("@pId1", DbType.String), 
                    new SqlParameter("@departmentId0", DbType.String), 
                    new SqlParameter("@departmentId1", DbType.String),
                    new SqlParameter("@PronoteHeaderId0", DbType.String), 
                    new SqlParameter("@PronoteHeaderId1", DbType.String),
                    new SqlParameter("@CusInvoiceXOId",DbType.String),
                    new SqlParameter("@CustomerId",DbType.String)
                                     };

            parames[0].Value = startDate;
            parames[1].Value = endDate;
            if (!string.IsNullOrEmpty(produceMaterialId0))
                parames[2].Value = produceMaterialId0;
            else
                parames[2].Value = DBNull.Value;

            if (!string.IsNullOrEmpty(produceMaterialId1))
                parames[3].Value = produceMaterialId1;
            else
                parames[3].Value = DBNull.Value; ;

            if (pId0 != null)
                parames[4].Value = pId0.Id;
            else
                parames[4].Value = DBNull.Value;
            if (pId1 != null)
                parames[5].Value = pId1.Id;
            else
                parames[5].Value = DBNull.Value;

            if (departmentId0 != null)
                parames[6].Value = departmentId0;
            else
                parames[6].Value = DBNull.Value;

            if (departmentId1 != null)
                parames[7].Value = departmentId1;
            else
                parames[7].Value = DBNull.Value;

            if (PronoteHeaderId0 != null)
                parames[8].Value = PronoteHeaderId0;
            else
                parames[8].Value = DBNull.Value;
            if (PronoteHeaderId1 != null)
                parames[9].Value = PronoteHeaderId1;
            else
                parames[9].Value = DBNull.Value;

            if (!string.IsNullOrEmpty(CusInvoiceXOId))
                parames[10].Value = CusInvoiceXOId;
            else
                parames[10].Value = DBNull.Value;

            if (!string.IsNullOrEmpty(customerId))
                parames[11].Value = customerId;
            else
                parames[11].Value = DBNull.Value;
            //  sql.Append(" from ProduceMaterial p left join  Workhouse w on w.WorkHouseId=p.WorkHouseId right join ProduceMaterialdetails d on p.ProduceMaterialID = d.ProduceMaterialID left join Product pro on d.ProductId = pro.ProductId");

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT  w.Workhousename as WorkhouseName,p.*  ");
            sql.Append(", (SELECT ProductName+'{'+CustomerProductName+'}' FROM Product WHERE Product.ProductId = (SELECT PronoteHeader.ProductId FROM PronoteHeader WHERE PronoteHeader.PronoteHeaderID = p.InvoiceId)) AS ParenProductName");
            sql.Append(", (SELECT  EmployeeName FROM employee where employee.employeeid=p.Employee0Id) as Employee0Name, (select  EmployeeName from employee where employee.employeeid=p.Employee1Id) as Employee1Name,(SELECT  EmployeeName FROM employee where employee.employeeid=p.AuditEmpId) as AuditEmpName");
            sql.Append(", (SELECT  CustomerInvoiceXOId FROM invoiceXO where invoiceXO.invoiceId=p.InvoiceXOId) as CusXOId ");
            sql.Append(" from ProduceMaterial p left join  Workhouse w on w.WorkHouseId=p.WorkHouseId ");
            sql.Append("  WHERE p.ProduceMaterialDate between @startDate  and @endDate ");
            if (!string.IsNullOrEmpty(produceMaterialId0) && !string.IsNullOrEmpty(produceMaterialId1))
                sql.Append("  AND p.ProduceMaterialID between @produceMaterialId0  and @produceMaterialId1 ");
            if (pId0 != null && pId1 != null)
                sql.Append("  AND p.ProduceMaterialID IN (SELECT ProduceMaterialID FROM ProduceMaterialdetails WHERE ProductId IN (SELECT ProductId FROM Product WHERE Id between @pId0 and @pId1))");
            //if (!string.IsNullOrEmpty(departmentId0) && !string.IsNullOrEmpty(departmentId1))
            //    sql.Append(" and p.Workhousename between @departmentId0 and @departmentId1");
            if (!string.IsNullOrEmpty(departmentId0))
            {
                sql.Append(" AND p.WorkHouseId = '" + departmentId0 + "'");
            }
            if (!string.IsNullOrEmpty(PronoteHeaderId0) && !string.IsNullOrEmpty(PronoteHeaderId1))
                sql.Append(" AND p.InvoiceId between @PronoteHeaderId0 and @PronoteHeaderId1");
            if (!string.IsNullOrEmpty(CusInvoiceXOId))
                sql.Append(" AND InvoiceXOId = (SELECT InvoiceId FROM InvoiceXO WHERE CustomerInvoiceXOId = @CusInvoiceXOId)");
            if (!string.IsNullOrEmpty(customerId))
                sql.Append(" and p.InvoiceXOId in (select InvoiceId from InvoiceXO where CustomerId=@CustomerId)");
            sql.Append(" order by p.ProduceMaterialID desc ");
            return this.DataReaderBind<Model.ProduceMaterial>(sql.ToString(), parames, CommandType.Text);
            //Hashtable ht = new Hashtable();
            //ht.Add("starDate", startDate);
            //ht.Add("endDate", endDate);
            //ht.Add("produceMaterialId0", produceMaterialId0);
            //ht.Add("produceMaterialId1", produceMaterialId1);
            //ht.Add("pId0", pId0 == null ? null : pId0.ProductName);
            //ht.Add("pId1", pId1 == null ? null : pId1.ProductName);
            //ht.Add("dId0", departmentId0);
            //ht.Add("dId1", departmentId1);
            //ht.Add("pronoteId0", PronoteHeaderId0);
            //ht.Add("pronoteId1", PronoteHeaderId1);
            //return sqlmapper.QueryForList<Model.ProduceMaterial>("ProduceMaterial.selectBycondition", ht);
        }

        public string SelectByInvoiceCusID(string ID)
        {
            return sqlmapper.QueryForObject<string>("ProduceMaterial.SelectByInvoiceCusID", ID);
        }

        public bool IsDepotOut(string id)
        {
            return sqlmapper.QueryForObject<bool>("ProduceMaterial.IsDepotOut", id);
        }
    }
}
