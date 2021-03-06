﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：AnnualHoliday.autogenerated.cs
// author: mayanjun
// create date：2012-2-28 16:36:46
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
    public partial class AnnualHoliday
    {
        #region Data

        /// <summary>
        /// 年假编号
        /// </summary>
        private string _annualHolidayId;

        /// <summary>
        /// 年假日期
        /// </summary>
        private DateTime? _holidayDate;

        /// <summary>
        /// 年假名称
        /// </summary>
        private string _holidayName;

        /// <summary>
        /// 
        /// </summary>
        private string _years;

        /// <summary>
        /// 
        /// </summary>
        private string _departs;

        private bool _isNationalHoliday;

        #endregion

        #region Properties

        /// <summary>
        /// 年假编号
        /// </summary>
        public string AnnualHolidayId
        {
            get
            {
                return this._annualHolidayId;
            }
            set
            {
                this._annualHolidayId = value;
            }
        }

        /// <summary>
        /// 年假日期
        /// </summary>
        public DateTime? HolidayDate
        {
            get
            {
                return this._holidayDate;
            }
            set
            {
                this._holidayDate = value;
            }
        }

        /// <summary>
        /// 年假名称
        /// </summary>
        public string HolidayName
        {
            get
            {
                return this._holidayName;
            }
            set
            {
                this._holidayName = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Years
        {
            get
            {
                return this._years;
            }
            set
            {
                this._years = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Departs
        {
            get
            {
                return this._departs;
            }
            set
            {
                this._departs = value;
            }
        }

        public bool IsNationalHoliday
        {
            get { return _isNationalHoliday; }
            set { _isNationalHoliday = value; }
        }

        /// <summary>
        /// 年假编号
        /// </summary>
        public readonly static string PRO_AnnualHolidayId = "AnnualHolidayId";

        /// <summary>
        /// 年假日期
        /// </summary>
        public readonly static string PRO_HolidayDate = "HolidayDate";

        /// <summary>
        /// 年假名称
        /// </summary>
        public readonly static string PRO_HolidayName = "HolidayName";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_Years = "Years";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_Departs = "Departs";

        public readonly static string PRO_IsNationalHoliday = "IsNationalHoliday";

        #endregion
    }
}
