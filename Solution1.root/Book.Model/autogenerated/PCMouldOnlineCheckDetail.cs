﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：PCMouldOnlineCheckDetail.autogenerated.cs
// author: mayanjun
// create date：2015/4/13 上午 10:11:44
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
    public partial class PCMouldOnlineCheckDetail
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private string _pCMouldOnlineCheckDetailId;

        /// <summary>
        /// 
        /// </summary>
        private string _pCMouldOnlineCheckId;

        /// <summary>
        /// 
        /// </summary>
        private string _productId;

        /// <summary>
        /// 
        /// </summary>
        private string _invoiceXOId;

        /// <summary>
        /// 
        /// </summary>
        private string _invoiceCusId;

        /// <summary>
        /// 
        /// </summary>
        private DateTime? _onlineDate;

        /// <summary>
        /// 
        /// </summary>
        private DateTime? _checkDate;

        /// <summary>
        /// 毛边
        /// </summary>
        private string _burr;

        /// <summary>
        /// 擦伤
        /// </summary>
        private string _bruise;

        /// <summary>
        /// 缩水
        /// </summary>
        private string _shrink;

        /// <summary>
        /// 对色
        /// </summary>
        private string _forColor;

        /// <summary>
        /// 折片
        /// </summary>
        private string _flap;

        /// <summary>
        /// 夾著確認
        /// </summary>
        private string _sandwichedConfirm;

        /// <summary>
        /// 
        /// </summary>
        private string _mark;

        /// <summary>
        /// 异常情况
        /// </summary>
        private string _abnormal;

        /// <summary>
        /// 
        /// </summary>
        private string _employeeId;

        /// <summary>
        /// 员工
        /// </summary>
        private Employee _employee;
        /// <summary>
        /// 销售订单
        /// </summary>
        private InvoiceXO _invoiceXO;
        /// <summary>
        /// 
        /// </summary>
        private PCMouldOnlineCheck _pCMouldOnlineCheck;
        /// <summary>
        /// 产品
        /// </summary>
        private Product _product;

        //2018年8月30日16:45:20
        /// <summary>
        /// 外观/软料附着度
        /// </summary>
        private string _appearance;
        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public string PCMouldOnlineCheckDetailId
        {
            get
            {
                return this._pCMouldOnlineCheckDetailId;
            }
            set
            {
                this._pCMouldOnlineCheckDetailId = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PCMouldOnlineCheckId
        {
            get
            {
                return this._pCMouldOnlineCheckId;
            }
            set
            {
                this._pCMouldOnlineCheckId = value;
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
        public DateTime? OnlineDate
        {
            get
            {
                return this._onlineDate;
            }
            set
            {
                this._onlineDate = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? CheckDate
        {
            get
            {
                return this._checkDate;
            }
            set
            {
                this._checkDate = value;
            }
        }

        /// <summary>
        /// 毛边
        /// </summary>
        public string Burr
        {
            get
            {
                return this._burr;
            }
            set
            {
                this._burr = value;
            }
        }

        /// <summary>
        /// 擦伤
        /// </summary>
        public string Bruise
        {
            get
            {
                return this._bruise;
            }
            set
            {
                this._bruise = value;
            }
        }

        /// <summary>
        /// 缩水
        /// </summary>
        public string Shrink
        {
            get
            {
                return this._shrink;
            }
            set
            {
                this._shrink = value;
            }
        }

        /// <summary>
        /// 对色
        /// </summary>
        public string ForColor
        {
            get
            {
                return this._forColor;
            }
            set
            {
                this._forColor = value;
            }
        }

        /// <summary>
        /// 折片
        /// </summary>
        public string Flap
        {
            get
            {
                return this._flap;
            }
            set
            {
                this._flap = value;
            }
        }

        /// <summary>
        /// 夾著確認
        /// </summary>
        public string SandwichedConfirm
        {
            get
            {
                return this._sandwichedConfirm;
            }
            set
            {
                this._sandwichedConfirm = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Mark
        {
            get
            {
                return this._mark;
            }
            set
            {
                this._mark = value;
            }
        }

        /// <summary>
        /// 异常情况
        /// </summary>
        public string Abnormal
        {
            get
            {
                return this._abnormal;
            }
            set
            {
                this._abnormal = value;
            }
        }

        /// <summary>
        /// 
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
        /// 销售订单
        /// </summary>
        public virtual InvoiceXO InvoiceXO
        {
            get
            {
                return this._invoiceXO;
            }
            set
            {
                this._invoiceXO = value;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        public virtual PCMouldOnlineCheck PCMouldOnlineCheck
        {
            get
            {
                return this._pCMouldOnlineCheck;
            }
            set
            {
                this._pCMouldOnlineCheck = value;
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

        //2018年8月30日16:46:18
        /// <summary>
        /// 外观/软料附着度
        /// </summary>
        public string Appearance
        {
            get { return _appearance; }
            set { _appearance = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_PCMouldOnlineCheckDetailId = "PCMouldOnlineCheckDetailId";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_PCMouldOnlineCheckId = "PCMouldOnlineCheckId";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_ProductId = "ProductId";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_InvoiceXOId = "InvoiceXOId";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_InvoiceCusId = "InvoiceCusId";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_OnlineDate = "OnlineDate";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_CheckDate = "CheckDate";

        /// <summary>
        /// 毛边
        /// </summary>
        public readonly static string PRO_Burr = "Burr";

        /// <summary>
        /// 擦伤
        /// </summary>
        public readonly static string PRO_Bruise = "Bruise";

        /// <summary>
        /// 缩水
        /// </summary>
        public readonly static string PRO_Shrink = "Shrink";

        /// <summary>
        /// 对色
        /// </summary>
        public readonly static string PRO_ForColor = "ForColor";

        /// <summary>
        /// 折片
        /// </summary>
        public readonly static string PRO_Flap = "Flap";

        /// <summary>
        /// 夾著確認
        /// </summary>
        public readonly static string PRO_SandwichedConfirm = "SandwichedConfirm";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_Mark = "Mark";

        /// <summary>
        /// 异常情况
        /// </summary>
        public readonly static string PRO_Abnormal = "Abnormal";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_EmployeeId = "EmployeeId";

        public readonly static string PRO_Appearance = "Appearance";

        #endregion
    }
}