﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：Flextime.autogenerated.cs
// author: peidun
// create date：2010-3-15 14:33:28
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
	public partial class Flextime
	{
		#region Data

		/// <summary>
		/// 弹性排班编号
		/// </summary>
		private string _flextimeId;
		
		/// <summary>
		/// 编号
		/// </summary>
		private string _businessHoursId;
		
		/// <summary>
		/// 员工编号
		/// </summary>
		private string _employeeId;
		
		/// <summary>
		/// 日期
		/// </summary>
		private DateTime? _flexDate;
		
		/// <summary>
		/// 员工
		/// </summary>
		private Employee _employee;
		/// <summary>
		/// 班别
		/// </summary>
		private BusinessHours _businessHours;
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 弹性排班编号
		/// </summary>
		public string FlextimeId
		{
			get 
			{
				return this._flextimeId;
			}
			set 
			{
				this._flextimeId = value;
			}
		}

		/// <summary>
		/// 编号
		/// </summary>
		public string BusinessHoursId
		{
			get 
			{
				return this._businessHoursId;
			}
			set 
			{
				this._businessHoursId = value;
			}
		}

		/// <summary>
		/// 员工编号
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
		/// 日期
		/// </summary>
		public DateTime? FlexDate
		{
			get 
			{
				return this._flexDate;
			}
			set 
			{
				this._flexDate = value;
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
		/// 班别
		/// </summary>
		public virtual BusinessHours BusinessHours
		{
			get
			{
				return this._businessHours;
			}
			set
			{
				this._businessHours = value;
			}
			
		}
		/// <summary>
		/// 弹性排班编号
		/// </summary>
		public readonly static string PROPERTY_FLEXTIMEID = "FlextimeId";
		
		/// <summary>
		/// 编号
		/// </summary>
		public readonly static string PROPERTY_BUSINESSHOURSID = "BusinessHoursId";
		
		/// <summary>
		/// 员工编号
		/// </summary>
		public readonly static string PROPERTY_EMPLOYEEID = "EmployeeId";
		
		/// <summary>
		/// 日期
		/// </summary>
		public readonly static string PROPERTY_FLEXDATE = "FlexDate";
		

		#endregion
	}
}
