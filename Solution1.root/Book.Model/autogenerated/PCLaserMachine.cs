﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：PCLaserMachine.autogenerated.cs
// author: mayanjun
// create date：2015/1/18 下午 08:12:17
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
	public partial class PCLaserMachine
	{
		#region Data

		/// <summary>
		/// 
		/// </summary>
		private string _pCLaserMachineId;
		
		/// <summary>
		/// 
		/// </summary>
		private string _pCDataInputId;
		
		/// <summary>
		/// 
		/// </summary>
		private string _noId;
		
		/// <summary>
		/// 
		/// </summary>
		private decimal? _leftX;
		
		/// <summary>
		/// 
		/// </summary>
		private decimal? _rightX;
		
		/// <summary>
		/// 
		/// </summary>
		private decimal? _leftY;
		
		/// <summary>
		/// 
		/// </summary>
		private decimal? _rightY;
		
		/// <summary>
		/// 
		/// </summary>
		private string _judge;
		
		/// <summary>
		/// 
		/// </summary>
		private PCDataInput _pCDataInput;
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 
		/// </summary>
		public string PCLaserMachineId
		{
			get 
			{
				return this._pCLaserMachineId;
			}
			set 
			{
				this._pCLaserMachineId = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string PCDataInputId
		{
			get 
			{
				return this._pCDataInputId;
			}
			set 
			{
				this._pCDataInputId = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string NoId
		{
			get 
			{
				return this._noId;
			}
			set 
			{
				this._noId = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal? LeftX
		{
			get 
			{
				return this._leftX;
			}
			set 
			{
				this._leftX = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal? RightX
		{
			get 
			{
				return this._rightX;
			}
			set 
			{
				this._rightX = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal? LeftY
		{
			get 
			{
				return this._leftY;
			}
			set 
			{
				this._leftY = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal? RightY
		{
			get 
			{
				return this._rightY;
			}
			set 
			{
				this._rightY = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Judge
		{
			get 
			{
				return this._judge;
			}
			set 
			{
				this._judge = value;
			}
		}
	
		/// <summary>
		/// 
		/// </summary>
		public virtual PCDataInput PCDataInput
		{
			get
			{
				return this._pCDataInput;
			}
			set
			{
				this._pCDataInput = value;
			}
			
		}
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_PCLaserMachineId = "PCLaserMachineId";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_PCDataInputId = "PCDataInputId";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_NoId = "NoId";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_LeftX = "LeftX";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_RightX = "RightX";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_LeftY = "LeftY";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_RightY = "RightY";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_Judge = "Judge";
		

		#endregion
	}
}