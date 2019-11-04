﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：ProductUnit.autogenerated.cs
// author: peidun
// create date：2009-10-13 上午 11:45:17
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
	public partial class ProductUnit
	{
		#region Data

		/// <summary>
		/// 编号
		/// </summary>
		private string _productUnitId;
		
		/// <summary>
		/// 单位组编号
		/// </summary>
		private string _unitGroupId;
		
		/// <summary>
		/// 插入时间
		/// </summary>
		private DateTime? _insertTime;
		
		/// <summary>
		/// 修改时间
		/// </summary>
		private DateTime? _updateTime;
		
		/// <summary>
		/// 单位编号
		/// </summary>
		private string _id;
		
		/// <summary>
		/// 单位中文名称
		/// </summary>
		private string _cnName;
		
		/// <summary>
		/// 单位英文名称
		/// </summary>
		private string _ukName;
		
		/// <summary>
		/// 英文名称复数
		/// </summary>
		private string _ukNames;
		
		/// <summary>
		/// 换算率
		/// </summary>
		private double? _convertRate;
		
		/// <summary>
		/// 条码
		/// </summary>
		private string _unitBarCode;
		
		/// <summary>
		/// 是否是主单位
		/// </summary>
		private bool? _isMainUnit;
		
		/// <summary>
		/// 单位组
		/// </summary>
		private UnitGroup unitGroup;
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 编号
		/// </summary>
		public string ProductUnitId
		{
			get 
			{
				return this._productUnitId;
			}
			set 
			{
				this._productUnitId = value;
			}
		}

		/// <summary>
		/// 单位组编号
		/// </summary>
		public string UnitGroupId
		{
			get 
			{
				return this._unitGroupId;
			}
			set 
			{
				this._unitGroupId = value;
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
		/// 单位编号
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
		/// 单位中文名称
		/// </summary>
		public string CnName
		{
			get 
			{
				return this._cnName;
			}
			set 
			{
				this._cnName = value;
			}
		}

		/// <summary>
		/// 单位英文名称
		/// </summary>
		public string UkName
		{
			get 
			{
				return this._ukName;
			}
			set 
			{
				this._ukName = value;
			}
		}

		/// <summary>
		/// 英文名称复数
		/// </summary>
		public string UkNames
		{
			get 
			{
				return this._ukNames;
			}
			set 
			{
				this._ukNames = value;
			}
		}

		/// <summary>
		/// 换算率
		/// </summary>
		public double? ConvertRate
		{
			get 
			{
				return this._convertRate;
			}
			set 
			{
				this._convertRate = value;
			}
		}

		/// <summary>
		/// 条码
		/// </summary>
		public string UnitBarCode
		{
			get 
			{
				return this._unitBarCode;
			}
			set 
			{
				this._unitBarCode = value;
			}
		}

		/// <summary>
		/// 是否是主单位
		/// </summary>
		public bool? IsMainUnit
		{
			get 
			{
				return this._isMainUnit;
			}
			set 
			{
				this._isMainUnit = value;
			}
		}
	
		/// <summary>
		/// 单位组
		/// </summary>
		public virtual UnitGroup UnitGroup
		{
			get
			{
				return this.unitGroup;
			}
			set
			{
				this.unitGroup = value;
			}
			
		}
		/// <summary>
		/// 编号
		/// </summary>
		public readonly static string PROPERTY_PRODUCTUNITID = "ProductUnitId";
		
		/// <summary>
		/// 单位组编号
		/// </summary>
		public readonly static string PROPERTY_UNITGROUPID = "UnitGroupId";
		
		/// <summary>
		/// 插入时间
		/// </summary>
		public readonly static string PROPERTY_INSERTTIME = "InsertTime";
		
		/// <summary>
		/// 修改时间
		/// </summary>
		public readonly static string PROPERTY_UPDATETIME = "UpdateTime";
		
		/// <summary>
		/// 单位编号
		/// </summary>
		public readonly static string PROPERTY_ID = "Id";
		
		/// <summary>
		/// 单位中文名称
		/// </summary>
		public readonly static string PROPERTY_CNNAME = "CnName";
		
		/// <summary>
		/// 单位英文名称
		/// </summary>
		public readonly static string PROPERTY_UKNAME = "UkName";
		
		/// <summary>
		/// 英文名称复数
		/// </summary>
		public readonly static string PROPERTY_UKNAMES = "UkNames";
		
		/// <summary>
		/// 换算率
		/// </summary>
		public readonly static string PROPERTY_CONVERTRATE = "ConvertRate";
		
		/// <summary>
		/// 条码
		/// </summary>
		public readonly static string PROPERTY_UNITBARCODE = "UnitBarCode";
		
		/// <summary>
		/// 是否是主单位
		/// </summary>
		public readonly static string PROPERTY_ISMAINUNIT = "IsMainUnit";
		

		#endregion
	}
}
