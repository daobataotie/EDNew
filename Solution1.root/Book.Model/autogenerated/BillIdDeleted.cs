﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：BillIdDeleted.autogenerated.cs
// author: mayanjun
// create date：2015/11/20 18:57:01
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
	public partial class BillIdDeleted
	{
		#region Data

		/// <summary>
		/// 
		/// </summary>
		private string _billId;
		
		/// <summary>
		/// 
		/// </summary>
		private DateTime? _deleteTime;
		
		/// <summary>
		/// 
		/// </summary>
		private string _billIdSetId;
		
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 
		/// </summary>
		public string BillId
		{
			get 
			{
				return this._billId;
			}
			set 
			{
				this._billId = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public DateTime? DeleteTime
		{
			get 
			{
				return this._deleteTime;
			}
			set 
			{
				this._deleteTime = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string BillIdSetId
		{
			get 
			{
				return this._billIdSetId;
			}
			set 
			{
				this._billIdSetId = value;
			}
		}
	
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_BillId = "BillId";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_DeleteTime = "DeleteTime";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_BillIdSetId = "BillIdSetId";
		

		#endregion
	}
}