﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：SupplierProduct.autogenerated.cs
// author: mayanjun
// create date：2013/2/5 10:56:26
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
    public partial class SupplierProduct
    {
        #region Data

        /// <summary>
        /// 主键编号
        /// </summary>
        private string _supplierProductId;

        /// <summary>
        /// 供应商编号
        /// </summary>
        private string _supplierId;

        /// <summary>
        /// 编号
        /// </summary>
        private string _employeeId;

        /// <summary>
        /// 商品编号
        /// </summary>
        private string _productId;

        /// <summary>
        /// 插入时间
        /// </summary>
        private DateTime? _insertTime;

        /// <summary>
        /// 修改时间
        /// </summary>
        private DateTime? _updateTime;

        /// <summary>
        /// 手动编号
        /// </summary>
        private string _iDNo;

        /// <summary>
        /// 价格区间
        /// </summary>
        private string _supplierProductPriceRange;

        /// <summary>
        /// 
        /// </summary>
        private string _atCurrencyCategoryId;

        /// <summary>
        /// 备注
        /// </summary>
        private string _note;
        /// <summary>
        /// 建档人
        /// </summary>
        private string _buildEmployeeId;

        /// <summary>
        /// 变更人
        /// </summary>
        private string _changeEmployeeId;

        private Employee _buildEmployee;

        private Employee _changeEmployee;

        /// <summary>
        /// 员工
        /// </summary>
        private Employee _employee;
        /// <summary>
        /// 产品
        /// </summary>
        private Product _product;
        /// <summary>
        /// 供应商
        /// </summary>
        private Supplier _supplier;
        /// <summary>
        /// 币种类别
        /// </summary>
        private AtCurrencyCategory _atCurrencyCategory;

        #endregion

        #region Properties

        /// <summary>
        /// 主键编号
        /// </summary>
        public string SupplierProductId
        {
            get
            {
                return this._supplierProductId;
            }
            set
            {
                this._supplierProductId = value;
            }
        }

        /// <summary>
        /// 供应商编号
        /// </summary>
        public string SupplierId
        {
            get
            {
                return this._supplierId;
            }
            set
            {
                this._supplierId = value;
            }
        }

        /// <summary>
        /// 编号
        /// </summary>
        public string EmployeeId
        {
            get
            {
                return this._employeeId;
            }
            set
            {
                this._employeeId = value;
            }
        }

        /// <summary>
        /// 商品编号
        /// </summary>
        public string ProductId
        {
            get
            {
                return this._productId;
            }
            set
            {
                this._productId = value;
            }
        }

        /// <summary>
        /// 插入时间
        /// </summary>
        public DateTime? InsertTime
        {
            get
            {
                return this._insertTime;
            }
            set
            {
                this._insertTime = value;
            }
        }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? UpdateTime
        {
            get
            {
                return this._updateTime;
            }
            set
            {
                this._updateTime = value;
            }
        }

        /// <summary>
        /// 手动编号
        /// </summary>
        public string IDNo
        {
            get
            {
                return this._iDNo;
            }
            set
            {
                this._iDNo = value;
            }
        }

        /// <summary>
        /// 价格区间
        /// </summary>
        public string SupplierProductPriceRange
        {
            get
            {
                return this._supplierProductPriceRange;
            }
            set
            {
                this._supplierProductPriceRange = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string AtCurrencyCategoryId
        {
            get
            {
                return this._atCurrencyCategoryId;
            }
            set
            {
                this._atCurrencyCategoryId = value;
            }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }
        /// <summary>
        /// 建档人
        /// </summary>
        public string BuildEmployeeId
        {
            get { return _buildEmployeeId; }
            set { _buildEmployeeId = value; }
        }

        /// <summary>
        /// 变更人
        /// </summary>
        public string ChangeEmployeeId
        {
            get { return _changeEmployeeId; }
            set { _changeEmployeeId = value; }
        }

        public Employee BuildEmployee
        {
            get { return _buildEmployee; }
            set { _buildEmployee = value; }
        }

        public Employee ChangeEmployee
        {
            get { return _changeEmployee; }
            set { _changeEmployee = value; }
        }

        /// <summary>
        /// 员工
        /// </summary>
        public virtual Employee Employee
        {
            get
            {
                return this._employee;
            }
            set
            {
                this._employee = value;
            }

        }
        /// <summary>
        /// 产品
        /// </summary>
        public virtual Product Product
        {
            get
            {
                return this._product;
            }
            set
            {
                this._product = value;
            }

        }
        /// <summary>
        /// 供应商
        /// </summary>
        public virtual Supplier Supplier
        {
            get
            {
                return this._supplier;
            }
            set
            {
                this._supplier = value;
            }

        }
        /// <summary>
        /// 币种类别
        /// </summary>
        public virtual AtCurrencyCategory AtCurrencyCategory
        {
            get
            {
                return this._atCurrencyCategory;
            }
            set
            {
                this._atCurrencyCategory = value;
            }

        }
        /// <summary>
        /// 主键编号
        /// </summary>
        public readonly static string PRO_SupplierProductId = "SupplierProductId";

        /// <summary>
        /// 供应商编号
        /// </summary>
        public readonly static string PRO_SupplierId = "SupplierId";

        /// <summary>
        /// 编号
        /// </summary>
        public readonly static string PRO_EmployeeId = "EmployeeId";

        /// <summary>
        /// 商品编号
        /// </summary>
        public readonly static string PRO_ProductId = "ProductId";

        /// <summary>
        /// 插入时间
        /// </summary>
        public readonly static string PRO_InsertTime = "InsertTime";

        /// <summary>
        /// 修改时间
        /// </summary>
        public readonly static string PRO_UpdateTime = "UpdateTime";

        /// <summary>
        /// 手动编号
        /// </summary>
        public readonly static string PRO_IDNo = "IDNo";

        /// <summary>
        /// 价格区间
        /// </summary>
        public readonly static string PRO_SupplierProductPriceRange = "SupplierProductPriceRange";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_AtCurrencyCategoryId = "AtCurrencyCategoryId";

        /// <summary>
        /// 备注
        /// </summary>
        public readonly static string PRO_Note = "Note";

        public readonly static string PRO_BuildEmployeeId = "BuildEmployeeId";

        public readonly static string PRO_ChangeEmployeeId = "ChangeEmployeeId";
        #endregion
    }
}
