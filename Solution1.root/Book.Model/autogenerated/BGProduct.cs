﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：BGProduct.autogenerated.cs
// author: mayanjun
// create date：2013-4-1 14:01:33
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
    public partial class BGProduct
    {
        #region Data

        /// <summary>
        /// Attribute_1465
        /// </summary>
        private string _bGProductId;

        /// <summary>
        /// 编号
        /// </summary>
        private string _employeeId;

        /// <summary>
        /// 插入时间
        /// </summary>
        private DateTime? _insertTime;

        /// <summary>
        /// 修改时间
        /// </summary>
        private DateTime? _updateTime;

        /// <summary>
        /// Attribute_1466
        /// </summary>
        private string _id;

        /// <summary>
        /// 企业内部编号
        /// </summary>
        private string _qiYeNeiId;

        /// <summary>
        /// 主管海关
        /// </summary>
        private string _zhuGuanHaiGuan;

        /// <summary>
        /// 经营单位编码
        /// </summary>
        private string _jingYingDanWeiId;

        /// <summary>
        /// 经营单位名称
        /// </summary>
        private string _jingYingDanWeiName;

        /// <summary>
        /// 加工单位编码
        /// </summary>
        private string _jiaGongDanWeiId;

        /// <summary>
        /// 加工单位名称
        /// </summary>
        private string _jiaGongDanWeiName;

        /// <summary>
        /// 申报单位编码
        /// </summary>
        private string _shenBaoDanWeiId;

        /// <summary>
        /// 申报单位名称
        /// </summary>
        private string _shenBaoDanWeiName;

        /// <summary>
        /// 管理对象
        /// </summary>
        private string _guanLiDuiXiang;

        /// <summary>
        /// 申报日期
        /// </summary>
        private DateTime? _shenBaoDate;

        /// <summary>
        /// 生产能力(万美元)
        /// </summary>
        private decimal? _shengChanNengLi;

        /// <summary>
        /// 备注
        /// </summary>
        private string _desc;

        /// <summary>
        /// 申报类型
        /// </summary>
        private string _shenBaoType;

        private int? _auditState;

        private string _auditEmpId;

        private Employee _auditEmp;


        /// <summary>
        /// 员工
        /// </summary>
        private Employee _employee;

        #endregion

        #region Properties

        /// <summary>
        /// Attribute_1465
        /// </summary>
        public string BGProductId
        {
            get
            {
                return this._bGProductId;
            }
            set
            {
                this._bGProductId = value;
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
        /// Attribute_1466
        /// </summary>
        public string Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        /// <summary>
        /// 企业内部编号
        /// </summary>
        public string QiYeNeiId
        {
            get
            {
                return this._qiYeNeiId;
            }
            set
            {
                this._qiYeNeiId = value;
            }
        }

        /// <summary>
        /// 主管海关
        /// </summary>
        public string ZhuGuanHaiGuan
        {
            get
            {
                return this._zhuGuanHaiGuan;
            }
            set
            {
                this._zhuGuanHaiGuan = value;
            }
        }

        /// <summary>
        /// 经营单位编码
        /// </summary>
        public string JingYingDanWeiId
        {
            get
            {
                return this._jingYingDanWeiId;
            }
            set
            {
                this._jingYingDanWeiId = value;
            }
        }

        /// <summary>
        /// 经营单位名称
        /// </summary>
        public string JingYingDanWeiName
        {
            get
            {
                return this._jingYingDanWeiName;
            }
            set
            {
                this._jingYingDanWeiName = value;
            }
        }

        /// <summary>
        /// 加工单位编码
        /// </summary>
        public string JiaGongDanWeiId
        {
            get
            {
                return this._jiaGongDanWeiId;
            }
            set
            {
                this._jiaGongDanWeiId = value;
            }
        }

        /// <summary>
        /// 加工单位名称
        /// </summary>
        public string JiaGongDanWeiName
        {
            get
            {
                return this._jiaGongDanWeiName;
            }
            set
            {
                this._jiaGongDanWeiName = value;
            }
        }

        /// <summary>
        /// 申报单位编码
        /// </summary>
        public string ShenBaoDanWeiId
        {
            get
            {
                return this._shenBaoDanWeiId;
            }
            set
            {
                this._shenBaoDanWeiId = value;
            }
        }

        /// <summary>
        /// 申报单位名称
        /// </summary>
        public string ShenBaoDanWeiName
        {
            get
            {
                return this._shenBaoDanWeiName;
            }
            set
            {
                this._shenBaoDanWeiName = value;
            }
        }

        /// <summary>
        /// 管理对象
        /// </summary>
        public string GuanLiDuiXiang
        {
            get
            {
                return this._guanLiDuiXiang;
            }
            set
            {
                this._guanLiDuiXiang = value;
            }
        }

        /// <summary>
        /// 申报日期
        /// </summary>
        public DateTime? ShenBaoDate
        {
            get
            {
                return this._shenBaoDate;
            }
            set
            {
                this._shenBaoDate = value;
            }
        }

        /// <summary>
        /// 生产能力(万美元)
        /// </summary>
        public decimal? ShengChanNengLi
        {
            get
            {
                return this._shengChanNengLi;
            }
            set
            {
                this._shengChanNengLi = value;
            }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Desc
        {
            get
            {
                return this._desc;
            }
            set
            {
                this._desc = value;
            }
        }

        /// <summary>
        /// 申报类型
        /// </summary>
        public string ShenBaoType
        {
            get
            {
                return this._shenBaoType;
            }
            set
            {
                this._shenBaoType = value;
            }
        }
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

        public virtual string AuditEmpId
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
        /// Attribute_1465
        /// </summary>
        public readonly static string PRO_BGProductId = "BGProductId";

        /// <summary>
        /// 编号
        /// </summary>
        public readonly static string PRO_EmployeeId = "EmployeeId";

        /// <summary>
        /// 插入时间
        /// </summary>
        public readonly static string PRO_InsertTime = "InsertTime";

        /// <summary>
        /// 修改时间
        /// </summary>
        public readonly static string PRO_UpdateTime = "UpdateTime";

        /// <summary>
        /// Attribute_1466
        /// </summary>
        public readonly static string PRO_Id = "Id";

        /// <summary>
        /// 企业内部编号
        /// </summary>
        public readonly static string PRO_QiYeNeiId = "QiYeNeiId";

        /// <summary>
        /// 主管海关
        /// </summary>
        public readonly static string PRO_ZhuGuanHaiGuan = "ZhuGuanHaiGuan";

        /// <summary>
        /// 经营单位编码
        /// </summary>
        public readonly static string PRO_JingYingDanWeiId = "JingYingDanWeiId";

        /// <summary>
        /// 经营单位名称
        /// </summary>
        public readonly static string PRO_JingYingDanWeiName = "JingYingDanWeiName";

        /// <summary>
        /// 加工单位编码
        /// </summary>
        public readonly static string PRO_JiaGongDanWeiId = "JiaGongDanWeiId";

        /// <summary>
        /// 加工单位名称
        /// </summary>
        public readonly static string PRO_JiaGongDanWeiName = "JiaGongDanWeiName";

        /// <summary>
        /// 申报单位编码
        /// </summary>
        public readonly static string PRO_ShenBaoDanWeiId = "ShenBaoDanWeiId";

        /// <summary>
        /// 申报单位名称
        /// </summary>
        public readonly static string PRO_ShenBaoDanWeiName = "ShenBaoDanWeiName";

        /// <summary>
        /// 管理对象
        /// </summary>
        public readonly static string PRO_GuanLiDuiXiang = "GuanLiDuiXiang";

        /// <summary>
        /// 申报日期
        /// </summary>
        public readonly static string PRO_ShenBaoDate = "ShenBaoDate";

        /// <summary>
        /// 生产能力(万美元)
        /// </summary>
        public readonly static string PRO_ShengChanNengLi = "ShengChanNengLi";

        /// <summary>
        /// 备注
        /// </summary>
        public readonly static string PRO_Desc = "Desc";

        /// <summary>
        /// 申报类型
        /// </summary>
        public readonly static string PRO_ShenBaoType = "ShenBaoType";

        public readonly static string PRO_AuditState = "AuditState";

        public readonly static string PRO_AuditEmpId = "AuditEmpId";

        #endregion
    }
}
