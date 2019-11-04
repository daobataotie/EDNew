﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：PronoteHeader.autogenerated.cs
// author: mayanjun
// create date：2012-2-4 11:43:54
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
    public partial class PronoteHeader
    {
        #region Data

        /// <summary>
        /// 编号
        /// </summary>
        private string _pronoteHeaderID;

        /// <summary>
        /// 编号2
        /// </summary>
        private string _employee0Id;

        /// <summary>
        /// 插入时间
        /// </summary>
        private DateTime? _insertTime;

        /// <summary>
        /// 修改时间
        /// </summary>
        private DateTime? _updateTime;

        /// <summary>
        /// 通知日期
        /// </summary>
        private DateTime? _pronoteDate;

        /// <summary>
        /// 备注
        /// </summary>
        private string _pronotedesc;

        /// <summary>
        /// 
        /// </summary>
        private bool? _checkeds;

        /// <summary>
        /// 
        /// </summary>
        private string _workHouseId;

        /// <summary>
        /// 
        /// </summary>
        private string _mRSHeaderId;

        /// <summary>
        /// 
        /// </summary>
        private double? _detailsSum;

        /// <summary>
        /// 
        /// </summary>
        private double? _inDepotQuantity;

        /// <summary>
        /// 
        /// </summary>
        private string _productId;

        /// <summary>
        /// 
        /// </summary>
        private string _productUnit;

        /// <summary>
        /// 
        /// </summary>
        private string _employee1Id;

        /// <summary>
        /// 
        /// </summary>
        private string _employee2Id;

        /// <summary>
        /// 
        /// </summary>
        private bool? _isBuildMaterial;

        /// <summary>
        /// 
        /// </summary>
        private string _invoiceXOId;

        /// <summary>
        /// 
        /// </summary>
        private int? _invoiceStatus;

        /// <summary>
        /// 
        /// </summary>
        private string _mRSdetailsId;

        /// <summary>
        /// 销售订单数量
        /// </summary>
        private double? _invoiceXODetailQuantity;

        /// <summary>
        /// 
        /// </summary>
        private string _invoiceCusId;

        /// <summary>
        /// 
        /// </summary>
        private int? _auditState;

        /// <summary>
        /// 
        /// </summary>
        private string _auditEmpId;

        private double? _materialprocessum;

        /// <summary>
        /// 员工
        /// </summary>
        private Employee _employee1;
        /// <summary>
        /// 员工
        /// </summary>
        private Employee _employee2;
        /// <summary>
        /// 员工
        /// </summary>
        private Employee _auditEmp;
        /// <summary>
        /// 产品
        /// </summary>
        private Product _product;
        /// <summary>
        /// 员工
        /// </summary>
        private Employee _employee0;
        /// <summary>
        /// 工作中心
        /// </summary>
        private WorkHouse _workHouse;

        private string _chakuang;

        private string _paihe;

        private string _moshu;

        private string _invoiceType;
        #endregion

        #region Properties

        /// <summary>
        /// 编号
        /// </summary>
        public string PronoteHeaderID
        {
            get
            {
                return this._pronoteHeaderID;
            }
            set
            {
                this._pronoteHeaderID = value;
            }
        }

        /// <summary>
        /// 编号2
        /// </summary>
        public string Employee0Id
        {
            get
            {
                return this._employee0Id;
            }
            set
            {
                this._employee0Id = value;
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
        /// 通知日期
        /// </summary>
        public DateTime? PronoteDate
        {
            get
            {
                return this._pronoteDate;
            }
            set
            {
                this._pronoteDate = value;
            }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Pronotedesc
        {
            get
            {
                return this._pronotedesc;
            }
            set
            {
                this._pronotedesc = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool? Checkeds
        {
            get
            {
                return this._checkeds;
            }
            set
            {
                this._checkeds = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string WorkHouseId
        {
            get
            {
                return this._workHouseId;
            }
            set
            {
                this._workHouseId = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string MRSHeaderId
        {
            get
            {
                return this._mRSHeaderId;
            }
            set
            {
                this._mRSHeaderId = value;
            }
        }

        /// <summary>
        /// 生产数量
        /// </summary>
        public double? DetailsSum
        {
            get
            {
                return this._detailsSum;
            }
            set
            {
                this._detailsSum = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double? InDepotQuantity
        {
            get
            {
                return this._inDepotQuantity;
            }
            set
            {
                this._inDepotQuantity = value;
            }
        }

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        public string ProductUnit
        {
            get
            {
                return this._productUnit;
            }
            set
            {
                this._productUnit = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Employee1Id
        {
            get
            {
                return this._employee1Id;
            }
            set
            {
                this._employee1Id = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Employee2Id
        {
            get
            {
                return this._employee2Id;
            }
            set
            {
                this._employee2Id = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool? IsBuildMaterial
        {
            get
            {
                return this._isBuildMaterial;
            }
            set
            {
                this._isBuildMaterial = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string InvoiceXOId
        {
            get
            {
                return this._invoiceXOId;
            }
            set
            {
                this._invoiceXOId = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int? InvoiceStatus
        {
            get
            {
                return this._invoiceStatus;
            }
            set
            {
                this._invoiceStatus = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string MRSdetailsId
        {
            get
            {
                return this._mRSdetailsId;
            }
            set
            {
                this._mRSdetailsId = value;
            }
        }

        /// <summary>
        /// 销售订单数量
        /// </summary>
        public double? InvoiceXODetailQuantity
        {
            get
            {
                return this._invoiceXODetailQuantity;
            }
            set
            {
                this._invoiceXODetailQuantity = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string InvoiceCusId
        {
            get
            {
                return this._invoiceCusId;
            }
            set
            {
                this._invoiceCusId = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int? AuditState
        {
            get
            {
                return this._auditState;
            }
            set
            {
                this._auditState = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string AuditEmpId
        {
            get
            {
                return this._auditEmpId;
            }
            set
            {
                this._auditEmpId = value;
            }
        }

        /// <summary>
        /// 员工
        /// </summary>
        public virtual Employee Employee1
        {
            get
            {
                return this._employee1;
            }
            set
            {
                this._employee1 = value;
            }

        }
        /// <summary>
        /// 员工
        /// </summary>
        public virtual Employee Employee2
        {
            get
            {
                return this._employee2;
            }
            set
            {
                this._employee2 = value;
            }

        }
        /// <summary>
        /// 员工
        /// </summary>
        public virtual Employee AuditEmp
        {
            get
            {
                return this._auditEmp;
            }
            set
            {
                this._auditEmp = value;
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
        /// 员工
        /// </summary>
        public virtual Employee Employee0
        {
            get
            {
                return this._employee0;
            }
            set
            {
                this._employee0 = value;
            }

        }
        /// <summary>
        /// 工作中心
        /// </summary>
        public virtual WorkHouse WorkHouse
        {
            get
            {
                return this._workHouse;
            }
            set
            {
                this._workHouse = value;
            }
        }
        /// <summary>
        /// 是否结案
        /// </summary>
        private bool? _isClose;
        public bool? IsClose
        {
            get
            {
                return _isClose;
            }
            set { this._isClose = value; }
        }

        /// <summary>
        /// 结案日期
        /// </summary>
        private DateTime? _JieAnDate;

        /// <summary>
        /// 结案日期
        /// </summary>
        public DateTime? JieAnDate
        {
            get { return _JieAnDate; }
            set { _JieAnDate = value; }
        }

        public string Chakuang
        {
            get { return _chakuang; }
            set { _chakuang = value; }
        }

        public string Paihe
        {
            get { return _paihe; }
            set { _paihe = value; }
        }

        public string Moshu
        {
            get { return _moshu; }
            set { _moshu = value; }
        }

        /// <summary>
        /// 单据类型：0为生产加工（自製），1为组装加工（自製(組裝)），2为加工指示（自製(半成品加工)）
        /// </summary>
        public string InvoiceType
        {
            get { return _invoiceType; }
            set { _invoiceType = value; }
        }

        /// <summary>
        /// 领料单数量
        /// </summary>
        public double? Materialprocessum
        {
            get { return _materialprocessum; }
            set { _materialprocessum = value; }
        }

        /// <summary>
        /// 编号
        /// </summary>
        public readonly static string PRO_PronoteHeaderID = "PronoteHeaderID";

        /// <summary>
        /// 编号2
        /// </summary>
        public readonly static string PRO_Employee0Id = "Employee0Id";

        /// <summary>
        /// 插入时间
        /// </summary>
        public readonly static string PRO_InsertTime = "InsertTime";

        /// <summary>
        /// 修改时间
        /// </summary>
        public readonly static string PRO_UpdateTime = "UpdateTime";

        /// <summary>
        /// 通知日期
        /// </summary>
        public readonly static string PRO_PronoteDate = "PronoteDate";

        /// <summary>
        /// 备注
        /// </summary>
        public readonly static string PRO_Pronotedesc = "Pronotedesc";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_Checkeds = "Checkeds";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_WorkHouseId = "WorkHouseId";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_MRSHeaderId = "MRSHeaderId";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_DetailsSum = "DetailsSum";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_InDepotQuantity = "InDepotQuantity";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_ProductId = "ProductId";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_ProductUnit = "ProductUnit";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_Employee1Id = "Employee1Id";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_Employee2Id = "Employee2Id";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_IsBuildMaterial = "IsBuildMaterial";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_InvoiceXOId = "InvoiceXOId";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_InvoiceStatus = "InvoiceStatus";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_MRSdetailsId = "MRSdetailsId";

        /// <summary>
        /// 销售订单数量
        /// </summary>
        public readonly static string PRO_InvoiceXODetailQuantity = "InvoiceXODetailQuantity";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_InvoiceCusId = "InvoiceCusId";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_AuditState = "AuditState";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_AuditEmpId = "AuditEmpId";

        public readonly static string PRO_Chakuang = "Chakuang";

        public readonly static string PRO_Paihe = "Paihe";

        public readonly static string PRO_Moshu = "Moshu";

        public readonly static string PRO_InvoiceType = "InvoiceType";

        public readonly static string PRO_Materialprocessum = "Materialprocessum";
        #endregion
    }
}
